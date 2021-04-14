using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Iterator
{
    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();
        // Возвращает ключ текущего объекта.
        public abstract int Key();
        // Возвращает текущий элемент.
        public abstract object Current();
        // Переходит к следующему элементу.
        public abstract bool MoveNext();
        // Перематывает Итератор к первому элементу.
        public abstract void Reset();
    }
    public abstract class IteratorAggregate : IEnumerable
    {
        // Возвращает Iterator или другой IteratorAggregate для 
        // реализующего объекта.
        public abstract IEnumerator GetEnumerator();
    }
    public class AlphabeticalOrderIterator : Iterator
    {
        private WordsCollection _collection;
        // Хранит текущее положение обхода. У итератора может быть множество
        // других полей для хранения состояния итерации, особенно когда он
        // должен работать с определённым типом коллекции.
        private int _position = -1;

        private bool _reverse = false;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
        {
            this._collection = collection;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = collection.GetItems().Count;
            }
        }
        public override object Current()
        {
            return this._collection.GetItems()[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = this._reverse ? this._collection.getItems().Count - 1 : 0;
        }
    }
    public class WordsCollection : IteratorAggregate
    {
        List<string> _collection = new List<string>();
        bool _direction = false;
        public void ReverseDirection()
        {
            _direction = !_direction;
        }
        public List<string> GetItems()
        {
            return _collection;
        }
        public void AddItem(string item)
        {
            this._collection.Add(item);
        }
        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _direction);
        }
    }
}
