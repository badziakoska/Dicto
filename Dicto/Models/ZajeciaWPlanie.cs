using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Models
{
    public class ZajeciaWPlanie : BaseModel
    {
        public int DzienTygodnia { get; set; }
        public DateTime GodzinaRozpoczecia { get; set; }
        public DateTime GodzinaZakonczenia { get; set; }
        public string IdDziennika { get; set; }
        public string IdGrupy { get; set; }
        public string IdUcznia { get; set; }
    }
}
