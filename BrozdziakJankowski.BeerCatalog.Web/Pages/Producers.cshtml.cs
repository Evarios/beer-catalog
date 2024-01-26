using BrozdziakJankowski.BeerCatalog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrozdziakJankowski.BeerCatalog.Models;


namespace BrozdziakJankowski.BeerCatalog.Web.Pages
{
    public class ProducersModel : PageModel
    {
        private readonly IProducerService _producerService;

        public ProducersModel(IProducerService producerService)
        {
            _producerService = producerService;
        }
        public IList<Producer> Producers { get; private set; }

        public void OnGet()
        {
            Producers = _producerService.GetAllProducers().ToList();
        }
        public async Task<IActionResult> OnPostAsync(int? deleteId)
        {
            if (deleteId.HasValue)
            {
                _producerService.DeleteProducer(deleteId.Value);
            }

            return RedirectToPage();
        }
    }
}
