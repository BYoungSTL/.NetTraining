using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using NET02._2.Entities;

namespace NET02._2
{
    public static class Serializer
    {
        private static string fileName = "D:\\RiderProjects\\NET Tasks\\NET02\\NET02\\NET02.2\\Config\\UserSettings.xml";
        
        public static void XmlSerialize(List<Login> logins)
        {
            XmlSerializer formatterLogin = new XmlSerializer(typeof(List<Login>)); 
            using FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            formatterLogin.Serialize(fileStream, logins);
            Console.WriteLine("Serialize");
        }

        public static List<Login> XmlDeserialize()
        {
            XmlSerializer formatterLogin = new XmlSerializer(typeof(List<Login>));

            using FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
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
            if (login.Windows.Count == 1 && login.Windows[0].Title.ToLower() == correctString && login.Windows[0].IsExistMainWindow())
            {
                return true;
            }

            if (login.Windows.TrueForAll(w=>!String.Equals(w.Title, correctString, StringComparison.CurrentCultureIgnoreCase)))
            {
                return true;
            }

            return false;
        }
    }
}