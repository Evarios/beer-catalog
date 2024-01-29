using BrozdziakJankowski.BeerCatalog.BL;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using Microsoft.Maui.Controls;
using System;

namespace BrozdziakJankowski.BeerCatalog.UI
{
    public partial class EditProducerPage : ContentPage
    {
        private readonly IProducerService _producerService;
        private int _producerId;

        public EditProducerPage(int producerId)
        {
            InitializeComponent();
            _producerId = producerId;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LoadProducerAsync();
        }

        private void LoadProducerAsync()
        {
            var producer = _producerService.GetProducerById(_producerId);
            if (producer != null)
            {
                producerNameEntry.Text = producer.Name;
                producerCountryEntry.Text = producer.Country;
            }
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            var producerName = producerNameEntry.Text;
            var producerCountry = producerCountryEntry.Text;

            // Create or update the Producer object with the input data
            var producer = new Producer
            {
                ProducerId = _producerId,
                Name = producerName,
                Country = producerCountry
            };

            // Use the ProducerService to update the producer
            _producerService.UpdateProducer(producer);

            // Navigate back to the Producer List page
            await Navigation.PopAsync();
        }
    }
}
