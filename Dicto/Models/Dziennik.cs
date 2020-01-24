using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Models
{
    public class Dziennik : BaseModel
    {
        public string Nazwa { get; set; }
        public string Rok { get; set; }
        public string IdTerapeuty { get; set; }
    }
}
