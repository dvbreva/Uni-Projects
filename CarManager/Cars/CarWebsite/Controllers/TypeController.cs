using ApplicationServices.DTOs;
using CarWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarWebsite.Controllers
{
    public class TypeController : Controller
    {
        // GET: Type
        public ActionResult Index()
        {
            List<TypeViewModel> typeVM = new List<TypeViewModel>();
            using (TypeServiceReference.TypeClient service = new TypeServiceReference.TypeClient())
            {
                foreach (var item in service.GetTypes())
                {
                    typeVM.Add(new TypeViewModel(item));
                }
            }
            return View(typeVM);
        }


        public ActionResult Details(int id)
        {
            TypeViewModel typeVM = new TypeViewModel();

            using (TypeServiceReference.TypeClient service = new TypeServiceReference.TypeClient())
            {
               
                var typeDto = service.GetTypeById(id);
                typeVM = new TypeViewModel(typeDto);
               
            }

            return View(typeVM);
        }



        public ActionResult Edit(int id)
        {
            TypeViewModel typeVM = new TypeViewModel();

            using (TypeServiceReference.TypeClient service = new TypeServiceReference.TypeClient())
            {
                var typeDto = service.GetTypeById(id);
                typeVM = new TypeViewModel(typeDto);

            }

            return View(typeVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeViewModel typeVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TypeServiceReference.TypeClient service = new TypeServiceReference.TypeClient())
                    {
                        TypeDto typeDto = new TypeDto
                        {
                            Id = typeVM.Id,
                            Name = typeVM.Name,
                            Description = typeVM.Description
                        };

                        service.PostType(typeDto);
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



        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeViewModel typeVM)
        {
            try
            {
                using (TypeServiceReference.TypeClient service = new TypeServiceReference.TypeClient())
                {
                    TypeDto typeDto = new TypeDto
                    {
                        Id = typeVM.Id,
                        Name = typeVM.Name,
                        Description = typeVM.Description
                    };

                    service.PostType(typeDto);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            TypeViewModel typeVM = new TypeViewModel();

            using (TypeServiceReference.TypeClient service = new TypeServiceReference.TypeClient())
            {
                service.DeleteType(id);
            }
            return RedirectToAction("Index");
        }
    }
}