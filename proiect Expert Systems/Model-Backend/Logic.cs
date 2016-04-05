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

        static DBCommunication dbCommunication = new DBCommunication();


        public static Dictionary<string, double> assignTagToFiles(string tag)
        {
            
            string rootFolder = myXMLClass.readRoot();

            string[] allfiles = System.IO.Directory.GetFiles(rootFolder, "*.*", System.IO.SearchOption.AllDirectories);
 




            Dictionary<string, double> dic = new Dictionary<string, double>();

            //IEnumerable<Tag> tags = dbCommunication.tags.ToList().Where(m => m.name == tag);
            //List<string> tagsFiles = tags.First().fileLocations;

            List<string> tagsFiles = new List<string>();
            tagsFiles.Add(@"C:\Users\rretzler\Desktop\FolderForESPrj\file1.txt");

            foreach (string s in allfiles)
            {
                if (tagsFiles.Contains(s))
                    dic.Add(s, 1);
                else
                {
                    double maxP = 0;
                    foreach (string ss in tagsFiles)
                    {
                        File f1 = new File(s);
                        File f2 = new File(ss);
                        Dictionary<string, long> ff1 = f1.textToWords(s);
                        Dictionary<string, long> ff2 = f2.textToWords(ss);
                        double p = matchFilessWords(ff1,ff2);
                        if (p > maxP)
                            maxP = p;
                    }
                    dic.Add(s,maxP);
                }
                    
            }
            
            return dic;

        }

        public static Dictionary<Tag, double> assignTagsToFile(string file)
        {
            Dictionary<Tag, double> myDic = new Dictionary<Tag, double>();
            File f = new File(file);
            Dictionary<string, long> filesWords = f.textToWords(file);
            List<Tag> myTags = dbCommunication.tags.ToList<Tag>();
            foreach (Tag t in myTags)
            {

               double maxProbability = 0;
 
                foreach (string tagsFiles in t.fileLocations)
                {
                    double dd = 0;
                    File tagsFile = new File(tagsFiles);
                    Dictionary<string, long> tagsFilesWords = tagsFile.textToWords(tagsFile.location);
                    dd = matchFilessWords(filesWords, tagsFilesWords);
                    if (dd > maxProbability)
                        maxProbability = dd;

                }
                myDic.Add(t, maxProbability);
            }
            return myDic;
        }

        public static double matchFilessWords(Dictionary<string, long> file1, Dictionary<string, long> file2)
        {
            double d = 0;
            KeyValuePair<long, long> k;

            k = countFilesWords(file1);
            long file1WordCount = k.Key;
            long file1WordlistCount = k.Value;
            k = countFilesWords(file2);
            long file2WordCount = k.Key;
            long file2WordlistCount = k.Value;

            List<KeyValuePair<string, long>> file1WordsList = file1.ToList();
            List<KeyValuePair<string, long>> file2WordsList = file2.ToList();
            
            long c1 = 0, c2 = 0, s1 = 0, s2 = 0, counter=0;
            double pp1=0.0, ppp1=0.0, pp2=0.0, ppp2=0.0;
            
            foreach (KeyValuePair<string, long> kvp in file1WordsList)
            {
                double p1 = 1.0 * kvp.Value / file1WordCount;
                long nrWordInFile2;
                bool b = file2.TryGetValue(kvp.Key, out nrWordInFile2);
                if (b)
                {
                    double p2 = 1.0 * nrWordInFile2 / file2WordCount;
                    d += Math.Min(p1 / p2, p2 / p1);
                    ++counter;
                }
                else
                {
                    ++c1;
                    pp1 += 1.0 * kvp.Value / file1WordCount;
                    ppp1 += 1.0 / file1WordlistCount;
                }
            }

            d /= counter;
            foreach (KeyValuePair<string, long> kvp in file2WordsList)
            {
                long l;
                bool b = file1.TryGetValue(kvp.Key, out l);
                if (!b)
                {
                    ++c2;
                    pp2 += 1.0 * kvp.Value / file1WordCount;
                    ppp2 += 1.0 / file1WordlistCount;
                }
            }

            long l1 = file1.Count, l2 = file2.Count;

            if (c2 != 0)
            {
                pp2 = 1.0 * s2 / file2WordCount;
                ppp2 = s2 / (c2 + s2);


                if (c1 != 0)
                    d -= (pp1 / c1 + ppp1 / c1 + pp2 + ppp2) / 4;
            }
           

            
            return Math.Max(d,0);
        }

        public static KeyValuePair<long, long> countFilesWords(Dictionary<string, long> file)
        {

            List<KeyValuePair<string, long>> wordList = file.ToList();
            long counter = 0;
            long counter1 = 0;
            foreach (KeyValuePair<string, long> kvp in wordList) 
            {
                counter += kvp.Value;
                ++counter1;

            }
            KeyValuePair<long, long> ret = new KeyValuePair<long, long>(counter, counter1); 
            return ret;
        }

    }
}
