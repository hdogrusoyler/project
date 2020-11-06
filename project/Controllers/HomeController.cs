using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var context = new dataContext();
            IEnumerable<category> list = context.Set<category>();

            return View(list.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            string password = "asdf1234";
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToLower();

            Guid g = Guid.NewGuid();
            //int g = 123456;

            dataContext context = new dataContext();
            context.Users.Add(new user() { email = "b@b.com", userName = "b", password = result, confirmCode = g.ToString() });
            context.SaveChanges();
            try
            {
                SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("info@dogrusoyler.com", "sifre84info");
                MailAddress from = new MailAddress("info@dogrusoyler.com", "Hüseyin");
                MailAddress to = new MailAddress("hdogrusoyler@outlook.com");
                MailMessage message = new MailMessage(from, to);

                message.Body = "body" + g;
                message.IsBodyHtml = true;
                message.Subject = "subject";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public PartialViewResult Menu()
        {
            var context = new dataContext();
            //List<RoleValue> roleValues = (List<RoleValue>)Session["MagentyRoleValues"];
            //List<RoleValue> menuList = new List<RoleValue>();
            //menuList = roleValues.Where(x => x.MenuOrAction == "M" && x.IsPermission == true).ToList();
            //return PartialView("_Menu", menuList);

            List<category> categoryList = new List<category>();
            categoryList = context.Set<category>().ToList();

            //List<List<category>> orderedList = new List<List<category>>();

            //foreach (var item in categoryList)
            //{
            //    List<category> itemCat = new List<category>();

            //    if (item.topCategoryId == 0)
            //    {
            //        itemCat.Add(item);
            //        foreach (var itemList in categoryList)
            //        {
            //            if (item.id == itemList.topCategoryId)
            //            {
            //                itemCat.Add(itemList);
            //            }
            //        }
            //    }



            //    orderedList.Add(itemCat);
            //}

            

            return PartialView("_Menu", categoryList);
        }

    }
}