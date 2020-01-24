using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Models
{
    public class Zajecia : BaseModel
    {
        public string IdZajecZPlanu { get; set; }
        public DateTime Data { get; set; }
        public string Temat { get; set; }
        public string Scenariusz { get; set; }
    }
}
