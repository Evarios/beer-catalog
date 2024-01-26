using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using BrozdziakJankowski.BeerCatalog.BL;

public class BeersModel : PageModel
{
    private readonly IBeerService _beerService;
    private readonly IProducerService _producerService;

    public BeersModel(IBeerService beerService, IProducerService producerService)
    {
        _beerService = beerService;
        _producerService = producerService;
    }

    public IList<Beer> Beers { get; private set; }
    public Dictionary<int, string> ProducerNames { get; set; } = new Dictionary<int, string>();
    public void OnGet()
    {
        Beers = _beerService.GetAllBeers().ToList();
        ProducerNames = Beers.Select(beer => beer.ProducerId).Distinct().ToDictionary(id => id, id => _producerService.GetProducerById(id).Name);
    }

    public IActionResult OnPostDelete(int? deleteId)
    {
        if (deleteId.HasValue)
        {
            _beerService.DeleteBeer(deleteId.Value);
        }

        return RedirectToPage();
    }
}
