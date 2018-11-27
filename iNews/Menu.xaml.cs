using System;
using System.Collections.Generic;
using iNews.Views;
using iNews.Views.CategoriaViews;
using iNews.Views.NoticiaViews;
using Xamarin.Forms;

namespace iNews
{
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuDetail());
        }

        public void GoHome(object sender, System.EventArgs e)
        {
            //Detail.Navigation.PushAsync(new MenuDetail());
            IsPresented = false;
        }

        public void GoPageNoticia(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new PageNoticia());
            IsPresented = false;
        }

        public void GoPageCategoria(object sender, System.EventArgs e)
        {
            Detail.Navigation.PushAsync(new PageCategoria());
            IsPresented = false;
        }
    }
}
