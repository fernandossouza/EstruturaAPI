using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EstruturaAPI.Models.Repository
{
    public class VwEstruturaBandejaHistRepository
    {
        private string stringConnection;
        private readonly IConfiguration _configuration;

        public VwEstruturaBandejaHistRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            stringConnection = _configuration.GetConnectionString("EstruturaConnection");
        }

        public async Task<IEnumerable<VwEstruturaBandejaHist>> GetEstrutura(string rfId)
        {
            IEnumerable<VwEstruturaBandejaHist> bandeja;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_VW_ESTRUTURA_BANDEJA_HIST] ";
            sSql = sSql + " WHERE [rfid] ='"+ rfId +"'";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                bandeja = await db.QueryAsync<VwEstruturaBandejaHist>(sSql);
            }
                return bandeja;
        }

        public async Task<IEnumerable<VwEstruturaBandejaHist>> GetEstruturaPorContainerHistId(long containerId)
        {
            IEnumerable<VwEstruturaBandejaHist> bandejaList;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_VW_ESTRUTURA_BANDEJA_HIST] ";
            sSql = sSql + " WHERE [containerHistId] = "+containerId;

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                bandejaList = await db.QueryAsync<VwEstruturaBandejaHist>(sSql);
            }
                return bandejaList;
        }
    }
}