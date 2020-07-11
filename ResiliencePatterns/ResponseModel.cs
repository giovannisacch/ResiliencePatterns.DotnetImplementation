namespace ResiliencePatterns
{
    public class ResponseModel
    {
        public ResponseModel(){ }

        public ResponseModel(string message, bool fallback)
        {
            Message = message;
            Fallback = fallback;
        }
        public string Message { get; set; }
        public bool Fallback { get; set; }
    }
}