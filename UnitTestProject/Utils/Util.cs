using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace UnitTestProject.Utils
{
    static class Util
    {
        const string ResourceKey = "UnitTestProject.Texts.";

        public static string LoadText(string name)
        {
            using (Stream stream = Assembly.GetExecutingAssembly()
                               .GetManifestResourceStream(ResourceKey + name))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string AsXaml(object instance)
        {
            using (var writer = new StringWriter())
            {
                var settings = new XmlWriterSettings { Indent = true };
                using (var xmlWriter = XmlWriter.Create(writer, settings))
                {
                    var docGen = new BrokenXamlWriter();
                    var docObj = docGen.Transform(instance);
                    docObj.Save(xmlWriter);

                    //XamlServices.Save(xmlWriter, instance);
                    //XamlWriter.Save(instance, xmlWriter);
                }

                writer.WriteLine();
                return writer.ToString();
            }

            //using (var writer = new StringWriter())
            //{
            //    var settings = new XmlWriterSettings { Indent = true };
            //    using (var xmlWriter = XmlWriter.Create(writer, settings))
            //    {
            //        XamlServices.Save(xmlWriter, instance);
            //    }
            //
            //    writer.WriteLine();
            //    return writer.ToString();
            //}
        }

        public static string GetRuntimeName()
        {
            var description = RuntimeInformation.FrameworkDescription.ToLower();
            // ".NET Framework"
            // ".NET Core"(for .NET Core 1.0 - 3.1)
            // ".NET Native"
            // ".NET"(for .NET 5.0 and later versions)

            if (description.Contains("framework"))
            {
                return "framework";
            }

            if (description.Contains("core"))
            {
                return "core";
            }

            if (description.Contains("native"))
            {
                return "native";
            }

            return "dotnet";
        }
    }
}
