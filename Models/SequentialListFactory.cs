using System.Collections.Generic;
using Newtonsoft.Json;

namespace SequenceDataStructure.Models
{
    /// <summary>
    /// Factory used to create by API
    /// </summary>
    public static class SequentialListFactory
    {
        /// <summary>
        /// This is used to make a list during a "GET". If there were a DB,that would be used instead
        /// </summary>
        public static SequentialList GenerateList(int min, int max)
        {
            return new SequentialList(min, max);
        }
        /// <summary>
        /// Creates a list from a POST request
        /// </summary>
        /// <param name="input">The input provided by user</param>
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
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }
    }
}
