using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Specialty.Domain.Models;
using Specialty.Domain.Repository;
using Specialty.Web.Models;

namespace Specialty.Web.Controllers
{
    public class SpecialtyApplicationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDirectChildren(int nodeId)
        {
            return Json(TreeHandler.GetDirectChildren(nodeId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGrandestChildren(int nodeId)
        {
            return Json(TreeHandler.GetGrandestChildren(nodeId), JsonRequestBehavior.AllowGet);
        }
    }
}