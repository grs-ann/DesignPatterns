using DesignPatterns.AbstractFacrory;
using DesignPatterns_FabricMethod;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFacrory_Test(new ConcreteFactory1());
            Console.WriteLine("************");
            Console.WriteLine("Работа паттерна окончена.");
            Console.ReadLine();
        }
        private static void FabricMethod_Test(Creator creator)
        {
            Console.WriteLine("Приветствую! Я создатель.\n" +
                "Я без проблем могу создать обьект и предостовляю\n," +
                "а также могу использовать этот объект в какой-нибудь бизнес-логике!");
            Console.WriteLine($"Например, {creator.SomeOperation()}");
        }
        private static void AbstractFacrory_Test(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();
            // Специфическое свойство только для типа стульев!
            Console.WriteLine("Абстрактная фабрика создала семейство \n " +
                "концептуально связанных типов.");
            Console.WriteLine("Это созданный стул: ");
            Console.WriteLine(productB.GetName());
            Console.WriteLine(productB.Carrying);
            Console.WriteLine("А так же стол: ");
            Console.WriteLine(productA.GetName());
        }
    }
}
