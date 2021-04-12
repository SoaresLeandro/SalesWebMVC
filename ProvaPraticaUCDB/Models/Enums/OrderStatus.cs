using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaPraticaUCDB.Models.Enums
{
    public enum OrderStatus : int
    {
        Valid = 0,
        CloseExpiration = 1,
        Expired = 2
    }
}
