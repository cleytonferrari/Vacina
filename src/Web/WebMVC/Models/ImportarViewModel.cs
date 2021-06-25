using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebMVC.Models
{
    public class ImportarViewModel
    {
        [Required(ErrorMessage = "Por favor selecione um arquivo *.csv")]
        [DataType(DataType.Upload)]
        public IFormFile Arquivo { get; set; }

    }
}
