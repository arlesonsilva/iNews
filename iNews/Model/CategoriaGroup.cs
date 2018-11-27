using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace iNews.Model
{
    public class CategoriaGroup : ObservableCollection<Categoria>
    {
        public string Console { get; private set; }
        public CategoriaGroup(string console)
            : base()
        {
            Console = console;
        }

        public CategoriaGroup(string console, IEnumerable<Categoria> source)
        : base(source)
        {
            Console = console;
        }
    
    }
}
