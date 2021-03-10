using DesignPatterns.AbstractFacrory;
using DesignPatterns.Builder;
using DesignPatterns_FabricMethod;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder_Test();
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
        private static void Builder_Test()
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;
            Console.WriteLine("Базовая - минимальная комплектация продукта(состоит из части А): ");
            director.buildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Полная комплектация продукта(состоит из частей А, B, C): ");
            director.buildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());
        }
    }
}
