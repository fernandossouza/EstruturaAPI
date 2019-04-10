using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EstruturaAPI.Models.Repository
{
    public class TbLocalizacaoBandejaRepository
    {
        private string stringConnection;
        private readonly IConfiguration _configuration;

        public TbLocalizacaoBandejaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            stringConnection = _configuration.GetConnectionString("EstruturaConnection");
        }

        public async Task<IEnumerable<TbLocalizacaoBandeja>> GetLocalizacao()
        {
            IEnumerable<TbLocalizacaoBandeja> bandejaList;
            string sSql = string.Empty;
            sSql = "SELECT * ";
            sSql = sSql + " FROM [SPI_TB_LOCALIZACAO_BANDEJA] AS C";
            sSql = sSql + " LEFT JOIN [SPI_TB_LOCALIZACAO_LINHA] AS L ON L.id = C.linhaId";
            sSql = sSql + " LEFT JOIN [SPI_TB_LOCALIZACAO_AREA] AS A ON A.id = L.areaId";
            sSql = sSql + " LEFT JOIN [SPI_TB_LOCALIZACAO_STATUS] AS S ON S.id = C.statusId";
            sSql = sSql + " WHERE C.RFID IS NOT NULL";

            
            using(IDbConnection db = new SqlConnection(stringConnection)){                
               
                var lookup = new Dictionary<long,TbLocalizacaoBandeja>();
                db.Query<TbLocalizacaoBandeja,TbLocalizacaoLinha,TbLocalizacaoArea,TbLocalizacaoStatus,TbLocalizacaoBandeja>(sSql,(c,l,a,s) =>
                {
                TbLocalizacaoBandeja oBandeja;
                if (!lookup.TryGetValue(c.id, out oBandeja)) {
                         lookup.Add(c.id, oBandeja = c);
                    }
                    if (oBandeja.linha == null) 
                         oBandeja.linha = new TbLocalizacaoLinha();
                    oBandeja.linha = l;

                    if (l.area == null) 
                         l.area = new TbLocalizacaoArea();
                    l.area = a;  

                    if (oBandeja.status == null) 
                         oBandeja.status = new TbLocalizacaoStatus();
                    oBandeja.status = s;               

                     return oBandeja;

                 }).AsQueryable();
                 bandejaList = lookup.Values;
            }

            if(bandejaList == null || bandejaList.Count()==0)
                return null;
            else
                return bandejaList;
        }
    }
}