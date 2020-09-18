using System;
using System.Collections.Generic;
using CTTManagement.DataModel.ZatsTests.Enums;

namespace CTTManagement.DataModel.ZatsTests
{
    [Serializable]
    public class ZatsTestCaseReflectionData 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "n/a";
        public Dictionary<int, List<Libraries>> DeviceMappings { get; set; }
        public List<string> ReqNumbers { get; set; }
        public TestCaseGroup Group { get; set; }
        public string Category { get; set; }
        public List<InputKey> InputKeys { get; set; }
        public List<string> ResultKeys { get; set; }
        public EPMapping EPMapping { get; set; }
        public bool FirmwareUpdateFileRequired { get; set; }
    }

    [Serializable]
    public class InputKey
    {
        public string Key { get; set; }

        public InputType Type { get; set; }
    }

    [Serializable]
    public class EPMapping
    {
        public EPMappingType Type { get; set; }

        public List<string> Values { get; set; }

    }
}
