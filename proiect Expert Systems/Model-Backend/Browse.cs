using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;

namespace proiect_Expert_Systems.Model_Backend
{
    class Browse
    {
        public void browseFolder(){
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            string[] files = Directory.GetFiles(fbd.SelectedPath);
            SearchOption searchOption = SearchOption.AllDirectories;
            IEnumerable<string> listDir = Directory.EnumerateDirectories(fbd.SelectedPath, "*", searchOption);

            foreach (string f in listDir)
            {
                System.Windows.Forms.MessageBox.Show("Files last found: " + f.ToString(), "Message");
            }

            System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
        }

    }
}
