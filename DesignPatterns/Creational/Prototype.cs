using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Prototype
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
        // Как можно заметить, поле IdInfo является ссылкой на класс IdInfo,
        // то есть стандартный метод MemberwiseClone() не поможет скопировать значение 
        // этого поля в новый объект-клон Person. Поэтому в таких случаях, 
        // мы копируем значения полей вручную.
        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = string.Copy(Name);
            return clone;
        }
    }
    public class IdInfo
    {
        public int IdNumber;
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
}
