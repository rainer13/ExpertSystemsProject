using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace proiect_Expert_Systems.Model_Backend
{
    class myXMLClass
    {


        static string readRoot(){

            string rootDirectory = "";
            XmlDocument myDoc = new XmlDocument();

            try
            {
                myDoc.Load(@"C:\Users\rretzler\Documents\Visual Studio 2013\Projects\proiect Expert Systems\proiect Expert Systems\Model-Backend\Settings.xml");
                XmlNode node = myDoc.SelectSingleNode("data/rootDirectory");
                rootDirectory = node.InnerText.ToString().Trim();
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

            return rootDirectory;

        }

        static void writeSomeWhere()
        {

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(@"C:\Users\rretzler\Documents\Visual Studio 2013\Projects\proiect Expert Systems\proiect Expert Systems\Model-Backend\Settings.xml");
            XmlTextWriter textWriter = new XmlTextWriter(@"C:\Users\rretzler\Documents\Visual Studio 2013\Projects\proiect Expert Systems\proiect Expert Systems\Model-Backend\Settings.xml", System.Text.Encoding.UTF8);
            myDoc.Save(textWriter);
        }


    }
}
