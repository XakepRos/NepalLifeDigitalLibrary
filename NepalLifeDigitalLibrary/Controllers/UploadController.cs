using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DigitalLibrarySystem.Helper;
using DigitalLibrarySystem.Data;
using DigitalLibrarySystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace DigitalLibrarySystem.Controllers
{
    public class UploadController : Controller
    {
        private readonly DbaseContext _dbContext;
        private readonly IConfiguration _configuration;
        public UploadController(DbaseContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public ActionResult UploadDocument()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UploadDocument(IFormFile file)
        {
            UploadHelper helper = new UploadHelper(_configuration);
            DocumentModel model = new DocumentModel();
            try
            {
                if (file != null)
                {
                    string folder = "NepalLife\\Documents";
                    model.DocURL = await helper.UploadImage(folder, file);

                }
                await _dbContext.Documents.AddRangeAsync(model);
                _dbContext.SaveChanges();
                ViewBag.Message = "Successfully Uploaded";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Upload failed. Try again.";
            }

            return View();
        }
    }
}
