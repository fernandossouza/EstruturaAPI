using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;
using EstruturaAPI.Models.Repository;
using EstruturaAPI.Service.Interface;

namespace EstruturaAPI.Service
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private readonly TbLocalizacaoContainerRepository _TbLocalizacaoContainerRepository;
        public LocalizacaoService(TbLocalizacaoContainerRepository tbLocalizacaoContainerRepository)
        {
            _TbLocalizacaoContainerRepository = tbLocalizacaoContainerRepository;
        }
        public async Task<IEnumerable<TbLocalizacaoContainer>> GetContainer()
        {
            IEnumerable<TbLocalizacaoContainer> containerList;

            containerList = await _TbLocalizacaoContainerRepository.GetLocalizacao();
            
            return containerList;
        }
    }
}