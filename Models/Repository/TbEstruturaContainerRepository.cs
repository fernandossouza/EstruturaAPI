using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EstruturaAPI.Models.Repository
{
    public class TbEstruturaContainerRepository
    {
        private string stringConnection;
        private readonly IConfiguration _configuration;

        public TbEstruturaContainerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            stringConnection = _configuration.GetConnectionString("EstruturaConnection");
        }

        public async Task<IEnumerable<TbEstruturaContainer>> GetEstrutura()
        {
            IEnumerable<TbEstruturaContainer> containerList;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_TB_ESTRUTURA_CONTAINER] ";
            // sSql = sSql + " WHERE [rfid] = '"+rfid+"'";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                containerList = await db.QueryAsync<TbEstruturaContainer>(sSql);
            }
                return containerList;
        }

        public async Task<TbEstruturaContainer> GetEstrutura(string rfid)
        {
            TbEstruturaContainer container;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_TB_ESTRUTURA_CONTAINER] ";
            sSql = sSql + " WHERE [rfid] = '"+rfid+"'";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                container = await db.QueryFirstOrDefaultAsync<TbEstruturaContainer>(sSql);
            }
                return container;
        }
    }
}