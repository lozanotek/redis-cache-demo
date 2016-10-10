using System;
using System.Web.Mvc;
using RedisDemo.Services;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var messageService = new MessageService();
            var messages = messageService.GetAllMessages();

            return View(messages);
        }

        public ActionResult Delete(Guid? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("index");
            }

            var messageService = new MessageService();
            messageService.RemoveMessage(Id.Value);

            return RedirectToAction("index");
        }

        public ActionResult DeleteAll()
        {
            var messageService = new MessageService();
            messageService.DeleteAllMessages();

            return RedirectToAction("index");
        }
    }
}
