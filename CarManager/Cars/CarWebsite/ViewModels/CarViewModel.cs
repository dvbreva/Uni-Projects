using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarWebsite.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Model { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public int HorsePower { get; set; }

        [Display(Name ="Make")]
        public int MakeId { get; set; }
        public MakeViewModel MakeVM { get; set; }

        [Display(Name ="Type")]
        public int TypeId { get; set; }
        public TypeViewModel TypeVM { get; set; }


        public CarViewModel() { }

        public CarViewModel(CarDto carDto)
        {
            Id = carDto.Id;
            Model = carDto.Model;
            ReleaseYear = carDto.ReleaseYear;
            HorsePower = carDto.HorsePower;
            MakeId = carDto.Make.Id;
            MakeVM = new MakeViewModel
            {
                Id = carDto.Make.Id,
                Name = carDto.Make.Name,
                Description = carDto.Make.Description,
                Country = carDto.Make.Country
            };
            TypeId = carDto.Type.Id;
            TypeVM = new TypeViewModel
            {
                Id = carDto.Type.Id,
                Name = carDto.Type.Name,
                Description = carDto.Type.Description
            };
        }

    }
}