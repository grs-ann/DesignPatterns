using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    // Интерфейс строитела - в нём объявляются
    // методы для создания различных частей обьектов продуктов.
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }
    public class ConcreteBuilder : IBuilder
    {
        // Новый экземпляр строителя должен обязательно
        // содержать пустой обьект продукта, который будет 
        // использоваться в дальнейшей "сборке" продукта.
        public ConcreteBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new Product();
        }
        private Product _product = new Product();
        // Все этапы "строительства" объекта
        // обязательно должны работать с одним
        // экземпляром продукта.
        public void BuildPartA()
        {
            this._product.Add("Part A");
        }
        public void BuildPartB()
        {
            this._product.Add("Part B");
        }
        public void BuildPartC()
        {
            this._product.Add("Part C");
        }
        // Каждый конкретный строитель должен иметь собственный
        // метод для получения результата его работы.
        // Это связано с тем, что разные строители могут возвращать
        // продукты разных типов без общего интерфейса, поэтому 
        // такой метод нельзя сделать общим в интерфейсе строителей.
        public Product GetProduct()
        {
            Product result = this._product;
            // Имеет смысл сбрасывать состояние строителя
            // при получении результата его работы, чтобы
            // он сразу мог начать создавать другой объект.
            // Хотя на деле, это не обязательно, и это можно 
            // сделать и вручную из клиентского кода.
            this.Reset();
            return result;
        }
    }
    // Необязательный, но очень удобный класс "директора".
    // В нем определяются готовые вариации "построения" готовых обьектов.
    // Таким образом, клиенту нужно лишь предоставить директору строителя,
    // и вызвать метод для создания обьекта в той или иной комплектации.
    public class Director
    {
        public IBuilder Builder { get; set; }
        public void buildMinimalViableProduct()
        {
            this.Builder.BuildPartA();
        }
        public void buildFullFeaturedProduct()
        {
            this.Builder.BuildPartA();
            this.Builder.BuildPartB();
            this.Builder.BuildPartC();
        }
    }
    // В целом, использовать паттерн строитель имеет смысл
    // только в том случае, если продукты действительно
    // достаточно сложные - то есть имеют обширную конфигурацию.
    // Также стоит учитывать, что возвращаемые строителями 
    // продукты не обязаны следовать одному интерфейсу!**
    public class Product
    {
        private List<object> _parts = new List<object>();
        public void Add(string part)
        {
            this._parts.Add(part);
        }
        // Метод, нужный просто для наглядности работы строителя.
        public string ListParts()
        {
            string str = string.Empty;
            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }
            str = str.Remove(str.Length - 2);
            return string.Concat("Product parts: ", str, "\n");
        }
    }
}