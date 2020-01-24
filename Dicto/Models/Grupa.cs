using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Models
{
    public class Grupa : BaseModel
    {
        public string Nazwa { get; set; }
        public string PlanPracy { get; set; }
        public string IdDziennika { get; set; }
    }
}
