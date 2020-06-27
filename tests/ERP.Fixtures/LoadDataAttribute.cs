using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace ERP.Fixtures
{
    public sealed class LoadDataAttribute : DataAttribute
    {
        private readonly string _fileName;
        private readonly string _section;

        public LoadDataAttribute(string section)
        {
            _fileName = @"record-data.json";
            _section = section;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            string path = Path.IsPathRooted(_fileName)
                ? _fileName
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), _fileName);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"File not found: {path}");
            }

            string fileData = File.ReadAllText(_fileName);

            if (string.IsNullOrEmpty(_section))
            {
                return JsonConvert.DeserializeObject<List<string[]>>(fileData);
            }

            JObject allData = JObject.Parse(fileData);
            JToken data = allData[_section];
            return new List<object[]> { new[] { data.ToObject(testMethod.GetParameters().First().ParameterType) } };
        }
    }
}