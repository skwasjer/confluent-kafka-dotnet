using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Confluent.SchemaRegistry.Serdes
{
    public interface IJsonSerializerAdapter
    {
        Task<string> SerializeAsync(object value);

        Task<object> DeserializeAsync(string jsonData, Type destinationType);
    }
}
