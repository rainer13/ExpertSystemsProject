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
        public int numberOfWords { get; set; }
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

        public File(string l, int now)
        {
            location = l;
            numberOfWords = now;
            isDirectory = false;
            dbComm.files.Add(this);

        }

        public File(string l)
        {
            location = l;
            isDirectory = true;
            numberOfWords = 0;
        }

        public Dictionary<string, long> textToWords()
        {
            Dictionary<string, long> wordCount = new Dictionary<string, long>();
            string allText = System.IO.File.ReadAllText(@location);
            char[] splitters = new char[10];
            splitters[0]=' ';
            splitters[1]='.';
            splitters[2]=';';
            splitters[3]=',';
            splitters[4]='"';
            splitters[5]='<';
            splitters[6]='>';
            splitters[7]='+';
            splitters[8]='-';
            splitters[9]='/';
            splitters[10]='\\';
            string[] words = allText.Split(splitters);
            return wordCount;
            long a;
            foreach (string word in words)
            {
                a = 0;
                if (wordCount.TryGetValue(word,out a))
                {
                    wordCount.Add(word, a + 1);
                }
                else
                    wordCount.Add(word,1);
            }
        }


    }
}
