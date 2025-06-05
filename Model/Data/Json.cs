using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Model.Core;
using Newtonsoft.Json;

namespace Model.Data
{
    public class Json : Serializer
    {
        public override void Serialize<T>(T data, string filePath)
        {
            if (data is Building building)
            {
                var dto = ConvertToDto(building);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(dto));
            }
        }
        public override T Deserialize<T>(string filePath)
        {
            if (!File.Exists(filePath)) return default;

            string json = File.ReadAllText(filePath);
            var dto = JsonConvert.DeserializeObject<BuildingDto>(json);
            return (T)(object)ConvertFromDto(dto);
        }
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
                _ => throw new InvalidOperationException($"Неизвестный тип заведения: {dto.Type}")
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
                    _ => throw new InvalidOperationException($"Неизвестный тип блюда: {dishDto.Type}")
                };
                menu.AddDish(dish);
            }
            return menu;
        }
        public override string GetFileExtension()
        {
            return "json";
        }
    }
}
