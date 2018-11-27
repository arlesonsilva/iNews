using System;
using System.IO;
using iNews.DB;
using iNews.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(Helper))]
namespace iNews.Droid
{
    public class Helper : IHelper
    {
        public string GetFilePath(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }
    }
}
