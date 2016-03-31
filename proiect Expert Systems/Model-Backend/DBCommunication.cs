using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proiect_Expert_Systems.Model_Backend
{
    class DBCommunication : DbContext
    {

        public DBCommunication() : base("DefaultConnection") { }


        public DbSet<File> files;
        public DbSet<Tag> tags;
    }
}
