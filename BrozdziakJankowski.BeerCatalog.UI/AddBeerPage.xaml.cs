using BrozdziakJankowski.BeerCatalog.Core;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace BrozdziakJankowski.BeerCatalog.UI
{
    public partial class AddBeerPage : ContentPage
    {
        private readonly IBeerService _beerService;
        private readonly IProducerService _producerService;
        private Dictionary<string, int> _producerNameToIdMap = new Dictionary<string, int>();

        public AddBeerPage(IBeerService beerService, IProducerService producerService)
        {
            InitializeComponent();
            _beerService = beerService;
            _producerService = producerService;

            LoadProducers();
            LoadBeerTypes();
        }

        private void LoadProducers()
        {
            var producers = _producerService.GetAllProducers();
            foreach (var producer in producers)
            {
                producerPicker.Items.Add(producer.Name);
                _producerNameToIdMap[producer.Name] = producer.ProducerId;
            }
        }

        private void LoadBeerTypes()
        {
            foreach (var type in Enum.GetValues(typeof(BeerType)))
            {
                beerTypePicker.Items.Add(type.ToString());
            }
        }

        private async void OnAddBeerClicked(object sender, EventArgs e)
        {
            var selectedProducerName = producerPicker.SelectedItem?.ToString();
            if (_producerNameToIdMap.TryGetValue(selectedProducerName, out int producerId))
            {
                var selectedProducer = _producerService.GetProducerById(producerId);
                if (selectedProducer != null)
                {
                    var newBeer = new Beer
                    {
                        Name = beerNameEntry.Text,
                        AlcoholContent = double.Parse(alcoholContentEntry.Text),
                        Type = (BeerType)Enum.Parse(typeof(BeerType), beerTypePicker.SelectedItem.ToString()),
                        ProducerId = selectedProducer.ProducerId
                    };

                    _beerService.AddBeer(newBeer);

                    await DisplayAlert("Success", "Beer added successfully", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Error", "Producer not found", "OK");
            }
        }
    }
}