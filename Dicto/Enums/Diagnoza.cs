using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dicto.Enums
{
    public enum Diagnoza
    {
        Sygmatyzm = 1,
        Rotacyzm,
        Kappacyzm,
        Gammacyzm,
        Lambdacyzm,
        Betacyzm,
        [Display(Name = "Mowa bezdźwięczna")]
        Bezdzwięczna,
        Rynolalia,
        Palatolalia,
        [Display(Name = "Opóźniony rozwój mowy")]
        ORM,
        Inne

    }
}
