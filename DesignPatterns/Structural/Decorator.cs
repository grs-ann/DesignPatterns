using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    // Базовый интерфейс Компонента определяет поведение,
    // которое будет изменяться декораторами.
    public abstract class Component
    {
        public abstract string Operation();
    }
    // Конкретные компоненты предоставляют реализации
    // поведения по умолчанию. Может быть несколько
    // вариаций этих классов.
    public class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }
    // Базовый класс декоратора следует тому же
    // интерфейсу, что и другие компоненты.
    // Главная цель этого класса - определить 
    // интерфейс обёртки для всех конкретных декораторов.
    // Реализация кода обёртки по умолчанию может
    // включать в себя поле для хранения завёрнутого 
    // компонента и средства его инициализации.
    public class Decorator : Component
    {
        protected Component _component;
        public Decorator(Component component)
        {
            this._component = component;
        }
        public void SetComponent(Component component)
        {
            this._component = component;
        }
        // Декоратор делегирует всю работу обёрнутому компоненту.
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }
    // Конкретные декораторы вызывают обёрнутый
    // объект и изменяют его результат
    // некоторым образом.
    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component component) : base(component)
        {
        }
        // Декораторы могут вызывать родительскую реализацию операции, 
        // вместо того, чтобы вызывать обёрнутый объект напрямую.
        // Такой подход упрощает расширение классов декораторов.
        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }
    // Декораторы могут выполнять своё поведение до или после
    // вызова обёрнутого объекта.
    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component component) : base(component)
        {
        }
        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }
    public class Client
    {
        // Клиентский код работает со всеми объектами, используя интерфейс
        // Компонента. Таким образом, он остаётся независимым от конкретных
        // классов компонентов, с которыми работает.
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }
}
