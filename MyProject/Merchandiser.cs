using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    class Merchandiser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }
    }
}
