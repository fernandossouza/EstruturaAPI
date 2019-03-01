using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;
using EstruturaAPI.Models.Repository;
using EstruturaAPI.Service.Interface;

namespace EstruturaAPI.Service
{
    public class EstruturaService : IEstruturaService
    {
        private readonly TbEstruturaContainerRepository _TbEstruturaContainerRepository;
        private readonly TbEstruturaBandejaRepository _TbEstruturaBandejaRepository;
        public EstruturaService(TbEstruturaContainerRepository tbEstruturaContainerRepository,TbEstruturaBandejaRepository tbEstruturaBandejaRepository)
        {
            _TbEstruturaContainerRepository = tbEstruturaContainerRepository;
            _TbEstruturaBandejaRepository = tbEstruturaBandejaRepository;
        }

        public async Task<IEnumerable<TbEstruturaContainer>> GetContainerAll()
        {
            IEnumerable<TbEstruturaContainer> containerList;

            containerList = await _TbEstruturaContainerRepository.GetEstrutura();

            return containerList;
        }

        public async Task<TbEstruturaBandeja> GetBandeja(string rfid)
        {
            if(string.IsNullOrWhiteSpace(rfid))
                throw new Exception("RFID está em branco");

            TbEstruturaBandeja bandeja;

            bandeja = await _TbEstruturaBandejaRepository.GetEstrutura(rfid);

            return bandeja;
        }

        public async Task<IEnumerable<TbEstruturaBandeja>> GetBandejaListPorContainer(long containerId)
        {
             if(containerId <= 0)
                throw new Exception("Id do container menor ou igual a 0");

            IEnumerable<TbEstruturaBandeja> bandejaList;

            bandejaList = await _TbEstruturaBandejaRepository.GetEstruturaPorContainerId(containerId);

            return bandejaList;
        }

        public async Task<TbEstruturaContainer> GetContainer(string rfid)
        {
            if(string.IsNullOrWhiteSpace(rfid))
                throw new Exception("RFID está em branco");
            TbEstruturaContainer container;

            container = await _TbEstruturaContainerRepository.GetEstrutura(rfid);

            if(container != null)
                container.bandejas =  await GetBandejaListPorContainer(container.id);

            return container;
        }

        public async Task<IEnumerable<TbEstruturaBandeja>> GetBandejaAll()
        {
            IEnumerable<TbEstruturaBandeja> bandejaList;

            bandejaList = await _TbEstruturaBandejaRepository.GetEstruturaAll();

            return bandejaList;
        }
    }
}