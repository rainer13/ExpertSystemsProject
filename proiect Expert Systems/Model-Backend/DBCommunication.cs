using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;


namespace proiect_Expert_Systems.Model_Backend
{
    class DBCommunication : DbContext
    {


        public DBCommunication() : base(@"Server=ISS27\SQLEXPRESS; Database=dbForESPrj; User Id=sa; Password=unu") { }

        public static void startUp(){
            //Debug.Write(Database.Connection.ConnectionString);



        }


        public DbSet<File> files { get; set; }
        public DbSet<Tag> tags { get; set; }
    }
}
