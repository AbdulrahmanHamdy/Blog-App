using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class PostController : Controller
    {
        private AppBDContext _context;
        private readonly string[] _allowedExtension = { ".jpg", ".jpeg", ".png" };

        public PostController(AppBDContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var postViewModel = new PostViewModel
            {
                Categories = new SelectList(_context.Categories, "Id", "Name"),
            };
            return View(postViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(10485760)]
        public async Task<IActionResult> Create(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                var inputFileExtension = Path.GetExtension(postViewModel.FeatureImage.FileName).ToLower();
                bool isAllowed = _allowedExtension.Contains(inputFileExtension);
                if (!isAllowed)
                {
                    ModelState.AddModelError("FeatureImage", "Invalid image format. Allowed formats are .jpg, .jpeg, .png");

                    // إعادة تحميل الـ Categories
                    postViewModel.Categories = new SelectList(_context.Categories, "Id", "Name");
                    return View(postViewModel);
                }

                postViewModel.Post.FeatureImagePath = await UploadFileToFolder(postViewModel.FeatureImage);
                _context.Posts.Add(postViewModel.Post);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // إعادة تحميل الـ Categories عند أي خطأ في النموذج
            postViewModel.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(postViewModel);
        }

        private async Task<string> UploadFileToFolder(IFormFile file)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Return path relative to wwwroot for use in <img src="">
            return Path.Combine("uploads", uniqueFileName).Replace("\\", "/");
        }
    }


}
