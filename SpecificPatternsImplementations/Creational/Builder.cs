using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificPatternsImplementations.Creational
{
    /// <summary>
    /// Интерфейс для строителей. Определяет
    /// методы создания разных частей объекта.
    /// </summary>
    public interface IBuilder
    {
        void BuildRobotGun();
        void BuildRobotEnergyBlock();
        void BuildRobotSecurityModule();
    }
    /// <summary>
    /// Конкретный строитель. В данном случае собирает 
    /// робота по частям.
    /// </summary>
    public class Builder : IBuilder
    {
        Robot robot = new Robot();
        public Builder()
        {
            Reset();
        }
        public void BuildRobotEnergyBlock()
        {
            robot.AddRobotPart(new RobotEnergyBlock());
        }

        public void BuildRobotGun()
        {
            robot.AddRobotPart(new RobotGun());
        }

        public void BuildRobotSecurityModule()
        {
            robot.AddRobotPart(new RobotSecurityModule());
        }
        public void Reset()
        {
            robot = new Robot();
        }
        /// <summary>
        /// Метод для получения результата сборки робота.
        /// Также обновляет состояние текущего робота,
        /// предоставляя возможность сконструировать нового.
        /// </summary>
        /// <returns>Возвращает построенного робота.</returns>
        public Robot GetABuiltRobot()
        {
            var buildedRobot = robot;
            this.Reset();
            return buildedRobot;
        }
    }
    /// <summary>
    /// Вспомогательный класс, просто дополняет
    /// классы-наследники названием части робота.
    /// </summary>
    public abstract class RobotPartBaseInformation
    {
        string partName;
        public RobotPartBaseInformation(string name)
        {
            partName = name;
        }
        
    }
    /// <summary>
    /// Часть робота(пистолет).
    /// </summary>
    public class RobotGun : RobotPartBaseInformation
    {
        public RobotGun() : base("Пистолет")
        {
        }
    }
    /// <summary>
    /// Часть робота(энергетический блок).
    /// </summary>
    public class RobotEnergyBlock : RobotPartBaseInformation
    {
        public RobotEnergyBlock() : base("Энергетический блок")
        {
        }
    }
    /// <summary>
    /// Часть робота(защитный модуль).
    /// </summary>
    public class RobotSecurityModule : RobotPartBaseInformation
    {
        public RobotSecurityModule() : base("Защитный модуль")
        {
        }
    }
    /// <summary>
    /// Робот, который может состоять из различных
    /// компонентов.
    /// </summary>
    public class Robot
    {
        List<RobotPartBaseInformation> _robotParts = new List<RobotPartBaseInformation>();
        public void AddRobotPart(RobotPartBaseInformation part)
        {
            _robotParts.Add(part);
        }
        public void ShowRobotDetails()
        {
            Console.WriteLine("Данный робот представлен в следующей комплектации: ");
            for (int i = 0; i < _robotParts.Count; i++)
            {
                Console.WriteLine($"{i++}) {_robotParts[i]};");
            }
        }
    }
    /// <summary>
    /// Необязательный класс паттерна Строитель.
    /// Упрощает для клиента создание объектов(роботов)
    /// в разных комплектациях.
    /// </summary>
    public class Director
    {
        private IBuilder _builder;
        public Director(IBuilder builder)
        {
            _builder = builder;
        }
        public void BuildMinimallyFunctionalRobot()
        {
            _builder.BuildRobotEnergyBlock();
        }
        public void BuildMediumConfigurationRobot()
        {
            _builder.BuildRobotEnergyBlock();
            _builder.BuildRobotSecurityModule();
        }
        public void BuildBattleRobot()
        {
            _builder.BuildRobotEnergyBlock();
            _builder.BuildRobotSecurityModule();
            _builder.BuildRobotGun();
        }
    }
}
