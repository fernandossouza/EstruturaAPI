using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;
using EstruturaAPI.Models.Repository;
using EstruturaAPI.Service.Interface;

namespace EstruturaAPI.Service
{
    public class EstruturaHistService : IEstruturaHistService
    {
        private readonly VwEstruturaContainerHistRepository _VwEstruturaContainerHistRepository;
        private readonly VwEstruturaBandejaHistRepository _VwEstruturaBandejaHistRepository;
        public EstruturaHistService(VwEstruturaContainerHistRepository vwEstruturaContainerHistRepository,VwEstruturaBandejaHistRepository vwEstruturaBandejaHistRepository)
        {
            _VwEstruturaContainerHistRepository = vwEstruturaContainerHistRepository;
            _VwEstruturaBandejaHistRepository = vwEstruturaBandejaHistRepository;
        }
        public async Task<IEnumerable<VwEstruturaBandejaHist>> GetBandeja(string rfid)
        {
            if(string.IsNullOrWhiteSpace(rfid))
                throw new Exception("RFID está em branco");

            IEnumerable<VwEstruturaBandejaHist> bandeja;

            bandeja = await _VwEstruturaBandejaHistRepository.GetEstrutura(rfid);

            return bandeja;
        }

        public async Task<IEnumerable<VwEstruturaContainerHist>> GetContainer(string rfid)
        {
            if(string.IsNullOrWhiteSpace(rfid))
                throw new Exception("RFID está em branco");

            IEnumerable<VwEstruturaContainerHist> containerList;

            containerList = await _VwEstruturaContainerHistRepository.GetEstrutura(rfid);

            foreach(var container in containerList)
            {
                container.bandejas = await _VwEstruturaBandejaHistRepository.GetEstruturaPorContainerHistId(container.id);
            }

            return containerList;
        }
    }
}