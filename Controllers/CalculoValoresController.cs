using PDVDesafioTOTVS.Web.DataAccessLayer;
using PDVDesafioTOTVS.Web.NHibernateMappingFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDVDesafioTOTVS.Web.Controllers
{
    public class CalculoValoresController : Controller
    {
        //private readonly ITrocoDisponivelDAO _TrocoDisponivelDAO;
        private readonly ITransacaoFinanceiraDAO _TransacaoFinanceiraDAO;

        public CalculoValoresController()
        {
            //_TrocoDisponivelDAO = new TrocoDisponivelDaoImpl();
            _TransacaoFinanceiraDAO = new TransacaoFinanceiraDAOImpl();
        }
        //public JsonResult GetTrocos()
        //{
        //    List<Troco> trocos = _TrocoDisponivelDAO.GetAll();
        //    return Json(trocos, JsonRequestBehavior.AllowGet);
        //}
        // GET: CalculoValores
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SalvarTransacaoFinanceira(TransacaoFinanceiraImpl obj)
        {
            try
            {
                obj = _TransacaoFinanceiraDAO.Create(obj);

                return Json(obj.IdTransacao);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}