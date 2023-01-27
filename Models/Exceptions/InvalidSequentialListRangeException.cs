using System;

namespace SequenceDataStructure.Model.Exceptions
{
    public class InvalidSequentialListRangeException : Exception
    {
        public override string Message => "The minimum value must be less than or equal to the maximum value.";
    }
}
