using System;
using System.IO;
using iNews.DB;
using iNews.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Helper))]
namespace iNews.iOS
{
    public class Helper : IHelper
    {
        public string GetFilePath(string file)
        {
            string document = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string library = Path.Combine(document, "..", "Library", "Databases");

            if (!Directory.Exists(library))
            {
                Directory.CreateDirectory(library);
            }

            return Path.Combine(library, file);
        }
    }
}