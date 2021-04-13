using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ChainOfResponsibilities
{
    // Интерфейс обработчика объявляет метод построения цепочки обработчиков.
    // Он также объявляет метод для выполнения запроса.
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object requect);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            // Возврат обработчика отсюда позволит связать 
            // обработчики простым способом, вот так:
            // monkey.SetNext(squirrel).SetNext(dog)
            return handler;
        }
        public virtual object Handle(object requect)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(requect);
            }
            return null;
        }
    }
    public class MonkeyHandler : AbstractHandler
    {
        public override object Handle(object requect)
        {
            if ((requect as string) == "Banana")
            {
                return $"Monkey: I'll eat the {requect.ToString()}";
            }
            return base.Handle(requect);
        }
    }
    public class SquirrelHandler : AbstractHandler
    {
        public override object Handle(object requect)
        {
            if (requect.ToString() == "Nut")
            {
                return $"Squirrel: I'll eat the {requect.ToString()}";
            }
            return base.Handle(requect);
        }
    }
    public class DogHandler : AbstractHandler
    {
        public override object Handle(object requect)
        {
            if (requect.ToString() == "MeatBall")
            {
                return $"Dog: I'll eat the {requect.ToString()}";
            }
            return base.Handle(requect);
        }
    }
    public class Client
    {
        // Обычно клиентский код приспособлен для работы с единственным обрабочиком.
        // В большинстве случаев клиенту даже неизвестно, что этот 
        // обработчик является частью цепочки.
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);
                if (result != null)
                {
                    Console.WriteLine($" {result}");
                }
                Console.WriteLine($"   {food} was left untouched.");
            }
        }
    }

}
