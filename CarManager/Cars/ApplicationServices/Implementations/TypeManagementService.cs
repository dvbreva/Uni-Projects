using ApplicationServices.DTOs;
using Data.Context;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using Type = Data.Entities.Type;

namespace ApplicationServices.Implementations
{
    public class TypeManagementService
    {
        private CarManagerDbContext context = new CarManagerDbContext();


        public List<TypeDto> Get()
        {
            List<TypeDto> typeDtos = new List<TypeDto>();

            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                // foreach-ing each item in the repository, not in the context
                foreach (var item in unitOfWork.TypeRepository.Get())
                {
                    typeDtos.Add(new TypeDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
            }
            return typeDtos;
        }


        public TypeDto GetById(int id)
        {
            TypeDto typeDto = new TypeDto();

            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                Type type = unitOfWork.TypeRepository.GetByID(id);

                if(type != null)
                {
                    typeDto = new TypeDto
                    {
                        Id = type.Id,
                        Name = type.Name,
                        Description = type.Description
                    };
                }
            }

            return typeDto;
        }


        public bool Save(TypeDto typeDto)
        {
            Type type = new Type
            {
                Id = typeDto.Id,
                Name = typeDto.Name,
                Description = typeDto.Description
            };

            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (typeDto.Id == 0)
                    {
                        unitOfWork.TypeRepository.Insert(type);
                    }
                    else
                    {
                        unitOfWork.TypeRepository.Update(type);
                    }
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(type);
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Type type = unitOfWork.TypeRepository.GetByID(id);
                    unitOfWork.TypeRepository.Delete(type);
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
