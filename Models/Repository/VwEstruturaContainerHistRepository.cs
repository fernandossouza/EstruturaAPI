using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EstruturaAPI.Models.Repository
{
    public class VwEstruturaContainerHistRepository
    {
        private string stringConnection;
        private readonly IConfiguration _configuration;

        public VwEstruturaContainerHistRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            stringConnection = _configuration.GetConnectionString("EstruturaConnection");
        }

        public async Task<IEnumerable<VwEstruturaContainerHist>> GetEstrutura(string rfid)
        {
            IEnumerable<VwEstruturaContainerHist> container;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_VW_ESTRUTURA_CONTAINER_HIST] ";
            sSql = sSql + " WHERE [rfid] = '"+rfid+"'";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                container = await db.QueryAsync<VwEstruturaContainerHist>(sSql);
            }
                return container;
        }

    }
}