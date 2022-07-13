using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_BSCS.Data;
using Project_BSCS.Models;
using Project_BSCS.Repository;

namespace Project_BSCS.Controllers
{
    public class PropertyController : Controller
    {
        private readonly PropertyRepository _propertyRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PropertyController(PropertyRepository propertyRepository, IWebHostEnvironment webHostEnvironment)
        {
            _propertyRepository = propertyRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ViewResult> Property()
        {
            //ViewBag.PriceSortDesc = string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            //ViewBag.PriceSortAsce = string.IsNullOrEmpty(sortOrder) ? "price_asce" : "";
            //ViewBag.DateOrder = string.IsNullOrEmpty(sortOrder) ? "newest" : "";

            var property = await _propertyRepository.GetAllProperty();
            return View(property);

            //Sorting Logic
            //switch (sortOrder)
            //{
            //    case "price_desc":
            //        property = (List<Property>)property.OrderByDescending(x => x.Price);
            //        break;

            //    case "price_asce":
            //        property = (List<Property>)property.OrderBy(x => x.Price);
            //        break;
            //    case "newwest":
            //        property = (List<Property>)property.OrderBy(x => x.CreatedDate);
            //        break;
            //    default:
            //        property = (List<Property>)property.OrderByDescending(x => x.CreatedDate);
            //        break;
            //}
        }
        [Authorize]
        public IActionResult AddProperty(bool isSuccess = false, int propertyId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.PropertyId = propertyId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProperty(Property obj)
        {
            
            if (ModelState.IsValid)
            {
                if (obj.PropertyImage != null)
                {
                    string folder = "Image/PropertyImage/";
                    obj.PropertyImageUrl = await UploadImage(folder, obj.PropertyImage);
                    
                }
                if (obj.PropertyImages != null)
                {
                    string folder = "Image/PropertyGallery/";

                    obj.Gallery = new List<PropertyGallery>();

                    foreach (var file in obj.PropertyImages)
                    {
                        var gallery = new PropertyGallery()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        obj.Gallery.Add(gallery);
                    }
                }
                int id = await _propertyRepository.AddProperty(obj);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddProperty), new { isSuccess = true, propertyId = id });
                }
            }
            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string severFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(severFolder, FileMode.Create));
            return "/" + folderPath;
        }

        public async Task<ViewResult> GetProperty(int id)
        {
            var data = await _propertyRepository.GetPropertyById(id);
            return View(data);
        }
    }
}
