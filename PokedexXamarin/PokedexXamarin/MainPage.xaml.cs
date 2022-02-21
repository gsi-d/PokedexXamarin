using PokedexXamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_ConsumindoWebAPI.Service;

namespace PokedexXamarin
{
    public partial class MainPage : ContentPage
    {
        DataService dataService;
        public List<Skills> pokemon;
        public MainPage()
        {
            InitializeComponent();
            dataService = new DataService();
        }

        public async void Listar()
        {
            pokemon = await dataService.GetProdutosAsync();
            listaPokemons.ItemsSource
        }
    }
}
