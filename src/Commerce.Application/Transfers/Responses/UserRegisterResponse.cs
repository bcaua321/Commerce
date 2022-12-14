namespace Commerce.Application.Transfers.Responses
{
    public class UserRegisterResponse
    {
        public bool Sucess { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
