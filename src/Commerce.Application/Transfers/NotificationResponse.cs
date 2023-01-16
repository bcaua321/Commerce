using System.Text.Json.Serialization;

namespace Commerce.Application.Transfers
{
    public class NotificationResponse 
    {
        public bool Sucess { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Errors { get; set; }

        public NotificationResponse(bool sucess)
        {
            Sucess = sucess;
        }

        public void AddError(string errorMessage)
        {
            if(Errors == null) Errors = new List<string>();

            Errors.Add(errorMessage);
        }

        public void AddRangeErrors(List<string> errorMessage)
        {
            if (Errors == null) Errors = new List<string>();

            Errors.AddRange(errorMessage);
        }
    }
}
