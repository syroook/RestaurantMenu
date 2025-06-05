using Model.Core;
using RestaurantMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurantMenu
{
    public partial class MenuForm : Form
    {
        private readonly IMenu _menu;
        private readonly string _buildingName;

        public MenuForm(IMenu menu, string buildingName)
        {
            InitializeComponent();
            _menu = menu;
            _buildingName = buildingName;

            // Инициализация столбцов DataGridView
            InitializeDataGridViewColumns();

            InitializeDishTypes();
            LoadMenu();
        }
        private void InitializeDataGridViewColumns()
        {
            menuDataGridView.Columns.Clear();
            menuDataGridView.AllowUserToAddRows = false;
            // Настройки таблицы
            menuDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            menuDataGridView.AllowUserToResizeRows = false;
            menuDataGridView.RowHeadersVisible = false;
            menuDataGridView.ReadOnly = true;
            menuDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            menuDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Добавляем столбцы с пропорциональным заполнением
            menuDataGridView.Columns.Add("Name", "Название");
            menuDataGridView.Columns.Add("Price", "Цена");
            menuDataGridView.Columns.Add("Type", "Тип");

            // Настраиваем ширину столбцов (сумма процентов = 100)
            menuDataGridView.Columns["Name"].FillWeight = 50; // 50% ширины
            menuDataGridView.Columns["Price"].FillWeight = 25; // 25% ширины
            menuDataGridView.Columns["Type"].FillWeight = 25; // 25% ширины

            // Форматирование цены
            menuDataGridView.Columns["Price"].DefaultCellStyle.Format = "C2";
            menuDataGridView.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void InitializeDishTypes()
        {
            dishTypeFilterComboBox.Items.Add("Все");
            dishTypeFilterComboBox.Items.AddRange(new object[]
            {
                "Закуски",
                "Горячее Блюдо",
                "Салат",
                "Напитки",
                "Десерт",
                "Завтрак"
            });
            dishTypeFilterComboBox.SelectedIndex = 0;
        }

        private void LoadMenu()
        {
            Text = $"{_buildingName} - {_menu.Name}";
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            // Очищаем текущие данные
            menuDataGridView.Rows.Clear();

            // Проверяем, что столбцы созданы
            if (menuDataGridView.Columns.Count == 0)
            {
                InitializeDataGridViewColumns();
            }

            var selectedType = dishTypeFilterComboBox.SelectedItem?.ToString();
            var dishesToShow = _menu.Dishes;

            if (!string.IsNullOrEmpty(selectedType) && selectedType != "Все")
            {
                dishesToShow = _menu.Dishes.Where(d => d.GetDishType() == selectedType).ToList();
            }

            foreach (var dish in dishesToShow)
            {
                menuDataGridView.Rows.Add(dish.Name, dish.Price, dish.GetDishType());
            }
        }

        private void dishTypeFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void addDishButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddDishForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Проверяем, есть ли блюдо с такой же ценой
                if (_menu.Dishes.Any(d => d.Name == addForm.DishName))
                {
                    MessageBox.Show("Блюдо с таким названием уже существует в меню!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dish = CreateDish(addForm.DishType, addForm.DishName, addForm.DishPrice);
                _menu.AddDish(dish);
                ApplyFilter();
            }
        }

        private void removeDishButton_Click(object sender, EventArgs e)
        {
            if (menuDataGridView.SelectedRows.Count > 0)
            {
                var selectedDishName = menuDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                var dishToRemove = _menu.Dishes.FirstOrDefault(d => d.Name == selectedDishName);

                if (dishToRemove != null)
                {
                    _menu.RemoveDish(dishToRemove);
                    ApplyFilter(); // Обновить отображение
                }
            }
            else
            {
                MessageBox.Show("Выберите блюдо для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Dish CreateDish(string dishType, string name, decimal price)
        {
            return dishType switch
            {
                "Закуски" => new Appetizer(name, price),
                "Горячее Блюдо" => new MainDish(name, price),
                "Салат" => new Salad(name, price),
                "Напитки" => new Drink(name, price),
                "Десерт" => new Dessert(name, price),
                "Завтрак" => new Breakfast(name, price),
                _ => throw new ArgumentException("Неизвестный тип блюда")
            };
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Здесь можно добавить сохранение изменений
            base.OnFormClosing(e);
        }
    }
}
