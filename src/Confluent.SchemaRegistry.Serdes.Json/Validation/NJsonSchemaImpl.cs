using System;
using System.Collections.Generic;
using System.Linq;
using NJsonSchema.Validation;

namespace Confluent.SchemaRegistry.Serdes
{
    // Named as such to avoid namespace conflict with top level ns NJsonSchema.
    internal class NJsonSchemaImpl : JsonSchema
    {
        private readonly NJsonSchema.JsonSchema schema;
        private readonly JsonSchemaValidator validator;

        public NJsonSchemaImpl(NJsonSchema.JsonSchema schema, JsonSchemaValidator validator)
            : base(schema?.ToJson(), schema?.Title)
        {
            this.schema = schema ?? throw new ArgumentNullException(nameof(schema));
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <inheritdoc />
        public override ICollection<SchemaValidationError> Validate(string jsonData)
        {
            return this.validator
                .Validate(jsonData, this.schema)
                .Select(e => new SchemaValidationError(e.Property, e.Path))
                .ToList();
        }
    }
}
