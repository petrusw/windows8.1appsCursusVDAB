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
using Windows.ApplicationModel.DataTransfer; 
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
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    SuskeEnWiskes = new DataBron().GetStripFiguren().Where(
        //                         s => s.Reeks == "Suske en Wiske").ToList();
        //    FiguurGridView.ItemsSource = SuskeEnWiskes;
        //}

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
        protected override void OnNavigatedTo(NavigationEventArgs e) 
        { 
            SuskeEnWiskes = new DataBron().GetStripFiguren() 
                .Where(s => s.Reeks == "Suske en Wiske").ToList(); 
            FiguurGridView.ItemsSource = SuskeEnWiskes; 
            Info.ContextMenuOpening += Info_ContextMenuOpening; 
        } 
        protected override void OnNavigatedFrom(NavigationEventArgs e) 
        { 
            Info.ContextMenuOpening -= Info_ContextMenuOpening; 
        } 
 
        private async void Info_ContextMenuOpening(object sender, ContextMenuEventArgs e) 
        { 
            e.Handled = true;
            TextBox t = (TextBox)sender;

            PopupMenu p = new PopupMenu();
            p.Commands.Add(new UICommand("Copy", null, 0));
            p.Commands.Add(new UICommand("Select All", null, 1));
            p.Commands.Add(new UICommandSeparator());
            p.Commands.Add(new UICommand("Background gray", null, 2));
            p.Commands.Add(new UICommand("Background white", null, 3));
            var selectedCommand = await p.ShowForSelectionAsync(GetTextBoxRect(t));

            if (selectedCommand != null)
            {
                String text;
                DataPackage d;

                switch ((int)selectedCommand.Id)
                {
                    case 0: //COPY 
                        text = t.SelectedText;
                        d = new DataPackage();
                        d.SetText(text);
                        Clipboard.SetContent(d);
                        break;
                    case 1: //SELECT ALL 
                        t.SelectAll();
                        break;
                    case 2:
                        Info.Background = new SolidColorBrush(Colors.LightGray);
                        break;
                    case 3:
                        Info.Background = new SolidColorBrush(Colors.White);
                        break;
                }

            } 
        }
        private Rect GetTextBoxRect(TextBox t)
        {
            Rect temp = t.GetRectFromCharacterIndex(t.SelectionStart, false);
            GeneralTransform transform = t.TransformToVisual(null);
            Point point = transform.TransformPoint(new Point());
            point.X = point.X + temp.X;
            point.Y = point.Y + temp.Y;
            return new Rect(point, new Size(temp.Width, temp.Height));
        } 
    }
}
