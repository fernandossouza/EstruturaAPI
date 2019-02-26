using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EstruturaAPI.Models.Repository
{
    public class TbMovimentacaoCadastroRepository
    {
        private string stringConnection;
        private readonly IConfiguration _configuration;

        public TbMovimentacaoCadastroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            stringConnection = _configuration.GetConnectionString("EstruturaConnection");
        }

        public async Task<IEnumerable<TbMovimentacaoCadastro>> GetMovimentacao()
        {
            IEnumerable<TbMovimentacaoCadastro> movimentacaoList;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_TB_MOVIMENTACAO_CADASTRO] ";
            sSql = sSql + " ORDER BY [dataCriacao] DESC ";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                movimentacaoList = await db.QueryAsync<TbMovimentacaoCadastro>(sSql);
            }
                return movimentacaoList;
        }

        public async Task<TbMovimentacaoCadastro> InserirMovimentacao(TbMovimentacaoCadastro movimentacao)
        {
            IEnumerable<long> insertRow;
            string sSql = string.Empty;
            sSql = "INSERT INTO [SPI_TB_MOVIMENTACAO_CADASTRO]([rfid],[origemId],[destinoId],[rotaId],[rotaNome],[statusId] ";
            sSql = sSql + " ,[dataAgendamento],[dataExecucao],[usuarioId],[usuarioNome],[flagMigrado],[flagConcluido],[dataCriacao]) ";
            sSql = sSql + " VALUES (@rfid,@origemId,@destinoId,@rotaId,@rotaNome,@statusId,@dataAgendamento,@dataExecucao ";
            sSql = sSql + " ,@usuarioId,@usuarioNome,@flagMigrado,@flagConcluido,@dataCriacao) ";
            sSql = sSql + " SELECT @@IDENTITY ";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                insertRow = await db.QueryAsync<long>(sSql,movimentacao);
            }

            if(insertRow == null || insertRow.Count() == 0)
                return null;

            movimentacao.id = insertRow.FirstOrDefault();

            return movimentacao;
        }


    }
}