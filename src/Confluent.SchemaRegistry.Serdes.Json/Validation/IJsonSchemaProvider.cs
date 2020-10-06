using System;

namespace Confluent.SchemaRegistry.Serdes
{
    /// <summary>
    /// Represents a JSON schema provider which resolves JSON schemas.
    /// </summary>
    public interface IJsonSchemaProvider
    {
        /// <summary>
        /// Gets the schema for specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The contract type to get the schema for.</param>
        /// <returns>A <see cref="JsonSchema"/> for specified type or <see langword="null"/> if no schema could be resolved.</returns>
        JsonSchema GetSchema(Type type);
    }
}
