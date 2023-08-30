using CoreInventario.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Services
{
    /// <summary>
    /// Class to configure string connection
    /// </summary>
    public class DataBaseConfiguration : IDataBaseConfiguration
    {
        public string Connection { get; set; }
    }
}
