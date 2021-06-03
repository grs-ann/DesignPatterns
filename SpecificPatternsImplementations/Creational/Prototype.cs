using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificPatternsImplementations.Creational
{
    /// <summary>
    /// Демонстрирует суть паттерна Прототип.
    /// Клиент имеет возможность копировать 
    /// состояние существующего объекта в новый.
    /// При этом состояние нового объекта не
    /// зависит от состояния старого и наоборот.
    /// </summary>
    public class Animal : ICloneable
    {
        public int age;
        public string name;
        public IdInformation idInfo;
        /// <summary>
        /// Поверхностное копирование объекта.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return (Animal)this.MemberwiseClone();
        }
        /// <summary>
        /// Глубокое клонирование объекта.
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public object DeepClone()
        {
            var cloned = (Animal)this.MemberwiseClone();
            cloned.idInfo = new IdInformation(idInfo.id);
            cloned.name = string.Copy(name);
            return cloned;
        }
    }
    /// <summary>
    /// Класс, используемый в качестве поля 
    /// в классе Animal.
    /// </summary>
    public class IdInformation
    {
        public int id;
        public IdInformation(int id)
        {
            this.id = id;
        }
    }
}
