using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEducation
{
    public class Ogrenciler
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }       
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Index(IsUnique = true)]
        [Column("AMk")]
        public string OgrenciNo { get; set; }
    }
}
