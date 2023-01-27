using SequenceDataStructure.Models.Exceptions;
using SequenceDataStructure.Models;

namespace SequenceDataStructure.Helpers
{
    public static class SequentialListHelpers
    {
        /// <summary>
        /// Determines if the list is sequential (i,i+1,i+2,i+3)
        /// </summary>
        public static bool IsSequential(this SequentialList input)
        {

            //Edge case zero means invalid list.
            if (input.Count() <= 0) throw new InvalidSequentialListException();
            //Edge case one means it is sequential
            if (input.Count() == 1) return true;

            //see if items 2 to max are sequential
            for (int i = 1; i < input.Count(); i++)
            {
                if (input[i] - input[i - 1] != 1)
                    return false;
            }
            return true;
        }
    }
}
