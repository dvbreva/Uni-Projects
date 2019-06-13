using ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarWebsite.ViewModels
{
    public class MakeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }


        public MakeViewModel() { }


        public MakeViewModel(MakeDto makeDto)
        {
            Id = makeDto.Id;
            Name = makeDto.Name;
            Description = makeDto.Description;
            Country = makeDto.Country;
        }
    }
}