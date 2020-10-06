using System.Collections.Generic;

namespace Confluent.SchemaRegistry.Serdes
{
    /// <summary>
    /// Abstract class to allow for different implementations of JSON schema provider. (See <see cref="IJsonSchemaProvider"/>)
    /// </summary>
    public abstract class JsonSchema : Schema
    {
        public JsonSchema(string schemaString, string fullName)
            : base(schemaString, SchemaType.Json)
        {
            FullName = fullName;
        }

        /// <summary>
        /// Gets the subject name. This is only provided for backwards compatibility.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Validates JSON specified in <paramref name="jsonData"/> against this JSON schema.
        /// </summary>
        /// <param name="jsonData">The JSON data to validate.</param>
        /// <returns>A collection of schema validation errors. When the collection is empty, validation succeeded.</returns>
        public abstract ICollection<SchemaValidationError> Validate(string jsonData);
    }
}
