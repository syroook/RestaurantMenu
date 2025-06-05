using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class Menu : IMenu
    {
        public string Name { get; }
        private readonly List<Dish> _dishes;
        public IReadOnlyList<Dish> Dishes => _dishes.AsReadOnly();
        public Menu(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название меню не может быть пустым", nameof(name));
            Name = name;
            _dishes = new List<Dish>();
        }
        public void AddDish(Dish dish)
        {
            if (dish == null)
                throw new ArgumentNullException(nameof(dish), "Блюдо не может быть null");
            if (_dishes.Any(d => d.Equals(dish)))
                throw new InvalidOperationException($"Блюдо '{dish.Name}' уже существует в меню");
            _dishes.Add(dish);
        }
        public void RemoveDish(Dish dish) //Приведение к базовуму классу Dish
        {
            if (dish == null)
                throw new ArgumentNullException(nameof(dish), "Блюдо не может быть null");

            var removedCount = _dishes.RemoveAll(d => d.Equals(dish));

            if (removedCount == 0)
                throw new KeyNotFoundException($"Блюдо '{dish.Name}' не найдено в меню");
        }
        public void ClearMenu()
        {
            _dishes.Clear();
        }
    }
    public partial class Menu
    {
        public void AddDish(Dish[] dishes)
        {
            if (dishes == null)
                throw new ArgumentNullException(nameof(dishes));

            foreach (var dish in dishes)
            {
                AddDish(dish); //dry
            }
        }
        public void RemoveDish(Dish[] dishes)
        {
            if (dishes == null)
                throw new ArgumentNullException(nameof(dishes));

            foreach (var dish in dishes)
            {
                RemoveDish(dish); 
            }
        }
    }

}
