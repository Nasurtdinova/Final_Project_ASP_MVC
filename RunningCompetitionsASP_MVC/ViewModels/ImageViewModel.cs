using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RunningCompetitionsASP_MVC.ViewModels
{
    public class ImageViewModel
    {
        public string FileName { get; set; }
  
        public IFormFile ImageData { get; set; }

    }
}
