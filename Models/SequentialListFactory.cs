using System.Collections.Generic;
using Newtonsoft.Json;
using SequenceDataStructure.Helpers;
using SequenceDataStructure.Models.Exceptions;
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
        /// 
        public static SequentialList CreateNew(int min, int max)
        {
            return new SequentialList(min, max);
        }
        public static SequentialList CreateNew(SequentialListJSONInput input)
        {
            var output = new SequentialList(input);
            //only allow sequentials
            if (!output.IsSequential()) { throw new NotSequentialException(); }
            return new SequentialList(input);
        }
        /// <summary>
        /// Creates a list from a POST request
        /// </summary>
        /// <param name="input">The input provided by user</param>
        public static IEnumerable<int> CreateNew(SequentialListInput input)
        {
            return new SequentialList(input.Min, input.Max);
        }
        /// <summary>
        /// Creates a JSON string from a request
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateJSONList(SequentialListInput input)
        {
            var obj = CreateNew(input);
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }
    }
}
