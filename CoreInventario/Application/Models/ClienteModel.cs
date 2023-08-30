using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }        
        public string CliCodigo { get; set; }
        public string CliTipo { get; set; }
        public string CliRazonSocial { get; set; }
        public string CliContacto { get; set; }
        public string CliTitulo { get; set; }
        public string CliDireccion { get; set; }
        public string CliTelefono1 { get; set; }
        public string CliTelefono2 { get; set; }
        public string CliCorreoE { get; set; }
        public int CliEstatus { get; set; }
    }
}
