using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;

namespace EstruturaAPI.Service.Interface
{
    public interface IEstruturaHistService
    {
         Task<IEnumerable<VwEstruturaContainerHist>> GetContainer(string rfid);
         Task<IEnumerable<VwEstruturaBandejaHist>> GetBandeja(string rfid);
    }
}