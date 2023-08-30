using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Services
{
    /// <summary>
    /// Interface to configure string connection data base.
    /// </summary>
    public interface IDataBaseConfiguration
    {
        string Connection { get; set; }
    }
}
