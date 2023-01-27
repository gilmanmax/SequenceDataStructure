namespace SequenceDataStructure.Models.Exceptions
{
    public class NotSequentialException:Exception
    {
        public override string Message
        {
            get
            {
                return "The input provided was not sequential.";
            }
        }
    }
}
