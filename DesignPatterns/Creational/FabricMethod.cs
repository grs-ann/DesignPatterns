using System;

namespace DesignPatterns_FabricMethod
{
    // Определяет общий интерфейс для различных классов-продуктов.
    public interface IProduct
    {
        // Название продукта.
        public string Name { get; set; }
        // Цена продукта
        public decimal Price { get; set; }
        // Метод для получения названия продукта.
        public string GetName();
        // Метод для получения цены продукта.
        public decimal GetPrice();
    }
    // Класс конкретного продукта типа "A". Реализует интерфейс IProduct.
    public class ConcreteProductA : IProduct
    {
        public ConcreteProductA(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string GetName()
        {
            return Name;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
    // Класс конкретного продукта типа "B". Реализует интерфейс IProduct.
    public class ConcreteProductB : IProduct
    {
        public ConcreteProductB(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string GetName()
        {
            return Name;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
    // Абстрактный класс создателя - обьявляет фабричный метод для 
    // конкретных классов-создателей, а так же содержит какую то общую бизнес логику, 
    // связанную с продуктами.
    public abstract class Creator
    {
        // "Создатель" объявляет фабричный метод.
        // Он не обязательно должен быть именно абстрактным,
        // можно добавить реализацию и по умолчанию.
        // Должен возвращать именно общий интерфейс, 
        // связывающий собой все продукты.
        public abstract IProduct FactoryMethod();
        // !!! ***
        // На самом деле, создание экземпляров различных типов продуктов
        // не является ключевой обязанностью фабричного метода.
        // Он может выполнять и какую-то свою бизнес-логику, 
        // связанную с этими продуктами.
        public string SomeOperation()
        {
            var product = FactoryMethod();
            return $"Продукт под названием '{product.GetName()}'\n" +
                $"Имеет стоимость {product.GetPrice()}.";
        }
    }
    // Конкретный создатель наследуется от 
    // абстрактного создателя, и реализует
    // фабричный метод по-своему.
    public class ConcreteCreatorA : Creator
    {
        // Следует понимать, что, хотя возвращаемый
        // тип абстрактного метода - интерфейс IProduct,
        // возвращается по факту конкретный тип какого-то
        // продукта!
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA("Вкусная булочка", (decimal)99.99);
        }
    }
    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB("Вкусный лимонад", 69);
        }
    }
}
