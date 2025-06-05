using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public abstract partial class Building
    {
        public string Name { get; protected set; }
        public IMenu MainMenu { get; protected set; }
        protected Building(string name, IMenu mainMenu)
        {
            Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Название не может быть пустым");
            MainMenu = mainMenu ?? throw new ArgumentNullException(nameof(mainMenu));
        }
        public abstract string GetBuildingType();
    }
    public class Restaurant : Building
    {
        public Restaurant(string name, IMenu mainMenu) : base(name, mainMenu) { }
        public override string GetBuildingType() => "Ресторан";
    }
    public class Cafe : Building
    {
        public Cafe(string name, IMenu mainMenu) : base(name, mainMenu) { }
        public override string GetBuildingType() => "Кафе";

    }
    public class CoffeeShop : Building
    {
        public CoffeeShop(string name, IMenu mainMenu) : base(name, mainMenu) { }
        public override string GetBuildingType() => "Кофейня";
    }



    public partial class Building : ISeasonalMenu
    {
        private IMenu _seasonalMenu; 
        public IMenu SeasonalMenu => _seasonalMenu;
        public bool HasSeasonalMenu => _seasonalMenu != null;
        public void AddSeasonalMenu(IMenu menu)
        {
            if (menu == null)
                throw new ArgumentNullException(nameof(menu));
            if (HasSeasonalMenu)
                throw new InvalidOperationException("Сезонное меню уже существует");

            _seasonalMenu = menu;
        }
        public void RemoveSeasonalMenu()
        {
            if (!HasSeasonalMenu)
                throw new InvalidOperationException("Нет сезонного меню для удаления");

            _seasonalMenu = null;
        }


    }
    public partial class Building
    {
        public List<Dish> Select(Type dishType)
        {
            if (MainMenu?.Dishes == null) return new List<Dish>();
            if (dishType == null)
                throw new ArgumentNullException(nameof(dishType));
            if (!typeof(Dish).IsAssignableFrom(dishType))
                throw new ArgumentException("Тип должен быть наследником Dish", nameof(dishType));

            var selectedDishes = new List<Dish>();
            foreach (var dish in MainMenu.Dishes)
            {
                if (dish.GetType() == dishType)
                {
                    selectedDishes.Add(dish);
                }
            }
            return selectedDishes;
        }
        public List<Dish> Select(string dishTypeName)
        {
            if (string.IsNullOrWhiteSpace(dishTypeName))
                throw new ArgumentException("Название типа не может быть пустым", nameof(dishTypeName));

            var selectedDishes = new List<Dish>();
            foreach (var dish in MainMenu.Dishes)
            {
                if (string.Equals(dish.GetDishType(), dishTypeName, StringComparison.OrdinalIgnoreCase))
                {
                    selectedDishes.Add(dish);
                }
            }
            return selectedDishes;
        }
        public override string ToString()
        {
            return Name;
        }


    }
}
