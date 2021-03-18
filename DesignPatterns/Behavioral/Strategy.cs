using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Strategy
{
    public class Context 
    {
        private IStrategy _strategy;
        public Context() { }
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

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
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

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
