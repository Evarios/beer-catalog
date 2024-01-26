using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BrozdziakJankowski.BeerCatalog.Models;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BrozdziakJankowski.BeerCatalog.Core;

public class AddBeerModel : PageModel
{
    private readonly IBeerService _beerService;
    private readonly IProducerService _producerService;

    public AddBeerModel(IBeerService beerService, IProducerService producerService)
    {
        _beerService = beerService;
        _producerService = producerService;
    }

    [BindProperty]
    public Beer Beer { get; set; }

    public List<SelectListItem> Producers { get; set; }
    public List<SelectListItem> BeerTypes { get; set; }

    public void OnGet()
    {
        Producers = _producerService.GetAllProducers()
            .Select(a => new SelectListItem
            {
                Value = a.ProducerId.ToString(),
                Text = a.Name
            }).ToList();

        BeerTypes = System.Enum.GetValues(typeof(BeerType))
            .Cast<BeerType>()
            .Select(b => new SelectListItem
            {
                Value = b.ToString(),
                Text = b.ToString()
            }).ToList();
    }

    public IActionResult OnPost()
    {
        ModelState.Remove("Beer.Producer");
        if (!ModelState.IsValid)
        {   
            return Page();
        }
        _beerService.AddBeer(Beer);

        return RedirectToPage("/Beers"); // Ensure you have a Beers list page to redirect to
    }
}
