using DesignPatterns.AbstractFacrory;
using DesignPatterns.Builder;
using DesignPatterns.Prototype;
using DesignPatterns_FabricMethod;
using DesignPatterns.Strategy;
using System;
using DesignPatterns.Adapter;
using DesignPatterns.Decorator;
using DesignPatterns.ChainOfResponsibilities;
using DesignPatterns.Command;
using DesignPatterns.Iterator;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandTest();
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
        private static void Prototype_Test()
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            // Выполнить поверхностное копирование p1 и присвоить её p2.
            Person p2 = p1.ShallowCopy();
            // Сделать глубокую копию p1 и присвоить её p3.
            Person p3 = p1.DeepCopy();

            // Вывести значения p1, p2 и p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Изменить значение свойств p1 и отобразить значения p1, p2 и p3.
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }
        private static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
        private static void Strategy_Test()
        {
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();
            Console.WriteLine();
            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
        private static void Adapter_Test()
        {
            var adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");
            Console.WriteLine(target.GetRequest());
        }
        private static void Decorator_Test()
        {
            var client = new DesignPatterns.Decorator.Client();
            Console.WriteLine("Client: I get a simple component: ");
            var simple = new ConcreteComponent();
            client.ClientCode(simple);

            // Причём можно "оборачивать" другие декораторы!
            var decoratorA = new ConcreteDecoratorA(simple);
            var decoratorB = new ConcreteDecoratorB(decoratorA);
            Console.WriteLine("Client: Now I've got a decorated component: ");
            client.ClientCode(decoratorB);
        }
        private static void ChainOfResponcibilityTest()
        {
            // Где то в клиентском коде происходит создание цепочки.
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            Console.WriteLine("Chain: Monkey -> Squirrel -> Dog");
            DesignPatterns.ChainOfResponsibilities.Client.ClientCode(monkey);

            Console.WriteLine("SubChain: Squirrel -> Dog");
            DesignPatterns.ChainOfResponsibilities.Client.ClientCode(squirrel);
        }
        private static void CommandTest()
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("SayHi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));
            invoker.DoSomethingImportant();
        }
        private static void IteratorTest()
        {
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");
            Console.WriteLine("Straight traversal: ");
            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("\nReverse traversal:");
            collection.ReverseDirection();
            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }
    }
}
