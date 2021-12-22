using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje5.Models
{
    public class Kullanici
    {
        [Key]
        public int ID { get; set; }
        public string kullanici_adi { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public ICollection<Blog> Blogs { get; set; }

    }
}
