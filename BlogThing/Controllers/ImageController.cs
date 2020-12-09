using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogThing.Utils;
using Microsoft.Extensions.Configuration;
using BlogThing.Data;
using BlogThing.Models;

namespace BlogThing.Controllers
{
    public class ImageController : Controller
    {
        // get the config from dependancy injection
        private IConfiguration config;
        private BlogDbContext db;

        public ImageController(IConfiguration configuration, BlogDbContext context)
        {
            config = configuration;
            db = context;
        }

        // show example form
        public IActionResult Index()
        {
            return View();
        }

        // submit image
        [HttpPost]
        public bool SubmitPicture(IFormFile picture)
        {
            string connectionString = config.GetValue<string>("AzureConnectionString");
            AzureHelper azure = new AzureHelper(connectionString, "codenforce");
            // upload to azure
            // need a filename and a stream
            string fileName = Guid.NewGuid().ToString();
            string extension = picture.FileName.Substring(picture.FileName.LastIndexOf("."));

            fileName += extension;

            if(azure.SaveToAzure(fileName, picture.OpenReadStream()))
            {
                Image image = new Image();
                image.FileName = fileName;
                image.ComplaintId = 7;
                db.Images.Add(image);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public IActionResult DonesoImg()
        {
            return View();
        }
    }
}
