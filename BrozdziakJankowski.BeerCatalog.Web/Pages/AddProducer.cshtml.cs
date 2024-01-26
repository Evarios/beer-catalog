using BrozdziakJankowski.BeerCatalog.Models;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AddProducerModel : PageModel
{
    private readonly IProducerService _producerService;

    public AddProducerModel(IProducerService producerService)
    {
        _producerService = producerService;
    }

    [BindProperty]
    public Producer Producer { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        ModelState.Remove("Beers");
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _producerService.AddProducer(Producer);

        return RedirectToPage("./Producers");
    }
}
