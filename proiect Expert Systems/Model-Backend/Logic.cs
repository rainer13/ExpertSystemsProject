using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using proiect_Expert_Systems.Model_Backend;
using System.Windows.Forms;
using System.IO;

namespace proiect_Expert_Systems.Model_Backend
{
    class Logic
    {

        public static Dictionary<string, double> addingFilesToTags(Tag tag)
        {


            string rootFolder = myXMLClass.readRoot();
            

            Dictionary<string, double> dic = new Dictionary<string, double>();
            dic.Add("lalal",1);
            return dic;

        }

       

    }
}
