using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Model.Data
{
    public class Xml : Serializer
    {
        public override void Serialize<T>(T data, string filePath)
        {
            try
            {
                if (data is Building building)
                {
                    var dto = ConvertToDto(building);
                    var serializer = new XmlSerializer(typeof(BuildingDto));

                    // Убедимся, что создаем директорию, если ее нет
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Используем настройки для корректного форматирования
                    var settings = new XmlWriterSettings
                    {
                        Indent = true,
                        Encoding = Encoding.UTF8
                    };

                    using (var writer = XmlWriter.Create(filePath, settings))
                    {
                        var namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("", ""); // Убираем namespace
                        serializer.Serialize(writer, dto, namespaces);
                    }
                }
                else
                {
                    throw new InvalidOperationException("XML serialization supports only Building type");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"XML serialization failed: {ex.Message}", ex);
            }
        }

        public override T Deserialize<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return default;

                var serializer = new XmlSerializer(typeof(BuildingDto));
                using (var reader = new StreamReader(filePath))
                {
                    var dto = (BuildingDto)serializer.Deserialize(reader);
                    return (T)(object)ConvertFromDto(dto);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"XML deserialization failed: {ex.Message}", ex);
            }
        }

        // Методы преобразования между DTO и доменными объектами
        private BuildingDto ConvertToDto(Building building)
        {
            return new BuildingDto
            {
                Name = building.Name,
                Type = building.GetBuildingType(),
                MainMenu = ConvertMenuToDto(building.MainMenu),
                SeasonalMenu = building is ISeasonalMenu seasonal && seasonal.HasSeasonalMenu
                    ? ConvertMenuToDto(seasonal.SeasonalMenu)
                    : null
            };
        }

        private MenuDto ConvertMenuToDto(IMenu menu)
        {
            return new MenuDto
            {
                Name = menu.Name,
                Dishes = menu.Dishes.Select(d => new DishDto
                {
                    Name = d.Name,
                    Price = d.Price,
                    Type = d.GetType().Name
                }).ToList()
            };
        }

        private Building ConvertFromDto(BuildingDto dto)
        {
            var mainMenu = ConvertMenuFromDto(dto.MainMenu);

            Building building = dto.Type switch
            {
                "Ресторан" => new Restaurant(dto.Name, mainMenu),
                "Кафе" => new Cafe(dto.Name, mainMenu),
                "Кофейня" => new CoffeeShop(dto.Name, mainMenu),
                _ => throw new InvalidOperationException($"Unknown building type: {dto.Type}")
            };

            if (dto.SeasonalMenu != null && building is ISeasonalMenu seasonal)
            {
                seasonal.AddSeasonalMenu(ConvertMenuFromDto(dto.SeasonalMenu));
            }

            return building;
        }

        private Menu ConvertMenuFromDto(MenuDto dto)
        {
            var menu = new Menu(dto.Name);
            foreach (var dishDto in dto.Dishes)
            {
                Dish dish = dishDto.Type switch
                {
                    nameof(Appetizer) => new Appetizer(dishDto.Name, dishDto.Price),
                    nameof(MainDish) => new MainDish(dishDto.Name, dishDto.Price),
                    nameof(Salad) => new Salad(dishDto.Name, dishDto.Price),
                    nameof(Drink) => new Drink(dishDto.Name, dishDto.Price),
                    nameof(Dessert) => new Dessert(dishDto.Name, dishDto.Price),
                    nameof(Breakfast) => new Breakfast(dishDto.Name, dishDto.Price),
                    _ => throw new InvalidOperationException($"Unknown dish type: {dishDto.Type}")
                };
                menu.AddDish(dish);
            }
            return menu;
        }
        public override string GetFileExtension() => "xml";
    }

    public class BuildingDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("MainMenu")]
        public MenuDto MainMenu { get; set; }

        [XmlElement("SeasonalMenu")]
        public MenuDto SeasonalMenu { get; set; }
    }
    public class MenuDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlArray("Dishes")]
        [XmlArrayItem("Dish")]
        public List<DishDto> Dishes { get; set; } = new List<DishDto>();
    }
    public class DishDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Price")]
        public decimal Price { get; set; }

        [XmlAttribute("Type")]
        public string Type { get; set; }
    }
}
