using ApplicationServices.DTOs;
using ApplicationServices.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : ICar
    {
        private CarServiceApplication _context = new CarServiceApplication();

        public string DeleteCar(int id)
        {
            if (!_context.Delete(id))
                return "Car was not deleted.";

            return "Car was deleted.";
        }

        public CarDto GetCarById(int id)
        {
            return _context.GetById(id);
        }

        public List<CarDto> GetCars()
        {
            return _context.Get();
        }

        public string Message()
        {
            return "Car service is up!";
        }

        public string PostCar(CarDto carDto)
        {
            if (!_context.Save(carDto))
                return "Car was not inserted.";

            return "Car was inserted.";
        }

        public string PutCar(CarDto carDto)
        {
            if (!_context.Save(carDto))
                return "Car is not updated.";

            return "Car is updated.";
        }
    }
}
