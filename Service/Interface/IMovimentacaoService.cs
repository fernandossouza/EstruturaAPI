using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;

namespace EstruturaAPI.Service.Interface
{
    public interface IMovimentacaoService
    {
        Task<IEnumerable<TbMovimentacaoCadastro>> GetMovimentacao();
        Task<TbMovimentacaoCadastro> PostMovimentacao(TbMovimentacaoCadastro movimentacao);
    }
}