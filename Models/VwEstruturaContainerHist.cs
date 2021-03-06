using System;
using System.Collections.Generic;

namespace EstruturaAPI.Models
{
    public class VwEstruturaContainerHist
    {
        public long id{get;set;}
        public string rfid{get;set;}
        public long loteId{get;set;}
        public string lote{get;set;}
        public long cloneId{get;set;}
        public string clone{get;set;}
        public DateTime dataEstaqueamento{get;set;}
        public int idade{get;set;}
        public string selecao{get;set;}
        public string classificacao{get;set;}
        public int qtdBandejas{get;set;}
        public int qtdMudas{get;set;}
        public IEnumerable<VwEstruturaBandejaHist> bandejas{get;set;}
        public DateTime data{get;set;}
    }
}