using System;
using System.Web.Mvc;
using Mailman.Web.Models;

namespace Mailman.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly CompositeMailman _mailman = new CompositeMailman();

        public ActionResult Index()
        {
            return View(new EmailModel());
        }

        [HttpPost]
        public ActionResult Index(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                var mail = new Email()
                {
                    Subject = model.Subject,
                    From = model.From,
                    Body = model.Body,
                    To = string.IsNullOrWhiteSpace(model.To) ? null : model.To?.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries),
                    Cc = string.IsNullOrWhiteSpace(model.Cc) ? null : model.Cc?.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries),
                    Bcc = string.IsNullOrWhiteSpace(model.Bcc) ? null : model.Bcc?.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                };

                try
                {
                    _mailman.Send(mail);
                    return RedirectToAction("Sent");
                }
                catch (Exception e)
                {
                    model.Error = e.Message;
                }
            }
            model.HasErrors = true;
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}