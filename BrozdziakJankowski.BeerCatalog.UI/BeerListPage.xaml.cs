using BrozdziakJankowski.BeerCatalog.Core;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.UI
{
    public partial class BeerListPage : ContentPage
    {
        private readonly IBeerService _beerService;
        private readonly IProducerService _producerService;
        private List<Beer> _beers;
        private List<string> _beerTypes;
        private Dictionary<int, string> _producerIdToName;
        private List<string> _filterBeerTypes;
        private ObservableCollection<Beer> _filteredBeers;


        public BeerListPage(IBeerService beerService, IProducerService producerService)
        {
            InitializeComponent();
            _beerService = beerService;
            _producerService = producerService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

        private void LoadData()
        {
            _beers = _beerService.GetAllBeers().ToList();
            var producers = _producerService.GetAllProducers().ToList();

            _beerTypes = Enum.GetValues(typeof(BeerType)).Cast<BeerType>().Select(bt => bt.ToString()).ToList();
            _producerIdToName = producers.ToDictionary(p => p.ProducerId, p => p.Name);

            beerListView.ItemsSource = _beers;
            _filterBeerTypes = new List<string> { "All" };
            _filterBeerTypes.AddRange(_beerTypes);

            // Set the ItemsSource for the filter picker
            filterPicker.ItemsSource = _filterBeerTypes;

            // Set the initial selection to "All"
            filterPicker.SelectedIndex = 0;

            // Initial population of the beer list
            _filteredBeers = new ObservableCollection<Beer>(_beers);
            beerListView.ItemsSource = _filteredBeers;
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Beer beer)
            {
                _beerService.UpdateBeer(beer);
                // Optionally, refresh the list or provide user feedback
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Beer beer)
            {
                _beerService.DeleteBeer(beer.BeerId);
                _beers.Remove(beer);
                beerListView.ItemsSource = null;
                beerListView.ItemsSource = _beers;
            }
        }

        private void OnBeerTypePickerBindingContextChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker != null)
            {
                picker.ItemsSource = _beerTypes; // This is your list of beer types as strings
                var beer = picker.BindingContext as Beer;
                if (beer != null)
                {
                    picker.SelectedItem = beer.Type.ToString();
                }
            }
        }

        private void OnProducerPickerBindingContextChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker != null)
            {
                picker.ItemsSource = _producerIdToName.Values.ToList(); // This is your list of producer names
                var beer = picker.BindingContext as Beer;
                if (beer != null && _producerIdToName.ContainsKey(beer.ProducerId))
                {
                    picker.SelectedItem = _producerIdToName[beer.ProducerId];
                }
            }
        }
        private void OnFilterPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedType = picker.SelectedItem as string;

            if (selectedType == "All")
            {
                _filteredBeers = new ObservableCollection<Beer>(_beers);
            }
            else
            {
                _filteredBeers = new ObservableCollection<Beer>(
                    _beers.Where(beer => beer.Type.ToString() == selectedType)
                );
            }

            // Update the ListView's ItemsSource to the new filtered list
            beerListView.ItemsSource = _filteredBeers;
        }

        private void OnBeerTypePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var beer = picker.BindingContext as Beer;
            if (picker.SelectedItem != null && beer != null)
            {
                beer.Type = (BeerType)Enum.Parse(typeof(BeerType), picker.SelectedItem.ToString());
            }
        }

        private void OnProducerPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var beer = picker.BindingContext as Beer;
            if (picker.SelectedItem != null && beer != null)
            {
                var selectedProducerName = picker.SelectedItem.ToString();
                var selectedProducer = _producerIdToName.FirstOrDefault(p => p.Value == selectedProducerName);
                beer.ProducerId = selectedProducer.Key;
            }
        }

    }
}
