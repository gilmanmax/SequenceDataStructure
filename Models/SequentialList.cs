using System.Collections;
using SequenceDataStructure.Model.Exceptions;
namespace SequenceDataStructure.Models
{
    /// <summary>
    /// A list containing a sequence of numbers from X to Y, all inclusive.
    /// </summary>
    public class SequentialList : IEnumerable<int>
    {
        IEnumerable<int> _items;
        public SequentialList(int min, int max) 
        {
            _items = new List<int>();
            /// Min Cannot be > max
            if (min > max)
            {
                throw new InvalidSequentialListRangeException();
            }
            _items = GenerateSequentialList(min, max);
            
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
                return _items.ElementAt(i);
            }
        }

        /// <summary>
        /// Generates the sequential list without using .ToList()
        /// </summary>
        /// <param name="min">Min value (inclusive)</param>
        /// <param name="max">Max value (inclusive</param>
        /// <returns>A list </returns>
        private static IEnumerable<int> GenerateSequentialList(int min, int max)
        {
            //populate the list
            for (int i = min; i <= max; i++)
            {
                yield return i;
            }
        }


        public IEnumerator<int> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    }
}
