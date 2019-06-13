using ApplicationServices.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;

namespace ApplicationServices.Implementations
{
    public class MakeManagementService
    {
        private CarManagerDbContext context = new CarManagerDbContext();

        public List<MakeDto> Get()
        {
            List<MakeDto> makeDtos = new List<MakeDto>();

            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach(var item in unitOfWork.MakeRepository.Get())
                {
                    makeDtos.Add(new MakeDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Country = item.Country
                    });
                }
            }
            return makeDtos;
        }

        public MakeDto GetById(int id)
        {
            MakeDto makeDto = new MakeDto();

            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                Make make = unitOfWork.MakeRepository.GetByID(id);
                if(make != null)
                {
                    makeDto = new MakeDto
                    {
                        Id = make.Id,
                        Name = make.Name,
                        Description = make.Description,
                        Country = make.Country
                    };
                }
            }

            return makeDto;
        }

        public bool Save(MakeDto makeDto)
        {
            Make make = new Make
            {
                Id = makeDto.Id, // !NBBBB
                Name = makeDto.Name,
                Description = makeDto.Description,
                Country = makeDto.Country
            };

            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (makeDto.Id == 0)
                    {
                        unitOfWork.MakeRepository.Insert(make);
                    }
                    else
                    {
                        unitOfWork.MakeRepository.Update(make);
                    }

                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(make);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Make make = unitOfWork.MakeRepository.GetByID(id);
                    unitOfWork.MakeRepository.Delete(make);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
