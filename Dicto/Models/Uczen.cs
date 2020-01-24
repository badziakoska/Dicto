using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dicto.Enums;

namespace Dicto.Models
{
    public class Uczen : BaseModel
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string IdGrupy { get; set; }
        public string IdDziennika { get; set; }
        public Diagnoza Diagnoza { get; set; }
        public string OpisWady { get; set; }
        public string PlanPracy { get; set; }
        public string Uwagi { get; set; }
    }
}
