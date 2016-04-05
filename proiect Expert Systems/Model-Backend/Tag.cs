using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_Expert_Systems.Model_Backend
{
    class Tag
    {
        [Key]
        public int Id { get; set; }
        public List<string> fileLocations { get; set; }
        public string name { get; set; }

        public static DBCommunication dbComm = new DBCommunication();

        public override bool Equals(object obj)
        {
            if (!(obj is Tag))
                return false;
            Tag t = obj as Tag;
            if (t.name != this.name)
                return false;
            return true;
        }

        public Tag(string s)
        {
            name = s;
            fileLocations = new List<string>();
        }

        public Tag() { }

    }
}
