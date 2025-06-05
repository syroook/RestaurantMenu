using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public abstract class Dish
    {
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }

        protected Dish(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым", nameof(name));
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена должна быть положительной");
            Name = name;
            Price = price;

        }
        public abstract string GetDishType();
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Dish otherDish))
                return false;

            return Name == otherDish.Name && Price == otherDish.Price && GetType() == obj.GetType();
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, GetType());
        }
    }
}
public class Appetizer : Dish 
{
    public Appetizer(string name, decimal price) : base(name, price) { }

    public override string GetDishType() => "Закуски";
}
public class MainDish : Dish
{
    public MainDish(string name, decimal price) : base(name, price) { }

    public override string GetDishType() => "Горячее Блюдо";
}
public class Salad : Dish
{
    public Salad(string name, decimal price) : base(name, price) { }

    public override string GetDishType() => "Салат";
}
public class Drink : Dish
{
    public Drink(string name, decimal price) : base(name, price) { }

    public override string GetDishType() => "Напитки";
}
public class Dessert : Dish
{
    public Dessert(string name, decimal price) : base(name, price) { }

    public override string GetDishType() => "Десерт";
}
public class Breakfast : Dish
{
    public Breakfast(string name, decimal price) : base(name, price) { }

    public override string GetDishType() => "Завтрак";
}
