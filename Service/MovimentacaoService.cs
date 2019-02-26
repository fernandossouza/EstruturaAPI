using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstruturaAPI.Models;
using EstruturaAPI.Models.Repository;
using EstruturaAPI.Service.Interface;

namespace EstruturaAPI.Service
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly TbMovimentacaoCadastroRepository _TbMovimentacaoCadastroRepository;
        public MovimentacaoService(TbMovimentacaoCadastroRepository tbMovimentacaoCadastroRepository)
        {
            _TbMovimentacaoCadastroRepository = tbMovimentacaoCadastroRepository;
        }

        public async Task<IEnumerable<TbMovimentacaoCadastro>> GetMovimentacao()
        {
            IEnumerable<TbMovimentacaoCadastro> movimentacaoList;

            movimentacaoList = await _TbMovimentacaoCadastroRepository.GetMovimentacao();
            
            return movimentacaoList;
        }

        public async Task<TbMovimentacaoCadastro> PostMovimentacao(TbMovimentacaoCadastro movimentacao)
        {
            movimentacao.dataCriacao = DateTime.Now;
            movimentacao.flagMigrado = false;
            movimentacao.flagConcluido = false;

            movimentacao = await _TbMovimentacaoCadastroRepository.InserirMovimentacao(movimentacao);

            if(movimentacao == null)
            throw new System.Exception("erro ao tentar inserir o registro no banco de dados");

            return movimentacao;
        }
    }
}