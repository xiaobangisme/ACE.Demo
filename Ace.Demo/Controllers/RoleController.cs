using Ace.Demo.Models;
using Ace.Demo.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ace.Demo.ViewModel;

namespace Ace.Demo.Controllers
{
    public class RoleController : Controller
    {

        public ActionResult Index()
        {
            using (DemoContext context = new DemoContext())
            {
                List<Role> list = context.Roles.ToList();
                return View(list);
            }
        }

        [HttpPost]
        public JsonResult GetData(string sidx, string sord, int page, int rows)
        {
            using (DemoContext context = new DemoContext())
            {

                JsonResult result = context.Roles.GetJson(sidx, sord, page, rows, JsonRequestBehavior.AllowGet, new string[] { "RoleID", "RoleName", "Description" });
                return result;
            }
        }

        public ActionResult Create()
        {
            return View(new RoleModel());
        }

        [HttpPost]
        public ActionResult Create(RoleModel model)
        {
            try
            {
                using (DemoContext context = new DemoContext())
                {
                    context.Roles.Add(new Role
                    {
                        Description = model.Description,
                        RoleName = model.RoleName
                    });
                    context.SaveChanges();
                }

                return Json(new { status = 1, msg = "成功！" });
            }
            catch (Exception e)
            {
                return Json(new { status = 0, msg = "失败！" });
            }
        }


        public ActionResult Edit(RoleModel model)
        {
            using (DemoContext context = new DemoContext())
            {
                Role item = context.Roles.FirstOrDefault(m => m.RoleID == model.RoleID);
                item.RoleName = model.RoleName;
                item.Description = model.Description;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save(RoleModel model)
        {
            try
            {
                switch (model.oper)
                {
                    case oper.add:
                        {
                            return RedirectToAction("Create", model);
                        }
                    case oper.edit:
                        {
                            return RedirectToAction("Edit", model);
                        }
                    case oper.del:
                        {
                            return RedirectToAction("Delete", new { RoleID = model.id });
                        }
                    default:
                        break;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? RoleID)
        {
            using (DemoContext context = new DemoContext())
            {
                Role item = context.Roles.FirstOrDefault(m => m.RoleID == RoleID);
                context.Roles.Remove(item);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
