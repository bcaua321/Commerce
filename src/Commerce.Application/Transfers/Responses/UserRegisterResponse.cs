﻿namespace Commerce.Application.Transfers.Responses
{
    public class UserRegisterResponse : NotificationResponse
    {
        public UserRegisterResponse(bool sucess) : base(sucess)
        {
        }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
