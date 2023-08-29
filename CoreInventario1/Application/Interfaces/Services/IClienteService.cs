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
    public interface IClienteService
    {
        Task<IEnumerable> GetAll();

        Task<Cliente> GetById(int id);

        Task<string> Add(ClienteModel model);

        Task<string> Edit(ClienteModel model);

        Task<string> Delete(int id);
    }
}
