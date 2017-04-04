using NHibernate;
using PDVDesafioTOTVS.Web.NHibernateHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVDesafioTOTVS.Web.DataAccessLayer
{
    public abstract class DAOProviderBase<T, V> : IDAOProvider<T, V> where T : new()
                                                        where V : struct
    {
        protected readonly ISession CurrentNhibernateSession;

        protected DAOProviderBase()
        {
            CurrentNhibernateSession = PDVDesafioTOTVS.MvcApplication.NHibernateSessionFactory.GetCurrentSession();
        }
        public T Create(T t)
        {
            try
            {
                using (ITransaction trans = this.CurrentNhibernateSession.BeginTransaction())
                {
                    this.CurrentNhibernateSession.Save(t);

                    trans.Commit();
                }
                return t;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T[] GetAll<T>()
        {
            try
            {
                var icriteria = this.CurrentNhibernateSession.CreateCriteria(typeof(T));

                return icriteria.List<T>().ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetObjectById(V v)
        {
            return (T)this.CurrentNhibernateSession.Load(typeof(T), v);
        }

        public void Update(T t)
        {
            try
            {
                using (ITransaction trans = this.CurrentNhibernateSession.BeginTransaction())
                {
                    this.CurrentNhibernateSession.SaveOrUpdate(t);

                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
