using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;

namespace EstruturaAPI.Service.Interface
{
    public interface ILocalizacaoService
    {
         Task<IEnumerable<TbLocalizacaoContainer>> GetContainer();
         Task<IEnumerable<TbLocalizacaoBandeja>> GetBandeja();
    }
}