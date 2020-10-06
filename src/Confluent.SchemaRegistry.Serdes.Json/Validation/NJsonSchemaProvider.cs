using System;
using NJsonSchema.Generation;
using NJsonSchema.Validation;

namespace Confluent.SchemaRegistry.Serdes
{
    /// <summary>
    /// Represents a JSON schema provider based on <see cref="NJsonSchema.JsonSchema"/>.
    /// </summary>
    public class NJsonSchemaProvider : IJsonSchemaProvider
    {
        private readonly JsonSchemaGeneratorSettings jsonSchemaGeneratorSettings;
        private readonly JsonSchemaValidator validator = new JsonSchemaValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="NJsonSchemaProvider"/> class using specified optional <paramref name="jsonSchemaGeneratorSettings"/>.
        /// </summary>
        /// <param name="jsonSchemaGeneratorSettings">The settings to use when resolving JSON schemas.</param>
        public NJsonSchemaProvider(JsonSchemaGeneratorSettings jsonSchemaGeneratorSettings = null)
        {
            this.jsonSchemaGeneratorSettings = jsonSchemaGeneratorSettings;
        }

        /// <inheritdoc />
        public JsonSchema GetSchema(Type type)
        {
            NJsonSchema.JsonSchema jsonSchema = this.jsonSchemaGeneratorSettings == null
                ? NJsonSchema.JsonSchema.FromType(type)
                : NJsonSchema.JsonSchema.FromType(type, this.jsonSchemaGeneratorSettings);

            return new NJsonSchemaImpl(jsonSchema, validator);
        }
    }
}
