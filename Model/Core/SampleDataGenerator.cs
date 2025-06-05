using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public static class SampleDataGenerator
    {
        public static List<Building> CreateTestBuildings()
        {
            var buildings = new List<Building>();

            // 1. Премиум ресторан
            var premiumMain = new Menu("Основное меню");
            premiumMain.AddDish(new MainDish("Томленый говяжий щёчки", 1890m));
            premiumMain.AddDish(new MainDish("Утиная грудка с вишневым соусом", 1650m));
            premiumMain.AddDish(new Appetizer("Тартар из говядины", 890m));
            premiumMain.AddDish(new Drink("Вино Кьянти", 850m));

            var premiumWinter = new Menu("Зимнее меню");
            premiumWinter.AddDish(new MainDish("Жаркое из оленины", 2100m));
            premiumWinter.AddDish(new Dessert("Глинтвейн домашний", 650m));

            var premium = new Restaurant("Пушкинъ", premiumMain);
            premium.AddSeasonalMenu(premiumWinter);
            buildings.Add(premium);

            // 2. Средний ресторан
            var midMain = new Menu("Основное меню");
            midMain.AddDish(new MainDish("Стейк Рибай", 1490m));
            midMain.AddDish(new MainDish("Паста Карбонара", 790m));
            midMain.AddDish(new Salad("Цезарь с курицей", 590m));
            midMain.AddDish(new Drink("Крафтовое пиво", 390m));

            var midSummer = new Menu("Летнее меню");
            midSummer.AddDish(new Salad("Теплый салат с креветками", 890m));
            midSummer.AddDish(new Drink("Лимонад домашний", 290m));

            var midRest = new Restaurant("Честная кухня", midMain);
            midRest.AddSeasonalMenu(midSummer);
            buildings.Add(midRest);

            // 3. Кафе-пекарня
            var bakeryMain = new Menu("Основное меню");
            bakeryMain.AddDish(new Breakfast("Сырники с вареньем", 390m));
            bakeryMain.AddDish(new Breakfast("Авокадо-тост", 450m));
            bakeryMain.AddDish(new Dessert("Круассан классический", 220m));
            bakeryMain.AddDish(new Drink("Капучино", 280m));

            var bakeryAutumn = new Menu("Осеннее меню");
            bakeryAutumn.AddDish(new Dessert("Тыквенный латте", 320m));
            bakeryAutumn.AddDish(new Breakfast("Овсянка с ягодами", 350m));

            var bakery = new Cafe("Булка", bakeryMain);
            bakery.AddSeasonalMenu(bakeryAutumn);
            buildings.Add(bakery);

            // 4. Кофейня
            var coffeeMain = new Menu("Кофейная карта");
            coffeeMain.AddDish(new Drink("Эспрессо", 180m));
            coffeeMain.AddDish(new Drink("Флэт Уайт", 250m));
            coffeeMain.AddDish(new Dessert("Тирамису", 350m));
            coffeeMain.AddDish(new Dessert("Маффин шоколадный", 220m));

            var coffeeSpring = new Menu("Весеннее меню");
            coffeeSpring.AddDish(new Drink("Кокосовый раф", 320m));
            coffeeSpring.AddDish(new Dessert("Клубничный чизкейк", 420m));

            var coffeeShop = new CoffeeShop("Кофе и Торт", coffeeMain);
            coffeeShop.AddSeasonalMenu(coffeeSpring);
            buildings.Add(coffeeShop);

            // 5. Фастфуд
            var fastfoodMain = new Menu("Основное меню");
            fastfoodMain.AddDish(new MainDish("Чизбургер", 290m));
            fastfoodMain.AddDish(new MainDish("Картофель фри", 190m));
            fastfoodMain.AddDish(new Drink("Кола", 150m));
            fastfoodMain.AddDish(new Dessert("Мороженое", 120m));

            var fastfoodSummer = new Menu("Летнее меню");
            fastfoodSummer.AddDish(new Drink("Молочный коктейль", 220m));
            fastfoodSummer.AddDish(new Salad("Овощной салат", 180m));

            var fastfood = new Cafe("Бургер & Co", fastfoodMain);
            fastfood.AddSeasonalMenu(fastfoodSummer);
            buildings.Add(fastfood);

            return buildings;
        }
    }
}
