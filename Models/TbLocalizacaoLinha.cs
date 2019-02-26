namespace EstruturaAPI.Models
{
    public class TbLocalizacaoLinha
    {
        public long id{get;set;}
        public string nome{get;set;}
        public long areaId{get;set;}
        public TbLocalizacaoArea area{get;set;}
    }
}