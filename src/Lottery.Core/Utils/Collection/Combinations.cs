using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Utils
{
    public class Combinations<T> : IEnumerable<IList<T>>
    {
        private List<IList<T>> _combinations;
        private IList<T> _items;
        private int _length;
        private int[] _endIndices;

        public Combinations(IList<T> items)
            : this(items, items.Count)
        {
        }

        public Combinations(IList<T> items, int length)
        {
            this._items = items;
            this._length = length;
            this._combinations = new List<IList<T>>();
            this._endIndices = new int[length];
            int j = length - 1;
            for (int i = this._items.Count - 1; i > this._items.Count - 1 - length; i--)
            {
                this._endIndices[j] = i;
                j--;
            }
            ComputeCombination();
        }

        private void ComputeCombination()
        {
            int[] indices = new int[this._length];
            for (int i = 0; i < this._length; i++)
            {
                indices[i] = i;
            }

            do
            {
                T[] oneCom = new T[this._length];
                for (int k = 0; k < this._length; k++)
                {
                    oneCom[k] = this._items[indices[k]];
                }
                this._combinations.Add(oneCom);
            }
            while (GetNext(indices));
        }

        private bool GetNext(int[] indices)
        {
            bool hasMore = true;
            for (int j = this._endIndices.Length - 1; j > -1; j--)
            {
                if (indices[j] < this._endIndices[j])
                {
                    indices[j]++;
                    for (int k = 1; j + k < this._endIndices.Length; k++)
                    {
                        indices[j + k] = indices[j] + k;
                    }
                    break;
                }
                else if (j == 0)
                {
                    hasMore = false;
                }
            }
            return hasMore;
        }

        public int Count
        {
            get { return this._combinations.Count; }
        }

        public List<string> Get(string separator)
        {
            List<string> elements = new List<string>(this.Count);
            foreach (IList<T> list in this)
            {
                if (typeof(T).Name.Equals(typeof(int).Name))
                {
                    elements.Add(string.Join(separator,
                        list.Select(x => int.Parse(x.ToString()).ToString("D2")).ToArray()));
                }
                else
                {
                    elements.Add(string.Join(separator, list.Select(x => x.ToString()).ToArray()));
                }
            }
            return elements;
        }

        public IEnumerator<IList<T>> GetEnumerator()
        {
            return this._combinations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<IList<T>>)GetEnumerator();
        }

        public List<string> GetRepeat(string separator, string format)
        {
            return null;
        }
    }
}
