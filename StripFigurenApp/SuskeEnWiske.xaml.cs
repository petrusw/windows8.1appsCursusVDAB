using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StripFigurenApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SuskeEnWiske : Page
    {
        private List<StripFiguur> SuskeEnWiskes;
        public SuskeEnWiske()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SuskeEnWiskes = new DataBron().GetStripFiguren().Where(
                                 s => s.Reeks == "Suske en Wiske").ToList();
            FiguurGridView.ItemsSource = SuskeEnWiskes;
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            //if (OpNaam.IsChecked.Value)
            //    SuskeEnWiskes = SuskeEnWiskes.OrderBy(s => s.Naam).ToList();
            //else
            //    SuskeEnWiskes = SuskeEnWiskes.OrderBy(s => s.Naam.Length).ToList();
            //FiguurGridView.ItemsSource = SuskeEnWiskes;
            //SorteerButton.Flyout.Hide();

            if (((MenuFlyoutItem)e.OriginalSource).Tag.ToString() == "naam")
                SuskeEnWiskes = SuskeEnWiskes.OrderBy(s => s.Naam).ToList();
            else
                SuskeEnWiskes = SuskeEnWiskes.OrderBy(s => s.Naam.Length).ToList();
            FiguurGridView.ItemsSource = SuskeEnWiskes;
            SorteerButton.Flyout.Hide(); 
        }

        private async void Title_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            PopupMenu p = new PopupMenu();
            p.Commands.Add(new UICommand("Background gray", command =>
                {
                    SuskeEnWiskeGrid.Background = new SolidColorBrush(Colors.LightGray);
                }, 0));
            p.Commands.Add(new UICommand("Background black", command =>
            {
                SuskeEnWiskeGrid.Background = new SolidColorBrush(Colors.Black);
            }, 1));
            await p.ShowForSelectionAsync(
               GetSenderRectangle((FrameworkElement)sender), Placement.Below); 
        }
        public static Rect GetSenderRectangle(FrameworkElement element)
        {
            GeneralTransform transform = element.TransformToVisual(null);
            Point point = transform.TransformPoint(new Point());
            Rect finalRect = new Rect(point, new Size(element.ActualWidth,
               element.ActualHeight));
            return finalRect;
        } 
    }
}
