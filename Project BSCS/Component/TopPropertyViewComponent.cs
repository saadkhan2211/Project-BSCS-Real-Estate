using Microsoft.AspNetCore.Mvc;
using Project_BSCS.Repository;

namespace Project_BSCS.Component
{
    public class TopPropertyViewComponent : ViewComponent
    {
        private readonly PropertyRepository _propertyRepository;

        public TopPropertyViewComponent(PropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _propertyRepository.GetTopPropertyAsync();
            return View(data);
        }
    }
}
