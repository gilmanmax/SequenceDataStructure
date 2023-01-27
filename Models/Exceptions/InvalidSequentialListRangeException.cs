using System;

namespace SequenceDataStructure.Models.Exceptions
{
    public class InvalidSequentialListRangeException : Exception
    {
        public override string Message => "The minimum value must be less than or equal to the maximum value.";
    }
}
