namespace Commerce.Application.Exceptions
{
    public class CommerceException : Exception
    {
        public List<string> Messages { get; set; }
        public CommerceException(List<string> messages)
        {
            Messages = messages;
        }

        public CommerceException(string message)
        {
            Messages = new List<string>
            {
                message
            };
        }
    }
}
