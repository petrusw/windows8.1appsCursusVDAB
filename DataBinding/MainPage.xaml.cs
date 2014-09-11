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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DataBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Persoon> persoonen = new List<Persoon>();
     
            
       
        public MainPage()
        {
            this.InitializeComponent();
            persoonen.Add(new Persoon
            {
                Voornaam = "Steven",
                Familienaam = "Lucas",
                Email = "steven.lucas@vdab.be"
            });
            persoonen.Add(new Persoon
            {
                Voornaam = "David",
                Familienaam = "Davidse",
                Email = "david.davidse@vdab.be"
            });
            persoonen.Add(new Persoon
            {
                Voornaam = "Jeroen",
                Familienaam = "Meus",
                Email = "jeroen.meus@vrt.be"
            });
        }

        private void PersonenLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Details.DataContext = (e.AddedItems[0] as Persoon);
        }

       
    }
}
