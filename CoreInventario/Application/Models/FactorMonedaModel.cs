﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class FactorMonedaModel
    {
        public string currency { get; set; }
        public decimal exchange { get; set; }
        public string date { get; set; }
    }
}
