using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using BrozdziakJankowski.BeerCatalog.UI;
public class MainPageViewModel
{
    public ICommand AddProducerCommand { get; private set; }
    public ICommand ViewProducersCommand { get; private set; }
    public ICommand AddBeerCommand { get; private set; }
    public ICommand ViewBeersCommand { get; private set; }

    public MainPageViewModel()
    {
        // Initialize commands
        AddProducerCommand = new Command(OnAddProducer);
        ViewProducersCommand = new Command(OnViewProducers);
        AddBeerCommand = new Command(OnAddBeer);
        ViewBeersCommand = new Command(OnViewBeers);
    }

    private void OnAddProducer()
    {
        Shell.Current.GoToAsync(nameof(AddProducerPage));
    }

    private void OnViewProducers()
    {
        Shell.Current.GoToAsync(nameof(ProducerListPage));
    }

    private void OnAddBeer()
    {
        Shell.Current.GoToAsync(nameof(AddBeerPage));
    }

    private void OnViewBeers()
    {
        Shell.Current.GoToAsync(nameof(BeerListPage));
    }
}
