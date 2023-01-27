namespace SequenceDataStructure.Models.Exceptions
{
    public class ValueNotInListException : Exception
    {
        public override string Message
        {
            get
            {
                return "The value provided is not in the list.";
            }
        }
    }
}
