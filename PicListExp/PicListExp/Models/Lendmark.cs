using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PicListExp.Models
{
    
    public class Landmark
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public int Category { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Uploaded { get; set; }

    }
}
