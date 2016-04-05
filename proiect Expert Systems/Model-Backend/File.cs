using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_Expert_Systems.Model_Backend
{
    class File
    {

        [Key]
        public int Id { get; set; }
        public string location { get; set; }
        public List<Tag> tags { get; set; }
        public bool isDirectory { get; set; }



        public static DBCommunication dbComm = new DBCommunication();

        public override bool Equals(object obj)
        {
            if (!(obj is File))
                return false;
            File t = obj as File;
            if (t.location != this.location)
                return false;
            return true;
        }

        public File(string l)
        {
            location = l;
            isDirectory = false;

        }

        public File(string l, bool b)
        {
            location = l;
            isDirectory = true;
        }

        public Dictionary<string, long> textToWords(string location)
        {
            Dictionary<string, long> wordCount = new Dictionary<string, long>();
            string allText = System.IO.File.ReadAllText(@location);
            char[] splitters = new char[14];
            splitters[0] = ' ';
            splitters[1] = '.';
            splitters[2] = ';';
            splitters[3] = ',';
            splitters[4] = '"';
            splitters[5] = '<';
            splitters[6] = '>';
            splitters[7] = '+';
            splitters[8] = '-';
            splitters[9] = '/';
            splitters[10] = '\\';
            splitters[11] = '\t';
            splitters[12] = '\r';
            splitters[13] = '\n';
            string[] words = allText.Split(splitters);
            long a;
            foreach (string word in words)
            {
                if (word != null)
                    if (word != "")
                    {
                        a = 0;
                        if (wordCount.TryGetValue(word, out a))
                        {
                            wordCount.Remove(word);
                            wordCount.Add(word, a + 1);
                        }
                        else
                            wordCount.Add(word, 1);
                    }
            }
            List<KeyValuePair<string, long>> wordsList = wordCount.ToList();
            string s="";
            foreach (KeyValuePair<string, long> w in wordsList)
                s += w.Key + " " + w.Value + "\n";
            try
            {
                System.IO.File.WriteAllText(@"C:\Users\Iulia\Desktop\folder\file1.txt", s);
            }
            catch (Exception e) { }
            return wordCount;
        }

        public File() { }


    }
}
