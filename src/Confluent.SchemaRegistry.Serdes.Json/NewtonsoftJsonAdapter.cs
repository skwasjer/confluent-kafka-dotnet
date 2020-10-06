using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Confluent.SchemaRegistry.Serdes
{
    public class NewtonsoftJsonAdapter : IJsonSerializerAdapter
    {
        public NewtonsoftJsonAdapter(JsonSerializerSettings serializerSettings = null)
        {
            SerializerSettings = serializerSettings;
        }

        /// <summary>
        /// Gets the JSON serializer settings.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; }

        /// <inheritdoc />
        public Task<string> SerializeAsync(object value)
        {
            return Task.FromResult(JsonConvert.SerializeObject(value, SerializerSettings));
        }

        /// <inheritdoc />
        public Task<object> DeserializeAsync(string jsonData, Type destinationType)
        {
            return Task.FromResult(JsonConvert.DeserializeObject(jsonData, destinationType, SerializerSettings));
        }
    }
}
