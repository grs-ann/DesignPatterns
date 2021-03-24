using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Adapter
{
    // Целевой класс объявляет интерфейс, с которым 
    // может работать клиентский код.
    public interface ITarget
    {
        string GetRequest();
    }
    // Адаптируемый класс содержит некую полезную
    // функциональность, но его интерфейс несовместим
    // с существующим клиентским кодом. Адаптируемый класс
    // нуждается в некоторой доработке, прежде чем
    // клиентский код сможет работать с ним.
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }
    // Адаптер делает интерфейс адаптируемого класса
    // совместимым с целевым интерфейсом.
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }
        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}
