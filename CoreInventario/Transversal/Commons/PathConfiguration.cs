using CoreInventario.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Transversal.Commons
{    
    /// <summary>
    /// Class to configure path directory
    /// </summary>
    public class PathConfiguration : IPathConfiguration
    {
        public string PathAvatar { get; set; }
        public string PathProductos { get; set; }
    }

}
