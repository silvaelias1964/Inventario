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

    public interface ISalidaService
    {
        Task<IEnumerable> GetAll();

        Task<Salida> GetById(int id);

        Task<ResultProcess> Add(SalidaModel model);

        Task<string> Edit(SalidaModel model);

        Task<string> Delete(int id);

        //Task<string> SumarInventario(int ProductoId, int EntStock);
    }
}
