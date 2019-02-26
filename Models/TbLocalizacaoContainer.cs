namespace EstruturaAPI.Models
{
    public class TbLocalizacaoContainer
    {
        public long id{get;set;}
        public string rfid{get;set;}
        public int posicaoX{get;set;}
        public int posicaoY{get;set;}
        public long loteId{get;set;}
        public string lote{get;set;}
        public long statusId{get;set;}
        public TbLocalizacaoStatus status{get;set;}
        public string cor{get;set;}
        public long cloneId{get;set;}
        public string clone{get;set;}
        public long linhaId{get;set;} 
        public TbLocalizacaoLinha linha{get;set;}
    }
}