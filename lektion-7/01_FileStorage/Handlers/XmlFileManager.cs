using _01_FileStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _01_FileStorage.Handlers
{
    internal class XmlFileManager : FileHandler
    {
        public XmlFileManager(string filePath)
        {
            _filePath = filePath;
        }

        public override void ReadFromFile()
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlNodeList xmlnode;
                int i = 0;
                string str = null;

                doc.Load(_filePath);
                xmlnode = doc.GetElementsByTagName("user");
                for (i = 0; i <= xmlnode.Count - 1; i++)
                {
                    _users.Add(new UserModel
                    {
                        Id = xmlnode[i].ChildNodes.Item(0).InnerText.Trim(),
                        Name = xmlnode[i].ChildNodes.Item(1).InnerText.Trim(),
                        Email = xmlnode[i].ChildNodes.Item(2).InnerText.Trim()
                    });
                }
            }
            catch { }
            

        }

        public override void WriteToFile()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml($"<users></users>");

                foreach (var user in _users)
                {
                    XmlElement id = doc.CreateElement("id");
                    id.InnerText = user.Id;
                    XmlElement name = doc.CreateElement("name");
                    name.InnerText = user.Name;
                    XmlElement email = doc.CreateElement("email");
                    email.InnerText = user.Email;

                    XmlElement userElement = doc.CreateElement("user");
                    userElement.AppendChild(id);
                    userElement.AppendChild(name);
                    userElement.AppendChild(email);

                    doc.DocumentElement.AppendChild(userElement);
                }


                XmlWriterSettings settings = new();
                settings.Indent = true;

                try
                {
                    XmlWriter writer = XmlWriter.Create(_filePath, settings);
                    doc.Save(writer);
                    writer.Close();
                }
                catch { }
            }
            catch { }

        }
    }
}
