using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pezeshkan.Models;
using System.Globalization;
using Microsoft.AspNet.Identity;

namespace Pezeshkan.Controllers
{
    [Authorize]
    public class SickDocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SickDocuments
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            return View("PersonalInfo", db.SickInfo.Where(a=>a.userId == userId).ToList());
        }

        // GET: SickDocuments
        public ActionResult PersonalInfo(string searchText)
        {
            string userId = User.Identity.GetUserId();
            if (String.IsNullOrEmpty(searchText))
                return PartialView("_PersonalInfoList", db.SickInfo.Where(a => a.userId == userId).ToList());
            else
                return PartialView("_PersonalInfoList", db.SickInfo.Where(a => a.userId == userId && (a.fname.Contains(searchText) || a.lname.Contains(searchText) || a.pcode.ToString().Contains(searchText))));
        }

        // GET: SickDocuments/Documents
        public ActionResult Documents(long id, string date)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string userId = User.Identity.GetUserId();

            ViewBag.personalInfo = (from a in db.SickInfo where a.pcode == id && a.userId == userId select a).First<SickInfo>();

            ViewBag.dates = new SelectList((from a in db.Special2
                                            where a.pcode == id
                                            select a).ToList(), "date", "date");
            ViewBag.vcc = new MultiSelectList((from a in db.Desease
                                               where a.desease_groop == "CC"
                                               select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vfmh = new SelectList((from a in db.Desease
                                           where a.desease_groop == "FMH"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vpmh = new SelectList((from a in db.Desease
                                           where a.desease_groop == "PMH"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vpsh = new SelectList((from a in db.Desease
                                           where a.desease_groop == "POH"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vpupils = new SelectList((from a in db.Desease
                                              where a.desease_groop == "PUPILS"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vcornea = new SelectList((from a in db.Desease
                                              where a.desease_groop == "CORNEA"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vac = new SelectList((from a in db.Desease
                                          where a.desease_groop == "AC"
                                          select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vlens = new SelectList((from a in db.Desease
                                            where a.desease_groop == "LENS"
                                            select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vangle = new SelectList((from a in db.Desease
                                             where a.desease_groop == "ANGLE"
                                             select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vcup = new SelectList((from a in db.Desease
                                           where a.desease_groop == "DISC/CUP"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vcolor = new SelectList((from a in db.Desease
                                             where a.desease_groop == "COLOR"
                                             select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vmargin = new SelectList((from a in db.Desease
                                              where a.desease_groop == "MARGIN"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vvessels = new SelectList((from a in db.Desease
                                               where a.desease_groop == "VESSELS"
                                               select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vperiphery = new SelectList((from a in db.Desease
                                                 where a.desease_groop == "PERIPHERY"
                                                 select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vmacula = new SelectList((from a in db.Desease
                                              where a.desease_groop == "MACULA"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vplan = new MultiSelectList((from a in db.Desease
                                                 where a.desease_groop == "PLAN"
                                                 select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vassess = new SelectList(db.Complate.ToList<Complate>(), "complate", "complate");
            ViewBag.vOD = new SelectList((new string[] { "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1" }));
            ViewBag.vOS = new SelectList((new string[] { "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1" }));
            ViewBag.vcontactLens = new SelectList((new string[] { "RGP", "SOFT" }));
            ViewBag.vapd = new SelectList((new string[] { "1", "2", "3", "4", "NO" }));

            if (String.IsNullOrEmpty(date))
            {
                Special2 specialTemp = new Special2();
                specialTemp.pcode = id;
                specialTemp.userId = userId;
                return View(specialTemp);
            }
            else
            {
                Special2 special = db.Special2.Where(a => a.pcode == id && a.Date == date && a.userId == userId).First();
                return View(special);
            }
        }

        // POST: SickDocuments/Documents
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Documents(Special2 special2)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(special2.Date))
                    db.Entry(special2).State = EntityState.Modified;
                else
                {
                    DateTime d = DateTime.Today;
                    PersianCalendar pc = new PersianCalendar();
                    special2.Date = string.Format("{0:yyyy}/{1:MM}/{2:dd}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
                    db.Special2.Add(special2);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            string userId = User.Identity.GetUserId();

            ViewBag.personalInfo = (from a in db.SickInfo where a.pcode == special2.pcode && a.userId == userId select a).First<SickInfo>();

            ViewBag.dates = new SelectList((from a in db.Special2
                                            where a.pcode == special2.pcode
                                            select a).ToList(), "date", "date");
            ViewBag.vcc = new MultiSelectList((from a in db.Desease
                                               where a.desease_groop == "CC"
                                               select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vfmh = new SelectList((from a in db.Desease
                                           where a.desease_groop == "FMH"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vpmh = new SelectList((from a in db.Desease
                                           where a.desease_groop == "PMH"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vpsh = new SelectList((from a in db.Desease
                                           where a.desease_groop == "POH"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vpupils = new SelectList((from a in db.Desease
                                              where a.desease_groop == "PUPILS"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vcornea = new SelectList((from a in db.Desease
                                              where a.desease_groop == "CORNEA"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vac = new SelectList((from a in db.Desease
                                          where a.desease_groop == "AC"
                                          select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vlens = new SelectList((from a in db.Desease
                                            where a.desease_groop == "LENS"
                                            select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vangle = new SelectList((from a in db.Desease
                                             where a.desease_groop == "ANGLE"
                                             select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vcup = new SelectList((from a in db.Desease
                                           where a.desease_groop == "DISC/CUP"
                                           select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vcolor = new SelectList((from a in db.Desease
                                             where a.desease_groop == "COLOR"
                                             select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vmargin = new SelectList((from a in db.Desease
                                              where a.desease_groop == "MARGIN"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vvessels = new SelectList((from a in db.Desease
                                               where a.desease_groop == "VESSELS"
                                               select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vperiphery = new SelectList((from a in db.Desease
                                                 where a.desease_groop == "PERIPHERY"
                                                 select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vmacula = new SelectList((from a in db.Desease
                                              where a.desease_groop == "MACULA"
                                              select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vplan = new MultiSelectList((from a in db.Desease
                                                 where a.desease_groop == "PLAN"
                                                 select a).ToList<Desease>(), "desease_name", "desease_name");
            ViewBag.vassess = new SelectList(db.Complate.ToList<Complate>(), "complate", "complate");
            ViewBag.vOD = new SelectList((new string[] { "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1" }));
            ViewBag.vOS = new SelectList((new string[] { "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1" }));
            ViewBag.vcontactLens = new SelectList((new string[] { "RGP", "SOFT" }));
            ViewBag.vapd = new SelectList((new string[] { "1", "2", "3", "4", "NO" }));
            return View(special2);
        }

        [HttpPost]
        [AllowAnonymous]
        public void addDesease(string group, string text)
        {
            Desease desease = new Desease();
            desease.desease_groop = group;
            desease.desease_name = text;
            db.Desease.Add(desease);
            db.SaveChanges();
        }

        [HttpPost]
        [AllowAnonymous]
        public void removeDesease(string group, string text)
        {
            Desease desease = db.Desease.Where(a => a.desease_groop == group && a.desease_name == text).First();
            if (desease != null)
            {
                db.Desease.Remove(desease);
                db.SaveChanges();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public void addComplate(string text)
        {
            int max = db.Complate.Max<Complate>(a => a.kind_of_complate);
            Complate complate = new Complate();
            complate.complate = text;
            complate.kind_of_complate = max++;
            db.Complate.Add(complate);
            db.SaveChanges();
        }

        [HttpPost]
        [AllowAnonymous]
        public void removeComplate(string text)
        {
            Complate complate = db.Complate.Where(a => a.complate == text).First();
            if (complate != null)
            {
                db.Complate.Remove(complate);
                db.SaveChanges();
            }
        }

        // GET: SickDocuments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Special2 special2 = db.Special2.Find(id);
            if (special2 == null)
            {
                return HttpNotFound();
            }
            return View(special2);
        }

        // GET: SickDocuments/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: SickDocuments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Special2 special2 = db.Special2.Find(id);
            if (special2 == null)
            {
                return HttpNotFound();
            }
            return View(special2);
        }

        // POST: SickDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,pcode,cc,fmh,pmh,psh,pdod,pdos,apd_os,apd_od,pupils,pupilsOS,iop_od,iop_os,Cornea_od,ac_od,lens_od,drops1_od,drops1_os,cyclo1_od,cyclo1_os,nearaddOd,nearaddOs,Near2,Ref2,diag,plan,disc1,disc2,medi1,medi2,medi3,medi4,disc,color_od,margin_od,disc_os,color_os,margin_os,Cornea_os,ac_os,lens_os,disc_od,visualod,visualos,plan2,plan3,diag2,diag3,date2,npd,Slit,Conj,angleod,angleos,macula1,macula2,macula3,vesselsos,vesselsod,peripheryod,peripheryos,visualglassod,visualglassos,BCVAOd1,BCVAOd2,BCVAOd3,BCVAOs1,BCVAOs2,BCVAOs3,Addod,Addos,PresentNGOd,PresentNGOs,nearaddod2,nearaddod3,nearaddos2,nearaddos3,lenskindos,lenskindod,diag4,diag5,diag6,plan4,plan5,plan6,BCVAOdcolor,BCVAOscolor,Tonopenos,Tonopenod,discopt,pakod,pakos")] Special2 special2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(special2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(special2);
        }

        // GET: SickDocuments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Special2 special2 = db.Special2.Find(id);
            if (special2 == null)
            {
                return HttpNotFound();
            }
            return View(special2);
        }

        // POST: SickDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Special2 special2 = db.Special2.Find(id);
            db.Special2.Remove(special2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
