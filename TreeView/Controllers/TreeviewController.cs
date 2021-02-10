using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;
using Ubiety.Dns.Core;

namespace TreeView.Controllers
{
    public class TreeviewController : Controller
    {
        // GET: Treeview
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Simple()
        {
            List<Menu> all = new List<Menu>();
            using(MyDataEntities dc= new MyDataEntities())
            {
                //all = dc.Menu.OrderBy(a => a.ParentMenuID).ToList();
                all = dc.Menu.Where(a => a.ParentMenuID.Equals(0)).ToList();
            }
            return View(all);
        }
        public JsonResult Getsubmenu(string pid)
        {
            List<Menu> submenu = new List<Menu>();
            int pID = 0;
            int.TryParse(pid, out pID);
            using (MyDataEntities dc = new MyDataEntities())
            {
                submenu = dc.Menu.Where(a => a.ParentMenuID.Equals(pID)).OrderBy(a => a.MenuName).ToList();
            }
            return new JsonResult { Data = submenu, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public void Export()
        {
            using (MyDataEntities db = new MyDataEntities())
            {
                StringWriter client = new StringWriter();
                client.WriteLine("\"MenuID\",\"MenuName\",\"NaveURL\",\"ParentMenuID\"");
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachement;filename=TreeviewMenu{0}.txt", DateTime.Now));
                Response.ContentType = "text/txt";
                Response.ApplyAppPathModifier("D:/");
                var listMenu = db.Menu.OrderBy(x => x.MenuId);
                foreach (var news in listMenu)
                {
                    client.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                        news.MenuId, news.MenuName, news.NaveURL, news.ParentMenuID));
                }
                Response.Write(client.ToString());
                Response.End();
            }

        }
    }
    

}