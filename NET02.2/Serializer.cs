using System;
using System.IO;
using System.Xml.Serialization;

namespace NET02._2
{
    public static class Serializer
    {
        private static string fileName = "UserSettings.xml";
        
        public static void XmlSerialize(Login login)
        {
            XmlSerializer formatterLogin = new XmlSerializer(typeof(Login));

            using FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            formatterLogin.Serialize(fileStream, login);
            Console.WriteLine("Serialize");
        }

        public static void XmlDeserialize(Login login)
        {
            XmlSerializer formatterLogin = new XmlSerializer(typeof(Login));

            using FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            login = formatterLogin.Deserialize(fileStream) as Login;
            Console.WriteLine("Deserialize");
            if (login != null)
            {
                Console.WriteLine($"{login.Name}");
                foreach (var window in login.Windows)
                {
                    Console.WriteLine($"Top: {window.Top}\n" +
                                      $"Bottom: {window.Bottom}\n" +
                                      $"Left: {window.Left}\n" +
                                      $"Right: {window.Right}");
                }
            }

            
        }
    }
}