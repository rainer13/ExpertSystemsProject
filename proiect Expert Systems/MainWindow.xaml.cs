using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using proiect_Expert_Systems.Model_Backend;

namespace proiect_Expert_Systems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



       

        private void butonDeAfisare_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, double> myDic = Logic.addingFilesToTags(null);
            Browse b = new Browse();
            b.browseFolder();
            File f = new File("C:\\Users\\rretzler\\Desktop\\FolderForESPrj\\file1.txt");
            f.textToWords();
            List<KeyValuePair<string,double>> dicToList=myDic.ToList();
            testDeScriere.Text = "";
            foreach (KeyValuePair<string, double> kvp in myDic)
                testDeScriere.Text += kvp.Key + " " + kvp.Value + "\n";

        }


    }
}
