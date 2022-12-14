namespace Commerce.Application.Exceptions
{
    public class CommerceValidationException : CommerceException
    {
        public CommerceValidationException(List<string> messages) : base(messages)
        {
        }
    }
}
