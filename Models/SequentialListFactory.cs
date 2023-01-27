using System.Collections.Generic;
using Newtonsoft.Json;

namespace SequenceDataStructure.Models
{
    /// <summary>
    /// Factory used to create by API
    /// </summary>
    public static class SequentialListFactory
    {
        private static IEnumerable<int> GenerateList(SequentialListInput input)
        {
            return new SequentialList(input.Min, input.Max);
        }
        /// <summary>
        /// Creates a JSON string from a request
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateFromInput(SequentialListInput input)
        {
            var obj = GenerateList(input);
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
