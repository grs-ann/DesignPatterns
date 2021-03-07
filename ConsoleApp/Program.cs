using DesignPatterns_FabricMethod;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FabricMethod_Test(new ConcreteCreatorA());
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
    }
}
