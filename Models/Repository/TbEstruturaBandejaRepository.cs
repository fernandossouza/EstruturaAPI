using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EstruturaAPI.Models.Repository
{
    public class TbEstruturaBandejaRepository
    {
        private string stringConnection;
        private readonly IConfiguration _configuration;

        public TbEstruturaBandejaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            stringConnection = _configuration.GetConnectionString("EstruturaConnection");
        }

        public async Task<TbEstruturaBandeja> GetEstrutura(string rfid)
        {
            TbEstruturaBandeja bandeja;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_TB_ESTRUTURA_BANDEJA] ";
            sSql = sSql + " WHERE [rfid] = '"+rfid+"'";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                bandeja = await db.QueryFirstOrDefaultAsync<TbEstruturaBandeja>(sSql);
            }
                return bandeja;
        }

        public async Task<IEnumerable<TbEstruturaBandeja>> GetEstruturaPorContainerId(long containerId)
        {
            IEnumerable<TbEstruturaBandeja> bandejaList;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_TB_ESTRUTURA_BANDEJA] ";
            sSql = sSql + " WHERE [containerId] = "+containerId;

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                bandejaList = await db.QueryAsync<TbEstruturaBandeja>(sSql);
            }
                return bandejaList;
        }
    }
}