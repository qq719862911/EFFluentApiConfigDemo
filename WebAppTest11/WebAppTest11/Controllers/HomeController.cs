using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTest11.Models.Home;

namespace WebAppTest11.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //List<SelectListItem> personList = new List<SelectListItem>();
            //for (int i = 0; i < 30; i++)
            //{
            //    SelectListItem person = new SelectListItem();
            //    person.Text = "person" + i;
            //    person.Value = i.ToString();
            //    if (i==5)
            //    {
            //        person.Group = new SelectListGroup() { Disabled=false,Name="组1"};
            //        person.Selected = true;
            //    }
            //    personList.Add(person);
            //}
            //ViewData["personList"] = personList;

            List<PersonViewModel> personList = new List<PersonViewModel>();
            for (int i = 0; i < 30; i++)
            {
                PersonViewModel person = new PersonViewModel();
                person.Id = i;
                person.Name = "person" + i;
                person.IsMale = false;
                if (i == 5)
                {
                    person.IsMale = true;
                }
                personList.Add(person);
            }
            SelectList list = new SelectList(personList, "Id", "Name");
            return View(list);
        }
         
        public FilePathResult GetPic()
        {
            return File("/2.jpg", "application/x-jpg", "图片");
        }

        public ActionResult ToBaidu()
        {
            return Redirect("/Home/GetPic");
        }

        public ActionResult GetVerifyCode()
        {
            var code = new Random().Next().ToString();
            //Session["verifyCode"] = code;
            TempData.Add("verifyCode", code);
            return Content("验证码已经发送" + code);
        }

        public ActionResult CheckVerifyCode()
        {
            //   string code = (string)Session["verifyCode"];
            // Session["verifyCode"] = null;
            object code;
            TempData.TryGetValue("verifyCode", out code);
            if (code != null)
            {
                return Content((string)code);
            }
            else
            {
                return Content("Error");
            }
        }

        public ActionResult TestAction()
        {
            Uri url = HttpContext.Request.Url;
            //HttpContext.Response.SetCookie()
            return Content(" AbsolutePath:" + url.AbsolutePath + "   AbsoluteUri:" + url.AbsoluteUri);
        }

    }
}