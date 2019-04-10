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
        private readonly TbLocalizacaoBandejaRepository _TbLocalizacaoBandejaRepository;
        public LocalizacaoService(TbLocalizacaoContainerRepository tbLocalizacaoContainerRepository,TbLocalizacaoBandejaRepository tbLocalizacaoBandejaRepository)
        {
            _TbLocalizacaoContainerRepository = tbLocalizacaoContainerRepository;
            _TbLocalizacaoBandejaRepository = tbLocalizacaoBandejaRepository;
        }
        public async Task<IEnumerable<TbLocalizacaoContainer>> GetContainer()
        {
            IEnumerable<TbLocalizacaoContainer> containerList;

            containerList = await _TbLocalizacaoContainerRepository.GetLocalizacao();
            
            return containerList;
        }

        public async Task<IEnumerable<TbLocalizacaoBandeja>> GetBandeja()
        {
            IEnumerable<TbLocalizacaoBandeja> bandejaList;

            bandejaList = await _TbLocalizacaoBandejaRepository.GetLocalizacao();
            
            return bandejaList;
        }
    }
}