using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using BrozdziakJankowski.BeerCatalog.Core; // Make sure this is included if BeerType enum is in a different namespace

public class BeersModel : PageModel
{
    private readonly IBeerService _beerService;
    private readonly IProducerService _producerService;

    public BeersModel(IBeerService beerService, IProducerService producerService)
    {
        _beerService = beerService;
        _producerService = producerService;
    }

    [BindProperty(SupportsGet = true)]
    public string TypeFilter { get; set; }

    public IList<Beer> Beers { get; private set; }
    public Dictionary<int, string> ProducerNames { get; set; } = new Dictionary<int, string>();
    public List<string> BeerTypes { get; set; } // Initialized list to populate the filter dropdown

    public void OnGet()
    {
        // Always populate the BeerTypes for the filter dropdown to ensure it's never null
        BeerTypes = Enum.GetValues(typeof(BeerType))
                        .Cast<BeerType>()
                        .Select(bt => bt.ToString())
                        .ToList();

        var beersQuery = _beerService.GetAllBeers();

        if (!string.IsNullOrEmpty(TypeFilter) && Enum.TryParse(TypeFilter, out BeerType typeFilter))
        {
            beersQuery = beersQuery.Where(beer => beer.Type == typeFilter);
        }

        Beers = beersQuery.ToList();

        // Ensure ProducerNames is populated only if there are beers, otherwise initialize to an empty dictionary
        ProducerNames = Beers.Any()
            ? _producerService.GetAllProducers()
                              .Where(producer => Beers.Select(beer => beer.ProducerId).Contains(producer.ProducerId))
                              .ToDictionary(producer => producer.ProducerId, producer => producer.Name)
            : new Dictionary<int, string>();
    }

    public IActionResult OnPostDelete(int? deleteId)
    {
        if (deleteId.HasValue)
        {
            _beerService.DeleteBeer(deleteId.Value);
        }

        // Re-initialize BeerTypes and other necessary properties here
        BeerTypes = Enum.GetValues(typeof(BeerType))
                        .Cast<BeerType>()
                        .Select(bt => bt.ToString())
                        .ToList();

        // Optionally, you might also want to reload the beers and producer names if they are displayed on the same page
        var beersQuery = _beerService.GetAllBeers();
        Beers = beersQuery.ToList();
        ProducerNames = Beers.Any()
            ? _producerService.GetAllProducers()
                              .Where(producer => Beers.Select(beer => beer.ProducerId).Contains(producer.ProducerId))
                              .ToDictionary(producer => producer.ProducerId, producer => producer.Name)
            : new Dictionary<int, string>();

        return RedirectToPage();
    }
}
