using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarWebsite.ViewModels
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(400)]
        public string Description { get; set; }



        public TypeViewModel() { }

        public TypeViewModel(TypeDto typeDto)
        {
            Id = typeDto.Id;
            Name = typeDto.Name;
            Description = typeDto.Description;
        }

    }
}