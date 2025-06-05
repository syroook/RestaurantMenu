using Model.Core;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Model.Core
{
    public class BuildingManager 
    {
        private readonly List<Building> _buildings = new();
        private readonly Serializer _serializer;
        private readonly string _dataDirectory;

        public BuildingManager(Serializer serializer)
        {
            _serializer = serializer;
            _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(_dataDirectory);
            LoadBuildings();
        }
        public void LoadBuildings()
        {
            _buildings.Clear();

            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
                return;
            }

            string currentExtension = _serializer.GetFileExtension();
            string otherExtension = currentExtension == "json" ? "xml" : "json";

            // Загружаем все файлы обоих форматов
            foreach (var file in Directory.GetFiles(_dataDirectory, "*.*"))
            {
                string fileExtension = Path.GetExtension(file).TrimStart('.');
                if (fileExtension != currentExtension && fileExtension != otherExtension)
                    continue;

                // Определяем нужный сериализатор
                var serializer = fileExtension == currentExtension
                    ? _serializer
                    : SerializerFactory.Create(fileExtension == "json"
                        ? SerializationFormat.Json
                        : SerializationFormat.Xml);

                var buildingName = Path.GetFileNameWithoutExtension(file);
                if (_buildings.Any(b => b.Name == buildingName))
                    continue;

                var building = serializer.Deserialize<Building>(file);
                if (building == null)
                    continue;

                _buildings.Add(building);

                // Конвертируем в текущий формат если нужно
                if (fileExtension != currentExtension)
                {
                    string newPath = Path.ChangeExtension(file, currentExtension);
                    _serializer.Serialize(building, newPath);
                }
            }
        }
        public string GetFileExtension() => _serializer is Json ? "json" : "xml";
        public void SaveBuilding(Building building, string filePath)
        {
            _serializer.Serialize(building, filePath);
        }

        public Building LoadBuilding(string filePath)
        {
            return _serializer.Deserialize<Building>(filePath);
        }


        public void AddBuilding(Building building)
        {
            _buildings.Add(building);
        }

        public IEnumerable<Building> GetBuildingsByType(string type)
        {
            if (string.IsNullOrEmpty(type))
                return _buildings;

            return _buildings.Where(b => b.GetBuildingType().Equals(type, StringComparison.OrdinalIgnoreCase));
        }
    }
}


