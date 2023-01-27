using System;

namespace SequenceDataStructure.Models.Exceptions
{
    public class InvalidSequentialListException : Exception
    {
        public override string Message => "Invalid Sequential List Provided.";
    }
}
