using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using iNews.DB;
using iNews.Model;
using iNews.Views.CategoriaViews;
using LiteDB;
using Xamarin.Forms;

namespace iNews.Views.CategoriaViews
{
    public partial class PageNovaCategoria : ContentPage
    {
        LiteDatabase _dataBase;
        LiteCollection<Categoria> Categorias;

        public PageNovaCategoria()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            _dataBase = new LiteDatabase(DependencyService.Get<IHelper>().GetFilePath("Banco.db"));
            Categorias = _dataBase.GetCollection<Categoria>();
            var categoria = Categorias.FindAll().FirstOrDefault(x => x.CategoriaId == 2);
            txtNome.Text = categoria?.Nome;
            BindingContext = this;
        }

        public async void AddNova_Categoria(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text) == true)
            {
                await DisplayAlert("Atenção!", "Valor inválido", "Cancelar");
                return;
            }

            if (Categorias.Exists(X => X.Nome == txtNome.Text))
            {
                await DisplayAlert("Atenção!", "Já existe uma categoria com este nome registrado: " + txtNome.Text, "Cancelar");
                return;
            }

            int idCategoria = Categorias.Count() == 0 ? 1 : (int)(Categorias.Max(x => x.CategoriaId) + 1);
            Categoria categoria = new Categoria
            {
                CategoriaId = idCategoria,
                Nome = txtNome.Text,
            };
            Categorias.Insert(categoria);
            await Navigation.PopAsync();
        }


    }
}
