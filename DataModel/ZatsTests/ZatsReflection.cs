// Setting this define will run ZATS Test Case reflection in a separate App Domain which can be released after reflection is done.
// This prevents that Test Case DLLs from beeing blocked on the file system after reflection.
// This is useful when TCs are updated while CTT is running (e.g. during TC development). 
// However writing text to the output log does not work is this is active. So to see exception error and exception messages this needs to be turned off.
//#define RUN_IN_APP_DOMAIN

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CTTManagement.DataModel.ZatsTests.Enums;
using ZWave.CTT.Logger;

namespace CTTManagement.DataModel.ZatsTests
{
    public static class ZatsReflection
    {
#if RUN_IN_APP_DOMAIN
        private static AppDomainIsolation<ExportedTypesWorker> Loader;
#endif
        public static ZatsTestCaseReflectionData GetReflectionData(string dllPath, string testCaseName)
        {
#if RUN_IN_APP_DOMAIN
            if (Loader == null)
            {
                Loader = new AppDomainIsolation<ExportedTypesWorker>(Path.GetDirectoryName(dllPath));
            }
            return Loader.Object.GetExportedTypes(dllPath, testCaseName);
#else
            return new ExportedTypesWorker().GetExportedTypes(dllPath, testCaseName);
#endif
        }

        public static void ReleaseAppDomain()
        {
#if RUN_IN_APP_DOMAIN
            if (Loader != null)
            {
                Loader.ReleaseAppDomain();
                Loader = null;
            }
#endif
        }
    }

#if RUN_IN_APP_DOMAIN
    public class ExportedTypesWorker : MarshalByRefObject
    {
        // Potential fix for RemotingException "Object ... has been disconnected or does not exist at the server"
        public override object InitializeLifetimeService()
        {
            return null;
        }
#else
    public class ExportedTypesWorker
    {
#endif
        private bool ReflectionLogEnabled = true;

        public ZatsTestCaseReflectionData GetExportedTypes(string dllPath, string testCaseName)
        {
            Type testCase = null;
            ZatsTestCaseReflectionData data = new ZatsTestCaseReflectionData();

#if !RUN_IN_APP_DOMAIN
            if (ReflectionLogEnabled)
            {
                LogUtils.LogMessage("Reflecting " + testCaseName + "..." + Environment.NewLine);
            }
#endif
            // Load Test Case
            try
            {
                var allowedClassNames = new[] { "ZatsCodeTestCase", "CertTestCase" };
                var asm = Assembly.LoadFrom(dllPath);
                var types = asm.GetTypes(); // .Where(x => allowedClassNames.Contains(x.BaseType.Name)).ToArray();

                testCase = types.FirstOrDefault(x => x.Name == testCaseName);
            }
            catch (Exception e)
            {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Test Case Assembly failed!" + Environment.NewLine + e.Message, "Error in Reflection", ErrorType.Error);
                }
#endif
                return null;
            }

