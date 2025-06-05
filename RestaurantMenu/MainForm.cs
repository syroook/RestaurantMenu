using Model.Core;
using RestaurantMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantMenu
{
    public partial class MainForm : Form
    {
        private SerializationFormat _currentFormat;
        private BuildingManager _buildingManager;

        public MainForm()
        {
            InitializeComponent();
            _currentFormat = DetectCurrentFormat();
            InitializeBuildingManager();
            LoadBuildings();
            SetupUI();
        }
        private void LoadBuildings()
        {

            _buildingManager = new BuildingManager(SerializerFactory.Create(_currentFormat));

            var dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dataDir) || !Directory.GetFiles(dataDir, $"*.*").Any())
            {
                // Если файлов нет вообще — создаем тестовые данные в текущем формате
                var testBuildings = SampleDataGenerator.CreateTestBuildings();
                foreach (var building in testBuildings)
                {
                    _buildingManager.AddBuilding(building);
                    SaveBuildingToFile(building);
                }
            }
            else
            {
                // Загружаем данные из файлов текущего формата
                _buildingManager.LoadBuildings();
            }

            RefreshBuildingList();
            RefreshTypeFilter();
        }
        private SerializationFormat DetectCurrentFormat()
        {
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (Directory.Exists(dataDir))
            {
                // Проверяем, есть ли XML-файлы
                if (Directory.GetFiles(dataDir, "*.xml").Length > 0)
                    return SerializationFormat.Xml;
            }
            return SerializationFormat.Json; // По умолчанию JSON
        }

        private void InitializeBuildingManager()
        {
            var serializer = SerializerFactory.Create(_currentFormat);
            _buildingManager = new BuildingManager(serializer);
        }
        private void SetupUI()
        {
            formatComboBox.DataSource = Enum.GetValues(typeof(SerializationFormat));
            formatComboBox.SelectedItem = _currentFormat;
            formatComboBox.SelectedIndexChanged += FormatComboBox_SelectedIndexChanged;

            buildingTypeFilterComboBox.SelectedIndexChanged += BuildingTypeFilterComboBox_SelectedIndexChanged;
            menuTypeComboBox.SelectedIndex = 0;
        }

        private void RefreshBuildingList()
        {
            buildingsListBox.Items.Clear();
            var selectedType = buildingTypeFilterComboBox.SelectedItem?.ToString();
            IEnumerable<Building> buildings;

            if (string.IsNullOrEmpty(selectedType) || selectedType == "Все")
            {
                buildings = _buildingManager.GetBuildingsByType("");
            }
            else
            {
                buildings = _buildingManager.GetBuildingsByType(selectedType);
            }

            foreach (var building in buildings)
            {
                buildingsListBox.Items.Add(building);
            }

            UpdateUIState();
        }

        private void RefreshTypeFilter()
        {
            buildingTypeFilterComboBox.Items.Clear();
            buildingTypeFilterComboBox.Items.Add("Все");

            var types = new HashSet<string>();
            foreach (var building in _buildingManager.GetBuildingsByType(""))
            {
                types.Add(building.GetBuildingType());
            }

            foreach (var type in types)
            {
                buildingTypeFilterComboBox.Items.Add(type);
            }

            buildingTypeFilterComboBox.SelectedIndex = 0;
        }

        private void UpdateUIState()
        {
            bool hasSelection = buildingsListBox.SelectedItem != null;
            showMenuButton.Enabled = hasSelection;
            menuTypeComboBox.Enabled = hasSelection;
            saveMenuButton.Enabled = hasSelection;
        }

        private void SaveBuildingToFile(Building building)
        {
            string fileName = $"{building.Name}.{_buildingManager.GetFileExtension()}";
            string filePath = Path.Combine("Data", fileName);

            // Удаляем старый файл, если он был в другом формате
            var oldExtension = _currentFormat == SerializationFormat.Json ? "xml" : "json";
            var oldFile = Path.ChangeExtension(filePath, oldExtension);
            if (File.Exists(oldFile))
            {
                File.Delete(oldFile);
            }

            // Сохраняем в текущем формате
            _buildingManager.SaveBuilding(building, filePath);

        }

        private void showMenuButton_Click(object sender, EventArgs e)
        {
            if (buildingsListBox.SelectedItem is Building selectedBuilding)
            {
                IMenu menuToShow = menuTypeComboBox.SelectedIndex == 0
                    ? selectedBuilding.MainMenu
                    : (selectedBuilding as ISeasonalMenu)?.SeasonalMenu;

                if (menuToShow == null)
                {
                    MessageBox.Show("Сезонное меню отсутствует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var menuForm = new MenuForm(menuToShow, selectedBuilding.Name);
                menuForm.ShowDialog();
            }
        }

        private void buildingsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (buildingsListBox.SelectedItem is Building selectedBuilding)
            {
                UpdateUIState();
            }
            else
            {
                showMenuButton.Enabled = false;
            }
        }

        private void FormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formatComboBox.SelectedItem is SerializationFormat newFormat && newFormat != _currentFormat)
            {
                // Конвертируем все файлы в новый формат
                ConvertFilesToNewFormat(newFormat);
                _currentFormat = newFormat;
                InitializeBuildingManager();
                LoadBuildings();
            }
        }

        private void ConvertFilesToNewFormat(SerializationFormat newFormat)
        {
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dataDir)) return;

            var oldSerializer = SerializerFactory.Create(_currentFormat);
            var newSerializer = SerializerFactory.Create(newFormat);

            // Сначала конвертируем все файлы
            foreach (var file in Directory.GetFiles(dataDir, $"*.{oldSerializer.GetFileExtension()}"))
            {
                var building = oldSerializer.Deserialize<Building>(file);
                if (building != null)
                {
                    string newFileName = Path.ChangeExtension(file, newSerializer.GetFileExtension());
                    newSerializer.Serialize(building, newFileName);
                    // Затем удаляем все файлы старого формата
                    if (File.Exists(newFileName))
                    {
                        File.Delete(file);
                    }
                }
            }
        }
        private void BuildingTypeFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBuildingList();
        }
        private void saveMenuButton_Click(object sender, EventArgs e)
        {
            if (buildingsListBox.SelectedItem is Building selectedBuilding)
            {
                SaveBuildingToFile(selectedBuilding);
                MessageBox.Show("Меню успешно сохранено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Перезагружаем данные, чтобы убедиться в корректности
                LoadBuildings();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
