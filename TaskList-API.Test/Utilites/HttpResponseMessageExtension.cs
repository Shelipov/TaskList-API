using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace TaskList_API.Test.Utilites
{
    static class HttpResponseMessageExtension
    {
        public static async Task<T> BodyAs<T>(this HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(body,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters =
                            {
                                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                            }
                        });
        }
    }
}
