using System;
using System.ComponentModel.DataAnnotations;

namespace EstruturaAPI.Models
{
    public class TbMovimentacaoCadastro
    {
        public long id{get;set;}
        [Required]
        public string rfid{get;set;}
        [Required]
        public long origemId{get;set;}
        [Required]
        public long destinoId{get;set;}
        [Required]
        public long rotaId{get;set;}
        [Required]
        public string rotaNome{get;set;}
        [Required]
        public long statusId{get;set;}
        [Required]
        public DateTime dataAgendamento{get;set;}
        public DateTime? dataExecucao{get;set;}
        [Required]
        public long usuarioId{get;set;}
        [Required]
        public string usuarioNome{get;set;}
        public bool flagMigrado{get;set;}
        public bool flagConcluido{get;set;}
        public DateTime dataCriacao{get;set;}
    }
}