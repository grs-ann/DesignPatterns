using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Command
{
    // Интерфейс команды объявляет метод для выполнения команд.
    public interface ICommand
    {
        void Execute();
    }
    // Некоторые команды способны выполнять простые операции самостоятельно.
    public class SimpleCommand : ICommand
    {
        private string _payload = string.Empty;
        public SimpleCommand(string payload)
        {
            this._payload = payload;
        }
        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I Can do simple things like printing ({this._payload})");
        }
    }
    // Но есть и команды, которые делегируют более сложные 
    // операции другим объектам, называемым "получатели".
    public class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        // Данные о контексе, необходимые для запуска методов получателя.
        private string _a;
        private string _b;
        // Сложные команды могут принимать один или несколько
        // объектов-получателей вместе с любыми данными о контексте
        // через конструктор.
        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }
        // Команды могут делегировать выполнение любым методам получателя.
        public void Execute()
        {
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }
    // Классы получателей содержат некую важную бизнес-логику.
    // Они умеют выполнять все виды операций, связанных с
    // выполнением запроса. Фактически, любой класс может 
    // выступать в роли Получателя.
    public class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }
        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }
    // Отправитель связан с одной или несколькими командами.
    // Он отправляет запрос команде.
    public class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;
        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }
        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }
        public void DoSomethingImportant()
        {
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }
            Console.WriteLine("Invoker: ...doing something really important...");

            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }
    
}
