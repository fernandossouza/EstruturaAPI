using System;

namespace EstruturaAPI.Models
{
    public class VwEstruturaBandejaHist
    {
        public long id{get;set;}
        public string rfid{get;set;}
        public long loteId{get;set;}
        public string lote{get;set;}
        public long cloneId{get;set;}
        public string clone{get;set;}
        public string selecao{get;set;}
        public int qtdMudas{get;set;}
        public string arranjo{get;set;}
        public string classificacao{get;set;}
        public string responsavelEstaqueamento{get;set;}
        public DateTime dataEstaqueamento{get;set;}
        public int idade{get;set;}
        public long containerId{get;set;}
        public int ordem{get;set;}
        public DateTime data{get;set;}
    }
}