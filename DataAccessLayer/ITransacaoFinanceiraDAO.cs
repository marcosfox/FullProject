using PDVDesafioTOTVS.Web.NHibernateMappingFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDVDesafioTOTVS.Web.DataAccessLayer
{
    public interface ITransacaoFinanceiraDAO
    {
        List<TransacaoFinanceira> GetAll();
        TransacaoFinanceiraImpl Create(TransacaoFinanceiraImpl obj);
    }
}