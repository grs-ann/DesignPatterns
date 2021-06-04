using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificPatternsImplementations.Creational
{
    /// <summary>
    /// Класс, являющийся объектом тяжёлой базы данных.
    /// Есть необходимость обращаться к одному и тому же
    /// экземпляру с целью повышения прозводительности.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Скрываем конструктор объекта
        /// от внешнего воздействия.
        /// </summary>
        private Database() { }
        /// <summary>
        /// Данное поле хранит в себе значение объекта.
        /// </summary>
        static Database _data = null;

        /// <summary>
        /// Вспомогательный объект для обеспечения потокобезопасности.
        /// </summary>
        static readonly object _locker = new object();
        /// <summary>
        /// Метод для получения единственного экземпляра
        /// </summary>
        /// <returns></returns>
        public static Database OpenDatabaseInstance()
        {
            if (_data == null)
            {
                // В случае многопоточности, остальные потоки должны дождаться
                // выполнения первого, иначе может произойти перезапись экземпляра.
                lock (_locker)
                {
                    // В защищенном поток проверяем, был ли уже создан
                    // экземпляр. Если нет, то создаем.
                    _data ??= new Database();
                }
            }
            return _data;
        }
    }
}
