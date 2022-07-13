namespace Project_BSCS.Data
{
    public class PropertyData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PropertyImageUrl { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public double Area { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int Floors { get; set; }
        public double Price { get; set; }
        public string Hospital { get; set; }
        public string Institute { get; set; }
        public string Hotel { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<PropertyGalleryData> PropertyGallery { get; set; }
    }
}
