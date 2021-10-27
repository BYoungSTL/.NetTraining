using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NET02._2.Entities;

namespace NET02._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Login> logins = new List<Login>();
            Window first = new Window
            {
                Height = 10,
                Width = 10,
                Top = 10,
                Left = 10,
                Title = "title1"
            };
            Window second = new Window
            {
                Height = 15,
                Width = 15,
                Top = 15,
                Left = 15,
                Title = "Title2"
            };
            Login login1 = new Login()
            {
                Name = "Guf",
                Windows = new List<Window>{first, second}
            };
            Login login2 = new Login()
            {
                Name = "Fuf",
                Windows = new List<Window>{first, second}
            };
            logins = Serializer.XmlDeserialize();
            Serializer.XmlSerialize(new List<Login>{login1, login2});
            if (logins != null)
            {
                foreach (var login in logins)
                {
                    Console.WriteLine($"{login.Name}");
                    foreach (var window in login.Windows)
                    {
                        Console.WriteLine($"Top: {window.Top}\n" +
                                          $"Bottom: {window.Width}\n" +
                                          $"Left: {window.Left}\n" +
                                          $"Right: {window.Height}");
                    }
                }
            }

            Console.WriteLine(logins != null && Serializer.IsLoginCorrect(logins[0]));
        }
    }
}