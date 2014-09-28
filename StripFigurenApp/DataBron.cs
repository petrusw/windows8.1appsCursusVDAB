using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace StripFigurenApp
{
    public class DataBron
    {
        public List<StripFiguur> GetStripFiguren()
        {
            List<StripFiguur> Helden = new List<StripFiguur>();

            Helden.Add(new StripFiguur
            {
                Reeks = "Asterix",
                Naam = "Asterix",
                Email = "asterix@armorica.ga",
                //goed opletten dat het - teken in ms-appx herkent word!!!!
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/Asterix.jpg"))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Asterix",
                Naam = "Obelix",
                Email = "obelix@armorica.ga",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/obelix.jpg"))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Suske en Wiske",
                Naam = "Suske",
                Email = "suske@standaard.be",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/suske.jpg"
                 ))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Suske en Wiske",
                Naam = "Wiske",
                Email = "wiske@standaard.be",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/wiske.jpg"))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Suske en Wiske",
                Naam = "Lambik",
                Email = "Lambik@standaard.be",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/lambik.jpg"))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Suske en Wiske",
                Naam = "Sidonia",
                Email = "Sidonia@standaard.be",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/sidonia.jpg",UriKind.RelativeOrAbsolute))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Kiekeboe",
                Naam = "Marcel",
                Email = "Marcel@kiekeboe.be",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/marcel.jpg"))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Kiekeboe",
                Naam = "Fanny",
                Email = "Fanny@kiekeboe.be",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/fanny.jpg"))
            });

            Helden.Add(new StripFiguur
            {
                Reeks = "Kiekeboe",
                Naam = "Konstantinopel",
                Email = "Konstantinopel@kiekeboe.be",
                Prentje = new BitmapImage(new Uri("ms-appx:///Assets/konstantinopel.jpg"))
            });
            return Helden;
        }
    }
}
