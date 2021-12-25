using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProje5.Models
{
    public class KullaniciBlog
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateTime tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }
        public int KisiID { get; set; }
        public virtual Kullanici Kisi { get; set; }
    }
}
