using CoreInventario.Application.Models;
using CoreInventario.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreInventario.Application.Interfaces.Services
{

    public interface IEntradaService
    {
        Task<IEnumerable> GetAll();

        Task<Entrada> GetById(int id);

        Task<ResultProcess> Add(EntradaModel model);

        Task<string> Edit(EntradaModel model);

        Task<string> Delete(int id);

        //Task<string> SumarInventario(int ProductoId, int EntStock);
    }
}
