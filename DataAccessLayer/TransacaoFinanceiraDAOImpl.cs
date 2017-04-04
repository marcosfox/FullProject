using NHibernate;
using PDVDesafioTOTVS.Web.NHibernateMappingFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDVDesafioTOTVS.Web.DataAccessLayer
{
    public class TransacaoFinanceiraDAOImpl : DAOProviderBase<TransacaoFinanceiraImpl, long>,
                                        ITransacaoFinanceiraDAO
    {
        public List<TransacaoFinanceira> GetAll()
        {
            ICriteria stateBuscaTroco = base.CurrentNhibernateSession.CreateCriteria(typeof(TransacaoFinanceira));

            //stateBuscaTroco.SetProjection();

            return stateBuscaTroco.List().Cast<TransacaoFinanceira>().ToList();

            //return list.Cast<Troco>().ToList();
        }
        public TransacaoFinanceiraImpl Create(TransacaoFinanceiraImpl obj)
        {
            try
            {
                using (ITransaction trans = base.CurrentNhibernateSession.BeginTransaction())
                {
                    base.CurrentNhibernateSession.SaveOrUpdate(obj);

                    trans.Commit();
                }
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}