﻿using CoreInventario.Application.DTOS;
using CoreInventario.Application.Interfaces.Repositories;
using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using CoreInventario.Domain.Enums;
using CoreInventario.Domain.Helpers;
using CoreInventario.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ProveedorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProveedorDTO> GetAll()
        {
            var lista = context.Proveedor.Select(c => new ProveedorDTO
            {
                Id = c.Id,
                PrvCodigo = c.PrvCodigo,
                PrvNombreCompania = c.PrvNombreCompania,
                PrvContacto = c.PrvContacto,
                PrvEstatus = c.PrvEstatus,
                proveedorEstatus = (ProveedorEstatusEnum)c.PrvEstatus

            }).ToList();

            return lista;
        }

        public Proveedor GetByID(int id)
        {
            return context.Proveedor.FromSqlRaw($"SELECT * FROM Proveedor WHERE Id = {id}")
                .FirstOrDefault();
        }

        public IEnumerable<ProveedorModel> GetAllByStatus(int status)
        {
            //return context.Proveedor.FromSqlRaw($"SELECT * FROM Proveedor WHERE PrvEstatus = {status}");
                //.FirstOrDefault();

            //var list = context.Proveedor.FromSqlRaw($"SELECT * FROM Proveedor WHERE PrvEstatus = {status}").ToList();

            //var lista = context.Proveedor.ToList().Where(c=>c.PrvEstatus == status);
            //return (IEnumerable<ProveedorModel>)lista;


            var lista = context.Proveedor.Select(c => new ProveedorModel
            {
                Id = c.Id,
                PrvCodigo = c.PrvCodigo,
                PrvNombreCompania = c.PrvNombreCompania,
                PrvContacto = c.PrvContacto,
                PrvEstatus = c.PrvEstatus,
                PrvCiudad = c.PrvCiudad,
                PrvCodigoPostal = c.PrvCodigoPostal,
                PrvCorreoE1 = c.PrvCorreoE1,
                PrvCorreoE2 = c.PrvCorreoE2,
                PrvDireccion = c.PrvDireccion,
                PrvPagWeb = c.PrvPagWeb,
                PrvRedSocial1 = c.PrvRedSocial1,
                PrvRedSocial2 = c.PrvRedSocial2,
                PrvTelefono1 = c.PrvTelefono1,
                PrvTelefono2 = c.PrvTelefono2,
                PrvTelefono3 = c.PrvTelefono3,
                PrvRegion=c.PrvRegion,
                PrvTituloContacto=c.PrvContacto

            }).ToList().Where(c => c.PrvEstatus == status);

            return lista;

        }

        public async Task Add(Proveedor proveedor)
        {
            context.Proveedor.Add(proveedor);
        }

        public async Task Delete(int id)
        {
            Proveedor proveedor = context.Proveedor.Find(id);
            context.Proveedor.Remove(proveedor);
        }

        public async Task Update(Proveedor proveedor)
        {
            context.Entry(proveedor).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Extraer el titulo del enum
        /// </summary>
        /// <param name="estatId"></param>
        /// <returns></returns>
        static string DescribEstatus(Enum estatId)
        {
            return EnumHelper.GetDescriptionFromEnumValue(estatId);
        }
    }
}
