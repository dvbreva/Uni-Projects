using ApplicationServices.DTOs;
using CarWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarWebsite.Controllers
{
    public class MakeController : Controller
    {
        // GET: Make
        public ActionResult Index()
        {
            List<MakeViewModel> makeVM = new List<MakeViewModel>();
            using (MakeServiceReference.MakeClient service = new MakeServiceReference.MakeClient())
            {
                foreach (var item in service.GetMakes())
                {
                    makeVM.Add(new MakeViewModel(item));
                }
            }
            return View(makeVM);
        }


        public ActionResult Details(int id)
        {
            MakeViewModel makeVM = new MakeViewModel();

            using (MakeServiceReference.MakeClient service = new MakeServiceReference.MakeClient())
            {
                var makeDto = service.GetMakeById(id);
                makeVM = new MakeViewModel(makeDto);
            }

            return View(makeVM);
        }

        // GET: Make/Edit/5
        public ActionResult Edit(int id)
        {
            MakeViewModel makeVM = new MakeViewModel();

            using (MakeServiceReference.MakeClient service = new MakeServiceReference.MakeClient())
            {
                var makeDto = service.GetMakeById(id);
                makeVM = new MakeViewModel(makeDto);
            }

            return View(makeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MakeViewModel makeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MakeServiceReference.MakeClient service = new MakeServiceReference.MakeClient())
                    {
                        MakeDto makeDto = new MakeDto
                        {
                            Id = makeVM.Id,
                            Name = makeVM.Name,
                            Description = makeVM.Description,
                            Country = makeVM.Country
                        };
                        service.PostMake(makeDto);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            MakeViewModel makeVM = new MakeViewModel();

            using (MakeServiceReference.MakeClient service = new MakeServiceReference.MakeClient())
            {
                service.DeleteMake(id);
            }
            return RedirectToAction("Index");
        }

        // GET: Make/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MakeViewModel makeVM)
        {
            try
            {
                using (MakeServiceReference.MakeClient service = new MakeServiceReference.MakeClient())
                {
                    MakeDto makeDto = new MakeDto
                    {
                        Id = makeVM.Id,
                        Name = makeVM.Name,
                        Description = makeVM.Description,
                        Country = makeVM.Country
                    };
                    service.PostMake(makeDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}