using System.Collections.Generic;
using System.IO;
using YamlDotNetFork.Core;
using YamlDotNetFork.Core.Events;
using YamlDotNetFork.Serialization;
using YamlDotNetFork.Samples.Helpers;

namespace YamlDotNetFork.Samples
{
    public class DeserializingMultipleDocuments
    {
        private readonly ITestOutputHelper output;

        public DeserializingMultipleDocuments(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Sample(
            DisplayName = "Deserializing multiple documents",
            Description = "Explains how to load multiple YAML documents from a stream."
        )]
        public void Main()
        {
            var input = new StringReader(Document);

            var deserializer = new DeserializerBuilder().Build();

            var parser = new Parser(input);

            // Consume the stream start event "manually"
            parser.Expect<StreamStart>();

            while (parser.Accept<DocumentStart>())
            {
                // Deserialize the document
                var doc = deserializer.Deserialize<List<string>>(parser);

                output.WriteLine("## Document");
                foreach (var item in doc)
                {
                    output.WriteLine(item);
                }
            }
        }

        private const string Document = @"---
- Prisoner
- Goblet
- Phoenix
---
- Memoirs
- Snow 
- Ghost        
...";
    }
}
