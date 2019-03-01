using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;

namespace EstruturaAPI.Service.Interface
{
    public interface IEstruturaService
    {
         Task<IEnumerable<TbEstruturaContainer>> GetContainerAll();
         Task<TbEstruturaContainer> GetContainer(string rfid);
         Task<TbEstruturaBandeja> GetBandeja(string rfid);
         Task<IEnumerable<TbEstruturaBandeja>> GetBandejaListPorContainer(long containerId);
    }
}