using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Utils
{
    public class Permutations<T> : IEnumerable<IList<T>>
    {
        private List<IList<T>> _permutations;
        private IList<T> _items;
        private int _length;
        private List<int[]> _indices;
        private int[] _value;
        private int _level = -1;

        public Permutations(IList<T> items)
            : this(items, items.Count)
        {
        }

        public Permutations(IList<T> items, int length)
        {
            this._items = items;
            this._length = length;
            this._permutations = new List<IList<T>>();
            this._indices = new List<int[]>();
            BuildIndices();
            foreach (IList<T> oneCom in new Combinations<T>(items, length))
            {
                this._permutations.AddRange(GetPermutations(oneCom));
            }
        }

        private void BuildIndices()
        {
            this._value = new int[this._length];
            Visit(0);
        }

        private void Visit(int k)
        {
            this._level += 1;
            this._value[k] = this._level;

            if (this._level == this._length)
            {
                this._indices.Add(this._value);
                int[] newValue = new int[this._length];
                Array.Copy(this._value, newValue, this._length);
                this._value = newValue;
            }
            else
            {
                for (int i = 0; i < this._length; i++)
                {
                    if (this._value[i] == 0)
                    {
                        Visit(i);
                    }
                }
            }

            this._level -= 1;
            this._value[k] = 0;
        }

        private IList<IList<T>> GetPermutations(IList<T> oneCom)
        {
            List<IList<T>> t = new List<IList<T>>();

            foreach (int[] idxs in this._indices)
            {
                T[] onePerm = new T[this._length];
                for (int i = 0; i < this._length; i++)
                {
                    onePerm[i] = oneCom[idxs[i] - 1];
                }
                t.Add(onePerm);
            }

            return t;
        }

        private int GetFactorial(int n)
        {
            int result = 1;
            while (n > 1)
            {
                result *= n;
                n--;
            }
            return result;
        }

        public IEnumerator<IList<T>> GetEnumerator()
        {
            return this._permutations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this._permutations.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return this._permutations.Count;
            }
        }

        public List<string> Get(string separator)
        {
            return this.Get(separator, "D2");
        }

        public List<string> Get(string separator,string format)
        {
            List<string> elements = new List<string>(this.Count);
            foreach (IList<T> list in this)
            {
                if (typeof(T).Name.Equals(typeof(int).Name))
                {
                    elements.Add(string.Join(separator,
                        list.Select(x => int.Parse(x.ToString()).ToString(format)).ToArray()));
                }
                else
                {
                    elements.Add(string.Join(separator, list.Select(x => x.ToString()).ToArray()));
                }
            }
            return elements;
        }

        public List<string> GetRepeat(string separator, string format)
        {
            return null;
        }
    }
}
