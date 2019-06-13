using ApplicationServices.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using Type = Data.Entities.Type;

namespace ApplicationServices.Implementations
{
    public class CarServiceApplication
    {
        private CarManagerDbContext context = new CarManagerDbContext();


        public List<CarDto> Get()
        {
            List<CarDto> carsDto = new List<CarDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CarRepository.Get())
                // foreach (var item in context.Cars.ToList())
                {
                    carsDto.Add(new CarDto
                    {
                        Id = item.Id,
                        Model = item.Model,
                        ReleaseYear = item.ReleaseYear,
                        HorsePower = item.HorsePower,
                        Make = new MakeDto
                        {
                            Id = item.Make.Id,
                            Name = item.Make.Name,
                            Description = item.Make.Description,
                            Country = item.Make.Country
                        },
                        Type = new TypeDto
                        {
                            Id = item.Type.Id,
                            Name = item.Type.Name,
                            Description = item.Type.Description
                        }
                    });
                }
            }
            return carsDto;
        }


        public CarDto GetById(int id)
        {
            CarDto carDto = new CarDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Car car = unitOfWork.CarRepository.GetByID(id);
                if(car != null)
                {
                    carDto = new CarDto
                    {
                        Model = car.Model,
                        ReleaseYear = car.ReleaseYear,
                        HorsePower = car.HorsePower,
                        Make = new MakeDto
                        {
                            Id = car.MakeId,
                            Name = car.Make.Name,
                            Description = car.Make.Description,
                            Country = car.Make.Country
                        },
                        Type = new TypeDto
                        {
                            Id = car.TypeId,
                            Name = car.Type.Name,
                            Description = car.Type.Description
                        }
                    };
                }
            }

            return carDto;
        }


        public bool Save(CarDto carDto)
        {
            if(carDto.Make == null || carDto.Type == null)
            {
                return false;
            } 

            // add additional functionality - if there is no such make or type -> create it
            Make make = new Make
            {
                Name = carDto.Make.Name,
                Description = carDto.Make.Description,
                Country = carDto.Make.Country
            };

            Type type = new Type
            {
                Name = carDto.Type.Name,
                Description = carDto.Type.Description
            };


            Car car = new Car
            {
                Id = carDto.Id,
                Model = carDto.Model,
                ReleaseYear = carDto.ReleaseYear,
                HorsePower = carDto.HorsePower,
                MakeId = carDto.Make.Id,
             //   Make = make,
                TypeId = carDto.Type.Id
              //  Type = type
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (carDto.Id == 0)
                    {
                       unitOfWork.CarRepository.Insert(car);
                      
                    }
                    else
                    {
                        unitOfWork.CarRepository.Update(car);
                    }
                   
                    unitOfWork.Save();
                }
                /* context.Cars.Add(car);
                 context.SaveChanges(); */
                return true;
            }
            catch
            {
                Console.WriteLine(car);
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Car car = unitOfWork.CarRepository.GetByID(id);
                    unitOfWork.CarRepository.Delete(car);
                    unitOfWork.Save();
                }
                /* Car car = context.Cars.Find(id);
                 context.Cars.Remove(car);
                 context.SaveChanges(); */
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
