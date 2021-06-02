using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificPatternsImplementations.Creational
{
    /// <summary>
    /// Вспомогательный класс для клиентскогго кода.
    /// Демонстрирует удобство создания семейства
    /// связанных объектов.
    /// </summary>
    public class Client
    {
        public void ClientMethod(IAbstractFactory factory)
        {
            var hat = factory.CreateHat();
            var torso = factory.CreateTorso();
            var pants = factory.CreatePants();
            Console.WriteLine($"Getting hat information: {hat.GetHeadSize()}");
            Console.WriteLine($"Getting torso information: {torso.GetTorsoHeight()}, {torso.GetTorsoWidth()}");
            Console.WriteLine($"Getting pants information: {pants.GetLegsLength()}, {pants.GetLegsWidth()}");
        }
    }
    /// <summary>
    /// Интерфейс абстрактной фабрики определяет 
    /// набор методов по созданию компонентов
    /// семейства.
    /// </summary>
    public interface IAbstractFactory
    {
        IHeadClothes CreateHat();
        ITorsoClothes CreateTorso();
        ILegsClothes CreatePants();
    }
    /// <summary>
    /// Конкретная реализация фабрики по созданию 
    /// семейства одежды марки "OscarDeLaRenta".
    /// </summary>
    public class OscarDeLaRentaFactory : IAbstractFactory
    {
        public IHeadClothes CreateHat()
        {
            return new OscarDeLaRentaHat(15);
        }

        public ILegsClothes CreatePants()
        {
            return new OscarDeLaRentaPants(60, 20);
        }

        public ITorsoClothes CreateTorso()
        {
            return new OscarDeLaRentaTorso(50, 30);
        }
    }
    /// <summary>
    /// Конкретная реализация фабрики по созданию 
    /// семейства одежды марки "MAXIMALONOV".
    /// </summary>
    public class MAXIMALONOVFactory : IAbstractFactory
    {
        public IHeadClothes CreateHat()
        {
            return new MaximAlonovBrendHat(15);
        }

        public ILegsClothes CreatePants()
        {
            return new MaximAlonovBrendPants(60, 20);
        }

        public ITorsoClothes CreateTorso()
        {
            return new MaximAlonovBrendTorso(50, 30);
        }
    }
    /// <summary>
    /// Конкретная реализация фабрики по созданию 
    /// семейства одежды марки "Ostin".
    /// </summary>
    public class OstinFactory : IAbstractFactory
    {
        public IHeadClothes CreateHat()
        {
            return new OstinHat(15);
        }

        public ILegsClothes CreatePants()
        {
            return new OstinPants(60, 20);
        }

        public ITorsoClothes CreateTorso()
        {
            return new OstinTorso(50, 30);
        }
    }
    /// <summary>
    /// Вспомогательный класс для одежды,
    /// хранит в себе общие свойства одежды
    /// (цену, название).
    /// </summary>
    public class BaseClothesClass
    {
        private double _price { get; set; }
        private string _productName { get; set; }
        public BaseClothesClass(double price, string productName)
        {
            _price = price;
            _productName = productName;
        }
        public double GetPrice()
        {
            return _price;
        }

        public string GetProductName()
        {
            return _productName;
        }
    }
    /// <summary>
    /// Данный интерфейс определяет набор свойств 
    /// и методов для всех видов головных уборов.
    /// </summary>
    public interface IHeadClothes
    {
        int GetHeadSize();
        int HeadSize { get; set; }
    }
    /// <summary>
    /// Конкретный продукт головных уборов.
    /// Марка - "OscarDeLaRenta".
    /// </summary>
    public class OscarDeLaRentaHat : BaseClothesClass, IHeadClothes
    {
        public int HeadSize { get; set; }
        public OscarDeLaRentaHat(int headSize) : base(70000.00, "OSCAR DE LA RENTA HAT")
        {
            HeadSize = headSize;
        }
        public int GetHeadSize()
        {
            return HeadSize;
        }
    }
    /// <summary>
    /// Конкретный продукт головных уборов.
    /// Марка - "MaximAlonovBrend".
    /// </summary>
    public class MaximAlonovBrendHat : BaseClothesClass, IHeadClothes
    {
        public int HeadSize { get; set; }
        public MaximAlonovBrendHat(int headSize) : base(25000, "MAXIMALONOV HAT")
        {
            HeadSize = headSize;
        }
        public int GetHeadSize()
        {
            return HeadSize;
        }
    }
    /// <summary>
    /// Конкретный продукт головных уборов.
    /// Марка - "Ostin".
    /// </summary>
    public class OstinHat : BaseClothesClass, IHeadClothes
    {
        public int HeadSize { get; set; }
        public OstinHat(int headSize) : base(1500, "Ostin HAT")
        {
            HeadSize = headSize;
        }
        public int GetHeadSize()
        {
            return HeadSize;
        }
    }
    /// <summary>
    /// Данный интерфейс определяет набор свойств 
    /// и методов для всех видов верхней одежды.
    /// </summary>
    public interface ITorsoClothes
    {
        int TorsoWidth { get; set; }
        int TorsoHeight{ get; set; }
        int GetTorsoWidth();
        int GetTorsoHeight();
    }
    /// <summary>
    /// Конкретный продукт верхней одежды.
    /// Марка - "OscarDeLaRenta".
    /// </summary>
    public class OscarDeLaRentaTorso : BaseClothesClass, ITorsoClothes
    {
        public int TorsoWidth { get; set; }
        public int TorsoHeight { get; set; }
        public OscarDeLaRentaTorso(int width, int height) : base(120000, "OSCAR DE LA RENTA TORSO")
        {
            TorsoWidth = width;
            TorsoHeight = height;
        }
        public int GetTorsoHeight()
        {
            return TorsoHeight;
        }
        public int GetTorsoWidth()
        {
            return TorsoHeight;
        }
    }
    /// <summary>
    /// Конкретный продукт верхней одежды.
    /// Марка - "MaximAlonovBrend".
    /// </summary>
    public class MaximAlonovBrendTorso : BaseClothesClass, ITorsoClothes
    {
        public int TorsoWidth { get; set; }
        public int TorsoHeight { get; set; }
        public MaximAlonovBrendTorso(int width, int height) : base(65000, "MAXIMALONOV TORSO")
        {
            TorsoWidth = width;
            TorsoHeight = height;
        }
        public int GetTorsoHeight()
        {
            return TorsoHeight;
        }
        public int GetTorsoWidth()
        {
            return TorsoHeight;
        }
    }
    /// <summary>
    /// Конкретный продукт верхней одежды.
    /// Марка - "Ostin".
    /// </summary>
    public class OstinTorso : BaseClothesClass, ITorsoClothes
    {
        public int TorsoWidth { get; set; }
        public int TorsoHeight { get; set; }
        public OstinTorso(int width, int height) : base(3400, "Ostin TORSO")
        {
            TorsoWidth = width;
            TorsoHeight = height;
        }
        public int GetTorsoHeight()
        {
            return TorsoHeight;
        }
        public int GetTorsoWidth()
        {
            return TorsoHeight;
        }
    }
    /// <summary>
    /// Данный интерфейс определяет набор свойств 
    /// и методов для всех видов штанов.
    /// </summary>
    public interface ILegsClothes 
    {
        int LegsWidth { get; set; }
        int LegsHeight { get; set; }
        int GetLegsWidth();
        int GetLegsLength();
    }
    /// <summary>
    /// Конкретный продукт штанов.
    /// Марка - "OscarDeLaRenta".
    /// </summary>
    public class OscarDeLaRentaPants : BaseClothesClass, ILegsClothes
    {
        public int LegsWidth { get; set; }
        public int LegsHeight { get; set; }
        public OscarDeLaRentaPants(int length, int width) : base(110000, "OSCAR DE LA RENTA PANTS")
        {
            LegsHeight = length;
            LegsHeight = width;
        }
        public int GetLegsLength()
        {
            return LegsWidth;
        }
        public int GetLegsWidth()
        {
            return LegsHeight;
        }
    }
    /// <summary>
    /// Конкретный продукт штанов.
    /// Марка - "MaximAlonovBrend".
    /// </summary>
    public class MaximAlonovBrendPants : BaseClothesClass, ILegsClothes
    {
        public int LegsWidth { get; set; }
        public int LegsHeight { get; set; }
        public MaximAlonovBrendPants(int length, int width) : base(50000, "MAXIMALONOV PANTS")
        {
            LegsHeight = length;
            LegsHeight = width;
        }
        public int GetLegsLength()
        {
            return LegsWidth;
        }
        public int GetLegsWidth()
        {
            return LegsHeight;
        }
    }
    /// <summary>
    /// Конкретный продукт штанов.
    /// Марка - "Ostin".
    /// </summary>
    public class OstinPants : BaseClothesClass, ILegsClothes
    {
        public int LegsWidth { get; set; }
        public int LegsHeight { get; set; }
        public OstinPants(int length, int width) : base(3000, "Ostin PANTS")
        {
            LegsHeight = length;
            LegsHeight = width;
        }
        public int GetLegsLength()
        {
            return LegsWidth;
        }
        public int GetLegsWidth()
        {
            return LegsHeight;
        }
    }
}
