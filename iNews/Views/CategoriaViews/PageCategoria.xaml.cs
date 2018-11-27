using System;
using System.Collections.ObjectModel;
using iNews.Model;
using Xamarin.Forms;
using iNews.Views.CategoriaViews;
using System.Collections.Generic;
using LiteDB;
using iNews.DB;
using System.Linq;

namespace iNews.Views.CategoriaViews
{
    public partial class PageCategoria : ContentPage
    {

        LiteDatabase _dataBase;
        LiteCollection<Categoria> Categorias;

        public PageCategoria()
        {
            InitializeComponent();

            _dataBase = new LiteDatabase(DependencyService.Get<IHelper>().GetFilePath("Banco.db"));
            Categorias = _dataBase.GetCollection<Categoria>();
            lvCategorias.ItemsSource = Categorias.FindAll();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            lvCategorias.ItemsSource = Categorias.FindAll();
        }

        private async void Nova_Categoria(object sender, EventArgs e)
        {
            var PageNovaCategoria = new PageNovaCategoria();
            await Navigation.PushAsync(PageNovaCategoria);
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var smi = mi.CommandParameter.ToString();
            var action = await DisplayActionSheet("Atenção", "Não", "Sim", "Deseja deletar o registro ?");
            if (action == "Sim")
            {
                var categoria = Categorias.FindAll().FirstOrDefault(x => x.CategoriaId == Convert.ToInt32(smi));
                Categorias.Delete(categoria?.CategoriaId);
                lvCategorias.ItemsSource = Categorias.FindAll();
            }
        }

        public async void OnEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var smi = mi.CommandParameter.ToString();
            var categoria = Categorias.FindAll().FirstOrDefault(x => x.CategoriaId == Convert.ToInt32(smi));
            if (categoria == null)
                return;
            await this.Navigation.PushAsync(new ItemDetailsPage(categoria));
        }
    }
}
