using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.AbstractFacrory
{
    // Базовый интерфейс для всех вариаций продукта
    // типа "A". В данном случае, это тип столов.
    public interface IAbstractProductA
    {
        public string GetName();
    }
    // Базовый интерфейс для всех вариаций продукта
    // типа "B". В данном случае, это тип стульев.
    public interface IAbstractProductB
    {
        public string GetName();
        public void ShowCarrying()
        {
            Console.WriteLine($"Грузоподъемность стула: {Carrying} кг. ");
        }
        // Грузоподъемность стула.
        public int Carrying { get; set; }
    }
    // Конкретный продукт типа столов. В данном случае это 
    // будет стол типа "Модерн".
    public class ConcreteProductA1 : IAbstractProductA
    {
        public string GetName()
        {
            return "Стол типа модерн";
        }
    }
    // Конкретный продукт типа столов. В данном случае это 
    // будет стол типа "Лофт".
    public class ConcreteProductA2 : IAbstractProductA
    {
        public string GetName()
        {
            return "Стол типа лофт";
        }
    }
    // Конкретный продукт типа стульев. В данном случае это 
    // будет стул типа "Модерн".
    public class ConcreteProductB1 : IAbstractProductB
    {
        public int Carrying { get; set; } = 100;

        public string GetName()
        {
            return "Стул типа модерн";
        }
    }
    // Конкретный продукт типа стульев. В данном случае это 
    // будет стул типа "Лофт".
    public class ConcreteProductB2 : IAbstractProductB
    {
        public int Carrying { get; set; } = 200;
        public string GetName()
        {
            return "Стул типа лофт";
        }
    }
    // Интерфейс абстрактной фабрики объявляет методы, которые
    // возвращают различные абстрактные продукты.
    // Эти продукты будут одним семейством, связаны какой-то общей 
    // концепцией высокого уровня. Семейство продуктов может иметь много вариация, 
    // но при этом, продукты одной из вариаций не будут совместимы с продуктами из
    // другой!
    public interface IAbstractFactory
    {
        public IAbstractProductA CreateProductA();
        public IAbstractProductB CreateProductB();
    }
    // Конкретная фабрика, реализует интерфейс абстрактной фабрики.
    // Таким образом, она создает семейство продуктов, связанных
    // концептуально на высоком уровне. *В данном случае, эта 
    // фабрика создаст семейство мебели(стол+стул) типа модерн*.
    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }
        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }
    // Конкретная фабрика, реализует интерфейс абстрактной фабрики.
    // Таким образом, она создает семейство продуктов, связанных
    // концептуально на высоком уровне. *В данном случае, эта 
    // фабрика создаст семейство мебели(стол+стул) типа лофт*.
    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

}
