using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPraticaUCDB.Models.Enums
{
    public enum OrderStatus : int
    {
        [Display(Name = "Válido")]
        Valid = 0,
        [Display(Name = "Vencimento próximo")]
        CloseExpiration = 1,
        [Display(Name = "Vencido")]
        Expired = 2
    }
}
