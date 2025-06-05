using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public interface IMenu
    {
        string Name { get; }
        IReadOnlyList<Dish> Dishes { get; } 
        void AddDish(Dish dish);
        void RemoveDish(Dish dish);
        void ClearMenu();
    }
}
