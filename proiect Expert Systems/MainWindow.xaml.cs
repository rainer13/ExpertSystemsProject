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
using System.Windows.Forms;
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
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace proiect_Expert_Systems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BoolStringClass> myItemList { get; set; }
        public ObservableCollection<BoolStringClass> tagItemsList { get; set; }
       // DBCommunication dbCommunication;

        public MainWindow()
        {
            InitializeComponent();
         //   dbCommunication = new DBCommunication();
        }    

        public void butonDeAfisare_Click(object sender, RoutedEventArgs e)
        {
          //  Dictionary<string, double> myDic = Logic.addingFilesToTags(null);
          //  DBCommunication dbCommunication = new DBCommunication();            
           // GetTagsList(dbCommunication.tags.ToList());



            Browse b = new Browse();
            FolderBrowserDialog folder = b.browseFolder();
            selectedFolder.Text = folder.SelectedPath;
            GetMyItemList(b.getFolderContent(folder));

         //   File f = new File("C:\\Users\\Iulia\\Desktop\\folder\\file1.txt");
         //   f.textToWords();
        //    List<KeyValuePair<string,double>> dicToList=myDic.ToList();
        //    testDeScriere.Text = "";
         //   foreach (KeyValuePair<string, double> kvp in myDic)
        //        testDeScriere.Text += kvp.Key + " " + kvp.Value + "\n";

        }

        public class BoolStringClass
        {
            public string itemText { get; set; }
            public int itemValue { get; set; }
        }

        public void GetMyItemList(IEnumerable<string> f)
        {
            myItemList = new ObservableCollection<BoolStringClass>();
            int i = 0;
            foreach (var filePath in f)
            {
                myItemList.Add(new BoolStringClass { itemText = filePath, itemValue = i++ });
                this.DataContext = this;
            }      
        }

        private void GetTagsList(IEnumerable<Tag> tags)
        {
            tagItemsList = new ObservableCollection<BoolStringClass>();
            int i = 0;
            foreach (var tag in tags)
            {
                tagItemsList.Add(new BoolStringClass { itemText = tag.name, itemValue = i++ });
                this.DataContext = this;
            }
        }

        public void butonAddTag_Click(object sender, RoutedEventArgs e)
        {
            DBCommunication dbCommunication = new DBCommunication();
            Tag tag = new Tag(newTag.Text);
            dbCommunication.tags.Add(tag);
            dbCommunication.SaveChanges();
            newTag.Text = "";
            dbCommunication.Dispose();
            //GetTagsList(dbCommunication.tags.ToList());
        }

        public void butonGetTag_Click(object sender, RoutedEventArgs e)
        {
            DBCommunication dbCommunication = new DBCommunication();
            GetTagsList(dbCommunication.tags.ToList());
            dbCommunication.Dispose();
        }









        public void chkItem_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox chkSelecttedItem = (System.Windows.Controls.CheckBox)sender;
            System.Windows.MessageBox.Show("Selected Item Name= " + chkSelecttedItem.Content.ToString() + System.Environment.NewLine + "Selected Item Value= " + chkSelecttedItem.Tag.ToString());
        }
         

    }
}
