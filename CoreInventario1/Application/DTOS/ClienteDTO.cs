using CoreInventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.DTOS
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string CliCodigo { get; set; }
        public string CliRazonSocial { get; set; }
        public string CliContacto { get; set; }
        public int CliEstatus { get; set; }
        public ClienteEstatusEnum clienteEstatus { get; set; }
    }
}
