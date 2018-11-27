using System;
using System.Collections.Generic;
using System.Linq;
using iNews.DB;
using iNews.Model;
using LiteDB;
using Xamarin.Forms;

namespace iNews.Views.NoticiaViews
{
    public partial class PageNovaNoticia : ContentPage
    {
        LiteDatabase _dataBase;
        LiteCollection<Noticia> Noticias;
        LiteCollection<Categoria> Categorias;
        Categoria categoriaSelect;

        public PageNovaNoticia()
        {
            InitializeComponent();
            _dataBase = new LiteDatabase(DependencyService.Get<IHelper>().GetFilePath("Banco.db"));
            Categorias = _dataBase.GetCollection<Categoria>();
            Noticias = _dataBase.GetCollection<Noticia>();
            pckCategorias.ItemsSource = Categorias.FindAll().ToList();
            BindingContext = this;
            lblDtNoticia.Text = "Data/Hora da Notícia: " + DateTime.Now.ToString();
        }

        public void pckCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var el = (Categoria)pckCategorias.SelectedItem;
            categoriaSelect = el;
            //await DisplayAlert("Atenção", $"Elemento selecionado foi { el.CategoriaId}", "Ok");
        }

        public async void AddNova_Noticia(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text) == true)
            {
                await DisplayAlert("Atenção!", "Valor inválido", "Cancelar");
                return;
            }

            if (Noticias.Exists(X => X.Titulo == txtTitulo.Text))
            {
                await DisplayAlert("Atenção!", "Já existe uma notícia com este título registrado: " + txtTitulo.Text, "Cancelar");
                return;
            }

            int idNoticia = Noticias.Count() == 0 ? 1 : (int)(Noticias.Max(x => x.NoticiaId) + 1);
            Noticia noticia = new Noticia
            {
                NoticiaId = idNoticia,
                categoria = categoriaSelect,
                Titulo = txtTitulo.Text,
                Descricao = edtDescricao.Text,
                DtNoticia = lblDtNoticia.Text,
            };
            Noticias.Insert(noticia);
            await Navigation.PopAsync();
        }
    }
}
