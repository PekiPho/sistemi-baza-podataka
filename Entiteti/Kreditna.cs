﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proejkt.Entiteti
{
    public class Kreditna:Kartica
    {
        public virtual int MaxPeriodOtplate { get; set; }

        public virtual decimal MesecniLimit { get; set; }
    }
}
