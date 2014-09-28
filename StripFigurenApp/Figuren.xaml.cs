using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StripFigurenApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Figuren : Page 
    {
        private ObservableCollection<StripFiguur> Helden = new ObservableCollection<StripFiguur>();
        private CollectionViewSource StripFiguurCollectie = new CollectionViewSource { IsSourceGrouped = true, ItemsPath = new PropertyPath("Figuren") };
        public Figuren()
        {
            this.InitializeComponent();
      
     Helden.Add(new StripFiguur { 
         Reeks="Asterix",
          Naam = "Asterix", Email = "asterix@armorica.ga", 
          // volgens de cursus moet het op deze manier maar dit kan niet volgens microsoft !!! 
            //Prentje = new BitmapImage(new Uri("ms‐appx:///Assets/Asterix.jpg",  
            //  UriKind.RelativeOrAbsolute)) 
            // Dit is de juiste manier om dit te doen
          Prentje = new BitmapImage(new Uri(this.BaseUri,"Assets/asterix.jpg")) 
      });

     Helden.Add(new StripFiguur
     {
         Reeks = "Asterix",
         Naam = "Obelix",
         Email = "obelix@armorica.ga",
         Prentje = new BitmapImage(new Uri(this.BaseUri,"Assets/obelix.jpg"
           ))
     });

     Helden.Add(new StripFiguur
     {
         Reeks = "Suske en Wiske",
         Naam = "Suske",
         Email = "suske@standaard.be",
         Prentje = new BitmapImage(new Uri(this.BaseUri,"Assets/suske.jpg"))
     });

     Helden.Add(new StripFiguur
     {
         Reeks = "Suske en Wiske",
         Naam = "Wiske",
         Email = "wiske@standaard.be",
         Prentje = new BitmapImage(new Uri(this.BaseUri, "Assets/wiske.jpg"))
     });

     Helden.Add(new StripFiguur
     {
         Reeks = "Suske en Wiske",
         Naam = "Lambik",
         Email = "Lambik@standaard.be",
         Prentje = new BitmapImage(new Uri(this.BaseUri, "Assets/lambik.jpg"))
     });

     Helden.Add(new StripFiguur
     {
         Reeks = "Suske en Wiske",
         Naam = "Sidonia",
         Email = "Sidonia@standaard.be",
         Prentje = new BitmapImage(new Uri(this.BaseUri, "Assets/sidonia.jpg"))
     });

     Helden.Add(new StripFiguur
     {
         Reeks = "Kiekeboe",
         Naam = "Marcel",
         Email = "Marcel@kiekeboe.be",
         Prentje = new BitmapImage(new Uri(this.BaseUri, "Assets/marcel.jpg"))
     });

     Helden.Add(new StripFiguur
     {
         Reeks = "Kiekeboe",
         Naam = "Fanny",
         Email = "Fanny@kiekeboe.be",
         Prentje = new BitmapImage(new Uri(this.BaseUri, "Assets/fanny.jpg"))
     });

     Helden.Add(new StripFiguur
     {
         Reeks="Kiekeboe",
         Naam = "Konstantinopel",
         Email = "Konstantinopel@kiekeboe.be",
         Prentje = new BitmapImage(new Uri(this.BaseUri, "Assets/konstantinopel.jpg"))
     });
      //StripListView.ItemsSource = Helden;
      //StripGridView.ItemsSource = Helden;
      var groupedFiguren = Helden.GroupBy(x => x.Reeks).Select(x => new StripReeks { ReeksNaam = x.Key, Figuren = x.ToList() });
      StripFiguurCollectie.Source = groupedFiguren.ToList();
      GroupedFigurenGridView.ItemsSource = StripFiguurCollectie.View;
        }

        private void FiguurDetails_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string naam = ((StripFiguur)((FiguurDetails)sender).DataContext).Naam;
            XmlDocument template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            XmlNodeList text = template.GetElementsByTagName("text");
            text[0].AppendChild(template.CreateTextNode(naam));
            ToastNotification toast = new ToastNotification(template);
            ToastNotificationManager.CreateToastNotifier().Show(toast); 
        }

        //private void StripGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (StripGridView.SelectedIndex >=0)
        //    {
        //        ButtonVerwijderen.Visibility = Visibility.Visible;
        //        GeselecteerdeFiguur.Text = String.Format("Geselecteerde figuur : {0} ({1})",
        //        ((StripFiguur)e.AddedItems[0]).Naam, ((StripFiguur)e.AddedItems[0]).Email); 
        //    }
        //    else
        //    {
        //        GeselecteerdeFiguur.Text = string.Empty;
        //        ButtonVerwijderen.Visibility = Visibility.Collapsed;
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (StripGridView.SelectedIndex >=0)
        //    {
        //        GeselecteerdeFiguur.Text = string.Empty;
        //        Helden.RemoveAt(StripGridView.SelectedIndex);
        //        ButtonVerwijderen.Visibility = Visibility.Collapsed;
        //    }
        //}
        
    }
}
