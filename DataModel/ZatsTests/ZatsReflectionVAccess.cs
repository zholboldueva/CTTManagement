using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CTTManagement.DataModel.ZatsTests.Enums;
using CTTManagement.Model;

namespace  CTTManagement.DataModel.ZatsTests
{
   public class ZatsReflectionVAccess
    {
        public ZatsTestsModel reflectedData;
        public List<ZatsTestsModel> GetTestFiles()
        {
            List<ZatsTestsModel> zatsTestCases = new List<ZatsTestsModel>();
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\MK-Logic\Downloads\ZatsReflection\ZatsReflection\ZatsReflection\ZatsTestCases");
            FileInfo[] Files = d.GetFiles("*.dll");
            Regex underlines = new Regex(@"[_]{1,}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            int count = 0;
            string testFileName = "";
            List<string> tests = new List<string>();
            foreach (FileInfo file in Files)
            {
                if (underlines.IsMatch(file.Name))
                {
                    testFileName = file.Name.Replace(".dll", "");
                    var reflectionData = ZatsReflection.GetReflectionData(@"..\..\ZatsTestCases\" + file.Name, testFileName);

                    if (reflectionData is ZatsTestCaseReflectionData)
                    {
                        reflectedData = new ZatsTestsModel();
                        count++;
                        reflectedData.TestCaseName = reflectionData.Name;
                        if(reflectionData.InputKeys!=null)
                        reflectedData.TCInputKeys = GetInputKeys(reflectionData.InputKeys);
                        if (reflectionData.ResultKeys != null)
                            reflectedData.TCResultKeys = GetResultKeys(reflectionData.ResultKeys);
                            reflectedData.TestCaseGroup = reflectionData.Group.ToString();
                        if (reflectionData.DeviceMappings != null)
                            reflectedData.LibrariesNeeded = GetLibrariesNeeded(reflectionData.DeviceMappings);
                        zatsTestCases.Add(reflectedData);
                       
                    }
                    else
                    {
                        Console.WriteLine("Error while reflecting DLL!");
                    }
                }
            }
            return zatsTestCases;
        }

        public string GetInputKeys(List<InputKey> inputKeys)
        {
            string outputArray = "";
           
                foreach (InputKey inputKey in inputKeys)
                {
                    outputArray += inputKey.Key + "\n";
                }
            return outputArray;
        }

        public string GetResultKeys(List<string> inputKeys)
        {
            string outputArray = "";

            foreach (string inputKey in inputKeys)
            {
                outputArray += inputKey + "\n";
            }
            return outputArray;
        }

        public string GetLibrariesNeeded(Dictionary<int, List<Libraries>> DeviceMappings)
        {
            string outputArray = "";
            foreach (KeyValuePair<int, List<Libraries>> libraries in DeviceMappings)
            {

                foreach (Libraries library in libraries.Value)
                {
                    outputArray += library + "\n";
                }
               
            }
            return outputArray;
        }

    }
}
