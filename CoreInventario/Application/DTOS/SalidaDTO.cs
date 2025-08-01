﻿using CoreInventario.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.DTOS
{
    public class SalidaDTO
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }          // Id producto
        public string PrdCodigo { get; set; }   // Cód producto
        public string Nombre { get; set; }      // Nombre producto
        public Decimal Precio { get; set; }     // Precio producto de salida
        public int Cantidad { get; set; }      // Cantidad producto
        public string Fecha { get; set; }       // Fecha de salida
        public int Estatus { get; set; }        // Estatus 0 Inicial / 1 procesado
        public EntSalEstatusEnum salidaEstatus { get; set; }

    }
}
