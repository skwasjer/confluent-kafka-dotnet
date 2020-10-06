namespace Confluent.SchemaRegistry.Serdes
{
    /// <summary>
    /// A schema validation error.
    /// </summary>
    public class SchemaValidationError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaValidationError"/> class.
        /// </summary>
        /// <param name="property">The property name.</param>
        /// <param name="path">The property path.</param>
        public SchemaValidationError(string property, string path)
        {
            Property = property;
            Path = path;
        }

        /// <summary>Gets the property name.</summary>
        public string Property { get; }

        /// <summary>Gets the property path.</summary>
        public string Path { get; }
    }
}
