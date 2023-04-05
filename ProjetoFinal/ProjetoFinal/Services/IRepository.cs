using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoFinal.Services
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> ListarPedidosPreparando();

        Task<string> AlterarPedidoParaEntregue(Guid id);
    }
}
