using System;

namespace SpecificPatternsImplementations.Creational
{
    /// <summary>
    /// Общий интерфейс для продуктов.
    /// </summary>
    public interface IProduct
    {
        double? GetPrice();
        string GetName();
    }
    /// <summary>
    /// Продукт, реализующий общий интерфейс.
    /// </summary>
    public class Cookie : IProduct
    {
        private string Name { get; set; }
        private double? Price { get; set; }
        public Cookie(string name, double? price)
        {
            Name = name;
            Price = price;
        }
        public string GetName()
        {
            if (Name != null)
            {
                return Name;
            }
            return null;
        }
        public double? GetPrice()
        {
            if (Price != null)
            {
                return Price;
            }
            return null;
        }
    }
    public class Cake : IProduct
    {
        private string Name { get; set; }
        private double? Price { get; set; }
        public Cake(string name, double? price)
        {
            Name = name;
            Price = price;
        }
        public string GetName()
        {
            if (Name != null)
            {
                return Name;
            }
            return null;
        }
        public double? GetPrice()
        {
            if (Price != null)
            {
                return Price;
            }
            return null;
        }
    }
    public abstract class Factory
    {
        private int Discount { get; set; }
        public Factory(int discount)
        {
            Discount = discount;
        }
        public abstract IProduct FactoryMethod();
        public void ShowPriceWithDiscount()
        {
            var product = FactoryMethod();
            Console.WriteLine($"Товар {product.GetName()}" +
                $"с учетом скидки стоит {product.GetPrice() * Discount / 100} руб.");
        }
        public void ShowPriceWithoutDiscount()
        {
            var product = FactoryMethod();
            Console.WriteLine($"Товар {product.GetName()} стоит {product.GetPrice()} руб.");
        }
    }
    /// <summary>
    /// Данный класс наследуется от "Абстрактной фабрики",
    /// и переопределяет фабричный метод так, чтобы возвращался
    /// объект Cake.
    /// </summary>
    public class CakeCreator : Factory
    {
        // Скидка в 20%.
        public CakeCreator() : base(20)
        {
        }
        public override IProduct FactoryMethod()
        {
            return new Cake("Пирожное", 65.49);
        }
    }
    /// <summary>
    /// Данный класс наследуется от "Абстрактной фабрики",
    /// и переопределяет фабричный метод так, чтобы возвращался
    /// объект Cookie.
    /// </summary>
    public class CookieCreator : Factory
    {
        // Скидка в 15%.
        public CookieCreator() : base(15)
        {
        }
        public override IProduct FactoryMethod()
        {
            return new Cookie("Печенье", 49.99);
        }
    }
}