            // Name
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseAttribute");
                if (testCaseAttribute != null)
                {
                    data.Name = testCaseAttribute.GetType().GetProperty("Description").GetValue(testCaseAttribute, null).ToString();
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Name failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Description
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseDescriptionAttribute");
                if (testCaseAttribute != null)
                {
                    data.Description = testCaseAttribute.GetType().GetProperty("Description").GetValue(testCaseAttribute, null).ToString();
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Description failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Version
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseVersionAttribute");
                if (testCaseAttribute != null)
                {
                    var major = testCaseAttribute.GetType().GetProperty("Major").GetValue(testCaseAttribute, null);
                    var minor = testCaseAttribute.GetType().GetProperty("Minor").GetValue(testCaseAttribute, null);
                    data.Version = major + "." + minor;
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Version failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // FirmwareUpdateFileRequired
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseFirmwareUpdateFileRequiredAttribute");
                if (testCaseAttribute != null)
                {
                    data.FirmwareUpdateFileRequired = (bool)testCaseAttribute.GetType().GetProperty("FirmwareUpdateFileRequired").GetValue(testCaseAttribute, null);
                }
            }
            catch (Exception e)
            {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting FirmwareUpdateFileRequired failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Device Mappings (Required Serial API Hardware Parts)
            try
            {
                var testCaseAttributes = testCase.GetCustomAttributes().Where(x => x.GetType().Name == "DeviceMappingAttribute");
                if (testCaseAttributes != null)
                {
                    foreach (var inputAttribute in testCaseAttributes)
                    { 
                        var number = (int) inputAttribute.GetType().GetProperty("Number").GetValue(inputAttribute, null);
                        //var libraries = (LibTypes[]) inputAttribute.GetType().GetProperty("Libraries").GetValue(inputAttribute, null);
                        var libTypes = (int[]) inputAttribute.GetType().GetProperty("Libraries").GetValue(inputAttribute, null);

                        if (data.DeviceMappings == null)
                        {
                            data.DeviceMappings = new Dictionary<int, List<Libraries>>();
                        }

                        List<Libraries> libraries = new List<Libraries>();
                        foreach (int libType in libTypes)
                        {
                            libraries.Add((Libraries)libType);
                        }

                        if (!data.DeviceMappings.ContainsKey(number))
                        {
                            data.DeviceMappings.Add(number, libraries);
                        }
                    }
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Device Mappings failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Requirements Numbers
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseReqNumbersAttribute");
                if (testCaseAttribute != null)
                {
                    var property = testCaseAttribute.GetType().GetProperty("ReqNumbers").GetValue(testCaseAttribute, null);
                    data.ReqNumbers = new List<string>((string[])property);
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Requirements Numbers failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Group
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseGroupAttribute");
                if (testCaseAttribute != null)
                {
                    var testCaseGroup = testCaseAttribute.GetType().GetProperty("Group").GetValue(testCaseAttribute, null).ToString();
                    data.Group = (TestCaseGroup)Enum.Parse(typeof(TestCaseGroup), testCaseGroup);
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Group failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Category
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseCategoryAttribute");
                if (testCaseAttribute != null)
                {
                    data.Category = testCaseAttribute.GetType().GetProperty("Category").GetValue(testCaseAttribute, null).ToString();
                }
            }
            catch (Exception e)
            {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Category failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Endpoint Mappings
            try
            {
                var testCaseAttribute = testCase.GetCustomAttributes().FirstOrDefault(x => x.GetType().Name == "ZatsTestCaseEPMappingAttribute");
                if (testCaseAttribute != null)
                {
                    var testCaseMappingType = testCaseAttribute.GetType().GetProperty("MappingType").GetValue(testCaseAttribute, null).ToString();
                    EPMappingType epMappingType = (EPMappingType)Enum.Parse(typeof(EPMappingType), testCaseMappingType);

                    var property = testCaseAttribute.GetType().GetProperty("MappingValues").GetValue(testCaseAttribute, null);

                    data.EPMapping = new EPMapping { Type = epMappingType, Values = new List<string>((string[])property) };
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting End Point Mappings failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Input Keys
            try
            {
                var testCaseAttributes = testCase.GetCustomAttributes().Where(x => x.GetType().Name == "ZatsTestCaseInputKeyAttribute");
                if (testCaseAttributes != null)
                {
                    foreach (var inputAttribute in testCaseAttributes)
                    {
                        var testCaseInputKey = inputAttribute.GetType().GetProperty("InputKey").GetValue(inputAttribute, null).ToString();
                        var testCaseInputType = inputAttribute.GetType().GetProperty("Type").GetValue(inputAttribute, null).ToString();
                        InputType inputType = (InputType)Enum.Parse(typeof(InputType), testCaseInputType);
                        if (data.InputKeys == null)
                        {
                            data.InputKeys = new List<InputKey>();
                        }
                        data.InputKeys.Add(new InputKey { Key = testCaseInputKey, Type = inputType });
                    }
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Input Keys failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }

            // Result Keys
            try
            {
                var testCaseAttributes = testCase.GetCustomAttributes().Where(x => x.GetType().Name == "ZatsTestCaseResultKeyAttribute");
                if (testCaseAttributes != null)
                {
                    foreach (var inputAttribute in testCaseAttributes)
                    {
                        var testCaseResultKey = inputAttribute.GetType().GetProperty("ResultKey").GetValue(inputAttribute, null).ToString();
                        if (data.ResultKeys == null)
                        {
                            data.ResultKeys = new List<string>();
                        }
                        data.ResultKeys.Add(testCaseResultKey);
                    }
                }
            }
            catch (Exception e) {
#if !RUN_IN_APP_DOMAIN
                if (ReflectionLogEnabled)
                {
                    LogUtils.LogError("Reflection: Getting Result Keys failed!", "Error in Reflection" + Environment.NewLine + e.Message, ErrorType.Error);
                }
#endif
            }
            return data;
        }
    }

#if RUN_IN_APP_DOMAIN
    public sealed class AppDomainIsolation<T>
        where T : MarshalByRefObject
    {
        private AppDomain _domain;
        private readonly T _object;

        public AppDomainIsolation(string assemblyDirectory)
        {
            string dir = Assembly.GetExecutingAssembly().FullName;
            _domain = AppDomain.CreateDomain("CTTReflectionDomain:" + Guid.NewGuid());

            var type = typeof(T);
            _object = (T)_domain.CreateInstanceAndUnwrap(dir, typeof(T).FullName);
        }

        public T Object
        {
            get { return _object; }
        }

        public void ReleaseAppDomain()
        {
            if (_domain != null)
            {
                AppDomain.Unload(_domain);
                _domain = null;
            }
        }
    }
#endif
}
