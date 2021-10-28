using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NET02._2.Entities;

namespace NET02._2
{
    class Program
    {
        static async Task Main(string[] args)
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
                Title = "title2"
            };
            Window third = new Window
            {
                Height = 15,
                Width = 15,
                Top = 15,
                Left = 15,
                Title = "main"
            };
            Login login1 = new Login()
            {
                Name = "Guf",
                Windows = new List<Window>{first, second}
            };
            Login login2 = new Login()
            {
                Name = "Fuf",
                Windows = new List<Window>{first, third}
            };
            logins = Serializer.XmlDeserialize();
            Serializer.XmlSerialize(new List<Login>{login1, login2});
            if (logins != null)
            {
                foreach (var login in logins)
                {
                    if (!Serializer.IsLoginCorrect(login))
                    {
                        Console.WriteLine($"{login.Name} :false");
                        foreach (var window in login.Windows)
                        {
                            Console.WriteLine($"Title: {window.Title}\nTop: {window.Top} " +
                                              $"Bottom: {window.Width} " +
                                              $"Left: {window.Left} " +
                                              $"Right: {window.Height} ");
                        }
                    }
                }
            }

            await Serializer.JsonSerialize(new List<Login>{login1, login2});
            List<Login> jsonLogin = await Serializer.JsonDeserialize();
            Serializer.XmlSplitting();
        }
    }
}