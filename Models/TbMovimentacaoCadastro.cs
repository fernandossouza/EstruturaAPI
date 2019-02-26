using System;

namespace EstruturaAPI.Models
{
    public class TbMovimentacaoCadastro
    {
        public long id{get;set;}
        public string rfid{get;set;}
        public long origemId{get;set;}
        public long destinoId{get;set;}
        public long rotaId{get;set;}
        public string rotaNome{get;set;}
        public long statusId{get;set;}
        public DateTime dataAgendamento{get;set;}
        public DateTime? dataExecucao{get;set;}
        public long usuarioId{get;set;}
        public string usuarioNome{get;set;}
        public bool flagMigrado{get;set;}
        public bool flagConcluido{get;set;}
        public DateTime dataCriacao{get;set;}
    }
}