using System;
namespace iNews.Model
{
    public class Noticia
    {
        public int NoticiaId { get; set; }
        public Categoria categoria { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string DtNoticia { get; set; }

        public Noticia()
        {
        }
    }
}
