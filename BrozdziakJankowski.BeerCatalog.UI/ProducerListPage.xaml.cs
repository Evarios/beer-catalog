using BrozdziakJankowski.BeerCatalog.Interfaces;
using BrozdziakJankowski.BeerCatalog.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrozdziakJankowski.BeerCatalog.UI;

public partial class ProducerListPage : ContentPage
{
    private readonly IProducerService _producerService;
    private List<Producer> _producers;

    public ProducerListPage(IProducerService producerService)
    {
        InitializeComponent();
        _producerService = producerService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        LoadProducers();
    }

    private void LoadProducers()
    {
        _producers = _producerService.GetAllProducers().ToList();
        producerListView.ItemsSource = _producers;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int producerId)
        {
            var producerToSave = _producers.FirstOrDefault(p => p.ProducerId == producerId);
            if (producerToSave != null)
            {
                _producerService.UpdateProducer(producerToSave);
            }
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int producerId)
        {
            // Find the producer to delete
            var producerToDelete = _producers.FirstOrDefault(p => p.ProducerId == producerId);
            if (producerToDelete != null)
            {
                // Delete the producer using the service
                _producerService.DeleteProducer(producerId);

                // Remove the producer from the list
                _producers.Remove(producerToDelete);
                producerListView.ItemsSource = null;
                producerListView.ItemsSource = _producers;
            }
        }
    }
}