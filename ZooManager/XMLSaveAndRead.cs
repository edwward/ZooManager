using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ZooManager
{
    public static class XMLSaveAndRead
    {
        public static void SaveZooToXML(Zoo list)
        {
            FileStream fs = new FileStream("zoo.xml", FileMode.Create);     //save zoo to xml
            new XmlSerializer(typeof(Zoo)).Serialize(fs, list);
        }

        public static List<Animal> LoadZooFromXML()             //FUNGUJE
        {
            try
            {
                var doc = XDocument.Load("C:\\Users\\edwwa\\source\\repos\\ZooManager\\ZooManager\\bin\\Debug\\zoo.xml");
                List<Animal> list = doc.Descendants("Animal").Select(d =>
                  new Animal
                  {
                      Species = d.Element("Species").Value,
                      Weight = int.Parse(d.Element("Weight").Value)

                  }).ToList();

                return list;
            }
            catch (System.Xml.XmlException e)
            {
                Console.WriteLine("file not found {0}", e);
                return null;
            }
            //finally 
            //{
            //    FileStream fs = new FileStream("zoo.xml", FileMode.Create);
            //}
        }

    }
}
