using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    /// <summary>
    /// Главная задача одиночки - сделать так, чтобы в программе
    /// был один единственный экземпляр класса, доступный 
    /// всем клиентам.
    /// </summary>
    public class Singleton
    {
        // Закрываем конструктор от внешнего воздействия.
        private Singleton() { }
        private static Singleton _instance;

        // Объект-блокировка для синхронизации поток во время первого
        // доступа к одиночке.
        private static readonly object _lock = new object();

        private static Singleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }
}
