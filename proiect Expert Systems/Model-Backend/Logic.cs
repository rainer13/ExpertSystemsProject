using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace proiect_Expert_Systems.Model_Backend
{
    class Logic
    {

        public static Dictionary<string, double> addingFilesToTags(Tag tag)
        {

            string rootDirectory = "";
            XmlDocument myDoc = new XmlDocument();
            
            try
            {
                myDoc.Load(@"C:\Users\rretzler\Documents\Visual Studio 2013\Projects\proiect Expert Systems\proiect Expert Systems\Model-Backend\Settings.xml");
                int a = 2;
                XmlNode node = myDoc.SelectSingleNode("data/rootDirectory");
                rootDirectory = node.InnerText.ToString().Trim();
                node.InnerText += "123";
                a = 3;
            
            }
            catch (FieldAccessException f)
            {
                rootDirectory += f.ToString();
                rootDirectory += f.InnerException;
            }
            catch (XmlException x)
            {
                rootDirectory += x.ToString();
                rootDirectory += x.Message;
            }
            catch (Exception e)
            {
                rootDirectory += e.ToString();
            }

            Dictionary<string, double> dic = new Dictionary<string, double>();
            dic.Add("lalal",1);
            //return dic;
            //System.IO.File.OpenWrite("C:\\Users\\rretzler\\Desktop\\testES.txt");
            System.IO.File.WriteAllText(@"C:\\Users\\rretzler\\Desktop\\testES.txt",rootDirectory);
            return null;

        }

       

    }
}
