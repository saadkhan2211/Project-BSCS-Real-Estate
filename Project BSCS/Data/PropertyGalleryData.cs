namespace Project_BSCS.Data
{
    public class PropertyGalleryData
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public PropertyData Property { get; set; }
    }
}
