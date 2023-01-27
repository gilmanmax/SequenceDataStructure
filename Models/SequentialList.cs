using System.Collections;
using SequenceDataStructure.Models.Exceptions;
using Newtonsoft.Json;
namespace SequenceDataStructure.Models
{
    /// <summary>
    /// A list containing a sequence of numbers from X to Y, all inclusive.
    /// </summary>
    
    public class SequentialList: IList<int>
    {
        int[] _items;
        public SequentialList(int min, int max) 
        {
            /// Min Cannot be > max
            if (min > max)
            {
                throw new InvalidSequentialListRangeException();
            }
            _items = GenerateSequentialListArr(min, max);
        }
        public SequentialList(SequentialListJSONInput input)
        {
            _items = input.items;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">index of element</param>
        /// <returns></returns>
        public int this[int i]
        {
            get
            {
                return _items[i];
            }
        }



        /// <summary>
        /// Generates the sequential list without using .ToList()
        /// </summary>
        /// <param name="min">Min value (inclusive)</param>
        /// <param name="max">Max value (inclusive</param>
        /// <returns>A list </returns>
        private static int[] GenerateSequentialListArr(int min, int max)
        {
            int[] arr = new int[max-min+1];
            int val = min;
            //populate the list
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = val;
                val++;
            }
            return arr;
        }
        int IList<int>.this[int index] { get => ((IList<int>)_items)[index]; set => ((IList<int>)_items)[index] = value; }

        public int Count => ((ICollection<int>)_items).Count;

        public bool IsReadOnly => ((ICollection<int>)_items).IsReadOnly;
        public void Add(int item)
        {
            ((ICollection<int>)_items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<int>)_items).Clear();
        }

        public bool Contains(int item)
        {
            return ((ICollection<int>)_items).Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            ((ICollection<int>)_items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)_items).GetEnumerator();
        }

        public int IndexOf(int item)
        {
            return ((IList<int>)_items).IndexOf(item);
        }

        public void Insert(int index, int item)
        {
            ((IList<int>)_items).Insert(index, item);
        }

        public bool Remove(int item)
        {
            return ((ICollection<int>)_items).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<int>)_items).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
