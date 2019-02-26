using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EstruturaAPI.Models.Repository
{
    public class TbLocalizacaoContainerRepository
    {
        private string stringConnection;
        private readonly IConfiguration _configuration;

        public TbLocalizacaoContainerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            stringConnection = _configuration.GetConnectionString("EstruturaConnection");
        }

        public async Task<IEnumerable<TbLocalizacaoContainer>> GetLocalizacao()
        {
            IEnumerable<TbLocalizacaoContainer> containerList;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_TB_LOCALIZACAO_CONTAINER] AS C";
            sSql = sSql + " LEFT JOIN [SPI_TB_LOCALIZACAO_LINHA] AS L ON L.id = C.linhaId";
            sSql = sSql + " LEFT JOIN [SPI_TB_LOCALIZACAO_AREA] AS A ON A.id = L.areaId";
            sSql = sSql + " LEFT JOIN [SPI_TB_LOCALIZACAO_STATUS] AS S ON S.id = C.statusId";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                var lookup = new Dictionary<long,TbLocalizacaoContainer>();
                db.Query<TbLocalizacaoContainer,TbLocalizacaoLinha,TbLocalizacaoArea,TbLocalizacaoStatus,TbLocalizacaoContainer>(sSql,(c,l,a,s) =>
                {
                TbLocalizacaoContainer oContainer;
                if (!lookup.TryGetValue(c.id, out oContainer)) {
                         lookup.Add(c.id, oContainer = c);
                    }
                    if (oContainer.linha == null) 
                         oContainer.linha = new TbLocalizacaoLinha();
                    oContainer.linha = l;

                    if (l.area == null) 
                         l.area = new TbLocalizacaoArea();
                    l.area = a;  

                    if (oContainer.status == null) 
                         oContainer.status = new TbLocalizacaoStatus();
                    oContainer.status = s;               

                     return oContainer;

                 }).AsQueryable();
                 containerList = lookup.Values;
            }

            if(containerList == null || containerList.Count()==0)
                return null;
            else
                return containerList;
        }
    }
}