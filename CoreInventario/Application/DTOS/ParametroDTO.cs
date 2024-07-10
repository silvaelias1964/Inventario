using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.DTOS
{
    public class ParametroDTO
    {
        public int Id {  get; set; }

        public string Nombre { get; set; }

        public string Valor { get; set; }

        public string Tipo { get; set; }
    }
}
