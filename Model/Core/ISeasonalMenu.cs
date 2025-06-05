using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public interface ISeasonalMenu
    {
        IMenu SeasonalMenu { get; }
        bool HasSeasonalMenu { get; }
        void AddSeasonalMenu(IMenu menu);
        void RemoveSeasonalMenu();

    }
}
