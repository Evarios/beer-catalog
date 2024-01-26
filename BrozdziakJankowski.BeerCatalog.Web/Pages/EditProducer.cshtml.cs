using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class EditProducerModel : PageModel
{
    private readonly IProducerService _producerService;

    public EditProducerModel(IProducerService producerService)
    {
        _producerService = producerService;
    }

    [BindProperty]
    public Producer Producer { get; set; }

    public void OnGet(int id)
    {
        Producer = _producerService.GetProducerById(id);
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _producerService.UpdateProducer(Producer);

        return RedirectToPage("/Producers");
    }
}
