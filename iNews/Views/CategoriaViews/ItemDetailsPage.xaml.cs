using System;
using System.Collections.Generic;
using iNews.DB;
using iNews.Model;
using LiteDB;
using Xamarin.Forms;

namespace iNews.Views.CategoriaViews
{
    public partial class ItemDetailsPage : ContentPage
    {
        LiteDatabase _dataBase;
        LiteCollection<Categoria> Categorias;

        public ItemDetailsPage(Categoria categoria)
        {
            InitializeComponent();
            _dataBase = new LiteDatabase(DependencyService.Get<IHelper>().GetFilePath("Banco.db"));
            Categorias = _dataBase.GetCollection<Categoria>();
            var itemDetails = categoria;
            this.BindingContext = itemDetails;
        }

        public async void DoneEditing()
        {
            await Navigation.PopAsync();
        }

        public async void SalveEditing()
        {
            Categoria categoria = new Categoria
            {
                CategoriaId = (int)lblCategoriaId.BindingContext,
                Nome = txtNome.Text,
            };
            Categorias.Update(categoria);
            await Navigation.PopAsync();
        }
    }
}
