using ApplicationServices.DTOs;
using CarWebsite.Utils;
using CarWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarWebsite.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            List<CarViewModel> carsVM = new List<CarViewModel>();
            using(CarServiceReference.CarClient service = new CarServiceReference.CarClient())
            {
                foreach(var item in service.GetCars())
                {
                    carsVM.Add(new CarViewModel(item));
                }
            }
            return View(carsVM);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            CarViewModel carVM = new CarViewModel();
            using (CarServiceReference.CarClient service = new CarServiceReference.CarClient())
            {
                var carDto = service.GetCarById(id);
                carVM = new CarViewModel(carDto);
            }

            return View(carVM);
        }

        
        public ActionResult Create()
        {
            ViewBag.Makes = LoadDataUtils.LoadMakesData();
            ViewBag.Types = LoadDataUtils.LoadTypesData();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarViewModel carVM)
        {
            try
            {
                    using (CarServiceReference.CarClient service = new CarServiceReference.CarClient())
                    {
                        CarDto carDto = new CarDto
                        {
                         //   Id = carVM.Id,
                            Model = carVM.Model,
                            ReleaseYear = carVM.ReleaseYear,
                            HorsePower = carVM.HorsePower,
                            Make = new MakeDto
                            {
                                Id = carVM.MakeId
                            },
                            Type = new TypeDto
                            {
                                Id = carVM.TypeId
                            }
                        };
                        service.PostCar(carDto);
                    }
                    ViewBag.Makes = LoadDataUtils.LoadMakesData();
                    ViewBag.Types = LoadDataUtils.LoadTypesData();

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            CarViewModel carVM = new CarViewModel();

            using(CarServiceReference.CarClient carService = new CarServiceReference.CarClient())
            {
                CarDto carDto = carService.GetCarById(id);
                carVM = new CarViewModel(carDto);
            }

            return View(carVM);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (CarServiceReference.CarClient carService = new CarServiceReference.CarClient())
            {
                carService.DeleteCar(id);
            }
            return RedirectToAction("Index");
        }

        


        public ActionResult Edit(int id)
        {
            CarViewModel carVM = new CarViewModel();
            using (CarServiceReference.CarClient carService = new CarServiceReference.CarClient())
            {
                var carDto = carService.GetCarById(id);
                carVM = new CarViewModel(carDto);
            }

            ViewBag.Makes = LoadDataUtils.LoadMakesData();
            ViewBag.Types = LoadDataUtils.LoadTypesData();

            return View(carVM);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarViewModel carVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CarServiceReference.CarClient service = new CarServiceReference.CarClient())
                    {
                        CarDto carDto = new CarDto
                        {
                            Id = carVM.Id,
                            Model = carVM.Model,
                            ReleaseYear = carVM.ReleaseYear,
                            HorsePower = carVM.HorsePower,
                            Make = new MakeDto
                            {
                                Id = carVM.MakeId
                            },
                            Type = new TypeDto
                            {
                                Id = carVM.TypeId
                            }
                        };
                        service.PostCar(carDto);
                    }

                    return RedirectToAction("Index");
                }

                ViewBag.Makes = LoadDataUtils.LoadMakesData();
                ViewBag.Types = LoadDataUtils.LoadTypesData();

                return View();
            }
            catch
            {
                ViewBag.Makes = LoadDataUtils.LoadMakesData();
                ViewBag.Types = LoadDataUtils.LoadTypesData();

                return View();
            }
        }
    }
}