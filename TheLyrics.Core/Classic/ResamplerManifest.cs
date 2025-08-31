using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TheLyrics.Core;
using TheLyrics.Core.Ustx;

namespace TheLyrics.Classic {
    public class ResamplerManifest {
        public Dictionary<string, UExpressionDescriptor> expressions = new Dictionary<string, UExpressionDescriptor> { };
        public bool expressionFilter = false;

        public ResamplerManifest() { }

        public static ResamplerManifest Load(string path) {
            var manifest = Yaml.DefaultDeserializer.Deserialize<ResamplerManifest>(
                File.ReadAllText(path, encoding: Encoding.UTF8)
                );
            manifest.expressions = manifest.expressions
                                .GroupBy(kvp => kvp.Key.ToLower())
                                .ToDictionary(
                                    group => group.Key,
                                    group => group.First().Value
                                );
            return manifest;
        }
    }
}
