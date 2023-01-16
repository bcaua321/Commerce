namespace Commerce.Application.Transfers.Responses
{
    public class UserLoginResponse : NotificationResponse
    {
        public UserLoginResponse(bool sucess) : base(sucess)
        {
        }

        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
