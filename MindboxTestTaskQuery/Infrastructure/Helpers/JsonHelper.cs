using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MindboxTestTaskQuery.Infrastructure.Helpers
{
    /// <summary>
    /// Класс-помощник для работы с Json
    /// </summary>
    public class JsonHelper
    {
        private readonly string _jsonFilePath;

        public JsonHelper(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public string GetInfoByKey(string key)
        {
            string result = "";

            using (StreamReader file = File.OpenText(_jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject data = (JObject)JToken.ReadFrom(reader);
                result = data[key].Value<string>();
            }

            return result;
        }
    }
}