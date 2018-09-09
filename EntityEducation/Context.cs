using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEducation
{
    public class OgrencilerContext :DbContext
    {
        // AppConfig deki Yazdıgım bağlantı ismini Yazdım..
        public OgrencilerContext() : base("ozz")

        {


        }


        // Db Tablo oluşturuyorum.
        public DbSet<Ogrenciler> tablo { get; set; }

    }
}
