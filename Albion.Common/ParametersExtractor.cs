using System.Collections.Generic;

namespace Albion.Common
{
    public static class ParametersExtractor
    {
        public static string StringOrNull(this Dictionary<byte, object> parameters, byte i)
        {
            parameters.TryGetValue(i, out var value);
            return value?.ToString();
        }

    }
}