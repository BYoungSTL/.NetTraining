using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using NET02._2.Entities;

namespace NET02._2
{
    public static class Serializer
    {
        private static string xmlFileName = "D:\\RiderProjects\\NET Tasks\\NET02\\NET02\\NET02.2\\Config\\UserSettings.xml";
            //"D:\\RiderProjects\\NET Tasks\\NET02\\NET02\\NET02.2\\Config\\UserSettings.xml";

        private static string jsonFileName = "D:\\RiderProjects\\NET Tasks\\NET02\\NET02\\NET02.2\\Config\\user.json";
            //"D:\\RiderProjects\\NET Tasks\\NET02\\NET02\\NET02.2\\Config\\user.json";
        private static string splitXmlFilePath = "D:\\RiderProjects\\NET Tasks\\NET02\\NET02\\NET02.2\\user.json";
            //"D:\\RiderProjects\\NET Tasks\\NET02\\NET02\\NET02.2\\Config\\";

        public static void XmlSerialize(List<Login> logins)
        {
            XmlSerializer formatterLogin = new XmlSerializer(typeof(List<Login>));
            using FileStream fileStream = new FileStream(xmlFileName, FileMode.OpenOrCreate);
            formatterLogin.Serialize(fileStream, logins);
            Console.WriteLine("Serialize");
        }

        public static List<Login> XmlDeserialize()
        {
            XmlSerializer formatterLogin = new XmlSerializer(typeof(List<Login>));

            using FileStream fileStream = new FileStream(xmlFileName, FileMode.OpenOrCreate);
            List<Login> logins = formatterLogin.Deserialize(fileStream) as List<Login>;
            Console.WriteLine("Deserialize");
            return logins;
        }

        /// <summary>
        /// True:
        ///     - The login configuration contains the settings for exactly one window titled main,
        ///       and for this window all four nested elements (top, left, width, height) are present
        ///     - The login configuration does not have the settings for window titled main
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool IsLoginCorrect(Login login)
        {
            const string correctString = "main";
            if (login.Windows.Count == 1 && login.Windows[0].Title.ToLower() == correctString &&
                login.Windows[0].IsExistMainWindow())
            {
                return true;
            }

            if (login.Windows.TrueForAll(w =>
                !String.Equals(w.Title, correctString, StringComparison.CurrentCultureIgnoreCase)))
            {
                return true;
            }

            return false;
        }

        //need to set up json serializer/deserializer
        public static async Task<List<Login>> JsonDeserialize()
        {
            List<Login> login;
            await using FileStream fileStream = new FileStream(jsonFileName, FileMode.OpenOrCreate);
            login = await JsonSerializer.DeserializeAsync<List<Login>>(fileStream);

            return login;
        }

        public static async Task JsonSerialize(List<Login> logins)
        {
            await using FileStream fileStream = new FileStream(jsonFileName, FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync(fileStream, logins);
        }

        /// <summary>
        /// Split users from main XML, separate user - separate file
        ///     ! Need to add default values(top = 0; left = 0; width = 400; height = 150;
        ///     ! Need to fix file name of split user
        /// </summary>
        public static void XmlSplitting()
        {
            XDocument doc = XDocument.Load(xmlFileName);
            string username = doc.Element("Login")?.Value;
            var newDocs = doc.Descendants("Login")
                .Select(d => new XDocument(d));
            XNamespace defaultNamespace = doc.Root.GetDefaultNamespace();
            int i = 0;
            foreach (var newDoc in newDocs)
            {
                if (newDoc.Element(defaultNamespace + "top") == null)
                {
                    newDoc.Add(new XElement("top", "0"));
                }

                if (newDoc.Element("left") == null)
                {
                    newDoc.Add(new XElement("left", "0"));
                }

                if (newDoc.Element("width") == null)
                {
                    newDoc.Add(new XElement("width", "400"));
                }

                if (newDoc.Element("height") == null)
                {
                    newDoc.Add(new XElement("height", "150"));
                }

                newDoc.Save(splitXmlFilePath + $"SplitUser{i}.xml");
                i++;
            }
            
        }
    }
}
