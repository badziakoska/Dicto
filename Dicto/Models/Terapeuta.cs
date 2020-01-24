using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Models
{
    public class Terapeuta : BaseModel
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
    }
}
