using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace ResiliencePatterns
{
    public class FallbackDefaultResponse
    {
        private FallbackDefaultResponse()
        {
        }

        public StringContent DefaultFallbackResponse { get; private set; }

        private static FallbackDefaultResponse _instance;
        private static readonly object _lock = new object();

        public static FallbackDefaultResponse GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new FallbackDefaultResponse();
                    _instance.DefaultFallbackResponse =
                        new StringContent(JsonSerializer.Serialize(new ResponseModel("Deu bom", true)));

                }
            }
            return _instance;
        }
    }
}