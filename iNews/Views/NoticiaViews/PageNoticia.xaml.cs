using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using iNews.Model;
using LiteDB;
using iNews.DB;
using Xamarin.Forms;
using System.Linq;

namespace iNews.Views.NoticiaViews
{
    public partial class PageNoticia : ContentPage
    {
        LiteDatabase _dataBase;
        LiteCollection<Noticia> Noticias;
        LiteCollection<Categoria> Categorias;

        public PageNoticia()
        {
            InitializeComponent();
            _dataBase = new LiteDatabase(DependencyService.Get<IHelper>().GetFilePath("Banco.db"));
            Noticias = _dataBase.GetCollection<Noticia>();
            Categorias = _dataBase.GetCollection<Categoria>();
            lvNoticias.ItemsSource = Noticias.FindAll().GroupBy(X => X.categoria.Nome);
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            lvNoticias.ItemsSource = Noticias.FindAll().GroupBy(X => X.categoria.Nome);
        }

        private async void Nova_Noticia(object sender, EventArgs e)
        {
            var PageNovaNoticia = new PageNovaNoticia();
            await Navigation.PushAsync(PageNovaNoticia);
        }
    }
}
