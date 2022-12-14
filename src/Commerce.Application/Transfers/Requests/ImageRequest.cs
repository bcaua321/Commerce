namespace Commerce.Application.Transfers.Requests
{
    public class ImageRequest
    {
        public ImageRequest(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
