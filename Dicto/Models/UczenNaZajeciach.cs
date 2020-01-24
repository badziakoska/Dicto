using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Models
{
    public class UczenNaZajeciach : BaseModel
    {
        public string IdUcznia { get; set; }
        public string IdZajec { get; set; }
        public bool Obecnosc { get; set; }
        public string PostepUcznia { get; set; }
    }
}
