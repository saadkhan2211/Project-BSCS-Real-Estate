using Microsoft.EntityFrameworkCore;
using Project_BSCS.Data;
using Project_BSCS.Models;

namespace Project_BSCS.Repository
{
    public class PropertyRepository
    {
        private readonly PropertyDbContext _context = null;
        public PropertyRepository(PropertyDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddProperty(Property model)
        {
            var newProperty = new PropertyData()
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                Location = model.Location,
                City = model.City,
                Area = model.Area,
                Bedroom = model.Bedroom,
                Bathroom = model.Bathroom,
                Floors = model.Floors,
                Hospital = model.Hospital,
                Hotel = model.Hotel,
                Institute = model.Institute,
                Name = model.Name,
                ContactNumber = model.ContactNumber,
                PropertyImageUrl = model.PropertyImageUrl,
                CreatedDate = DateTime.UtcNow
            };

            newProperty.PropertyGallery = new List<PropertyGalleryData>();
            foreach (var file in model.Gallery)
            {
                newProperty.PropertyGallery.Add(new PropertyGalleryData()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Properties.AddAsync(newProperty);
            await _context.SaveChangesAsync();

            return newProperty.Id;
        }

        public async Task<List<Property>> GetAllProperty()
        {
            var properties = new List<Property>();
            var allProperty = await _context.Properties.ToListAsync();
            if (allProperty?.Any() == true)
            {
                foreach (var property in allProperty)
                {
                    properties.Add(new Property()
                    {
                        Id = property.Id,
                        Title = property.Title,
                        Description = property.Description,
                        Price = property.Price,
                        Location = property.Location,
                        City = property.City,
                        Area = property.Area,
                        Bedroom = property.Bedroom,
                        Bathroom = property.Bathroom,
                        Floors = property.Floors,
                        Hotel= property.Hotel,
                        Hospital= property.Hospital,
                        Institute = property.Institute,
                        Name = property.Name,
                        ContactNumber=property.ContactNumber,
                        PropertyImageUrl = property.PropertyImageUrl,
                        CreatedDate = DateTime.Now.Date
                    });
                }
            }
            return properties;
        }
        public async Task<List<Property>> GetTopPropertyAsync()
        {
            var properties = new List<Property>();
            var allProperty = await _context.Properties.Take(3).OrderByDescending(s => s.Id).ToListAsync();
            if (allProperty?.Any() == true)
            {
                foreach (var property in allProperty)
                {
                    properties.Add(new Property()
                    {
                        Id = property.Id,
                        Title = property.Title,
                        Description = property.Description,
                        Price = property.Price,
                        Location = property.Location,
                        City = property.City,
                        Area = property.Area,
                        Bedroom = property.Bedroom,
                        Bathroom = property.Bathroom,
                        Floors = property.Floors,
                        Hotel= property.Hotel,
                        Hospital= property.Hospital,
                        Institute = property.Institute,
                        Name=property.Name,
                        ContactNumber=property.ContactNumber,
                        PropertyImageUrl = property.PropertyImageUrl,
                        CreatedDate = DateTime.Now.Date
                    });
                }
            }
            return properties;
        }

        public async Task<Property> GetPropertyById(int id)
        {
            return await _context.Properties.Where(x => x.Id == id).Select(property => new Property(){
                Id = property.Id,
                Title = property.Title,
                Description = property.Description,
                Price = property.Price,
                Location = property.Location,
                City = property.City,
                Area = property.Area,
                Bedroom = property.Bedroom,
                Bathroom = property.Bathroom,
                Floors = property.Floors,
                Hotel = property.Hotel,
                Hospital = property.Hospital,
                Institute = property.Institute,
                Name = property.Name,
                ContactNumber = property.ContactNumber,
                PropertyImageUrl = property.PropertyImageUrl,
                CreatedDate = DateTime.Now.Date,
                Gallery = property.PropertyGallery.Select(g => new PropertyGallery()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                }).ToList()
            }).FirstOrDefaultAsync();
        }
    }
}
