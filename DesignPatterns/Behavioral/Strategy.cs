using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    // Контекст определяет интерфейс, представляющий интерес для клиентов.
    public class Context 
    {
        // Контекст должен хранить ссылку на один из объектов Стратегии.
        // Контекст не в курсе, какой это конкретный класс стратегии,
        // он работает с ними через специальный интерфейс.
        private IStrategy _strategy;
        public Context() { }
        // Чаще всего, объект стратегии передается контексту
        // через конструктор.
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        // В то же время, контекст позволяет заменить
        // стратегию на другую прямо во время работы
        // приложения, что бывает очень удобно.
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        // Вместо того, чтобы самостоятельно реализовывать различные версии
        // похожих алгоритмов, контекст делегирует эту работу "Стратегии".
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: sorting data using the strategy(not sure how it'll do it");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });
            var resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ", ";
            }
            Console.WriteLine(resultStr);
        }
    }
    // Интерфейс стратегии объявляет операции, 
    // общие для всех поддерживаемых версий
    // некоторого алгоритма.
    // Этот интерфейс и использует контекст.
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }
    // Конкретные стратегии реализуют алгоритм,
    // следуя базовому интерфейсу. Поэтому выходит, что
    // конкретные стратегии становятся взаимозаменямыми 
    // в контексте.
    public class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            return list;
        }
    }
    public class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();
            return list;
        }
    }
}
