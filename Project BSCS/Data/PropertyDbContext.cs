using Microsoft.EntityFrameworkCore;
using Project_BSCS.Models;

namespace Project_BSCS.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options) : base(options)
        {
        }
        public DbSet<PropertyData> Properties { get; set; }
        public DbSet<PropertyGalleryData> PropertyGalleryDatas { get; set; }

    }
}
