using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.UI;
using BrozdziakJankowski.BeerCatalog.Models;
namespace BrozdziakJankowski.BeerCatalog.UI;

public partial class AddProducerPage : ContentPage
{
    private readonly IProducerService _producerService;

    public AddProducerPage(IProducerService producerService)
    {
        InitializeComponent();
        _producerService = producerService;
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        var producerName = producerNameEntry.Text;
        var producerCountry = producerCountryEntry.Text;

        // Create a new Producer object with the input data
        var newProducer = new Producer
        {
            Name = producerName,
            Country = producerCountry
        };

        // Use the ProducerService to add the new producer
        _producerService.AddProducer(newProducer);

        // Navigate back to the previous page once done
        Shell.Current.GoToAsync("ProducerListPage");
    }
}