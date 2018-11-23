using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AmpProps
{
    public class ConfigView : ContentPage
    {
        public ConfigView()
        {
            Label lblHeader = new Label
            {
                Text = "Options",
                FontSize=50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            Label lblNotifications = new Label
            {
                Text="Notifications",
                FontSize = 30,
                FontAttributes = FontAttributes.None,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            Switch swchNotifications = new Switch
            {
                HorizontalOptions = LayoutOptions.Start,
                IsToggled = true,
            };
            Label lblIdioma = new Label
            {
                Text = "Idioma",
                FontSize = 30,
                FontAttributes = FontAttributes.None,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            var oListPickerIdioma = new List<string>();
                oListPickerIdioma.Add("Castellano");
                oListPickerIdioma.Add("Catalan");
                oListPickerIdioma.Add("Ingles");
                oListPickerIdioma.Add("Japones");
                oListPickerIdioma.Add("Frances");
                oListPickerIdioma.Add("Ruso");
            Picker pkrIdioma = new Picker
            {
                SelectedItem = "Castellano",
                ItemsSource = oListPickerIdioma,
                Title = "Castellano",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = true,
            };
            Label lblFacebook = new Label
            {
                Text = "Facebook",
                FontSize = 30,
                FontAttributes = FontAttributes.None,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            Switch swchFacebook = new Switch
            {
                HorizontalOptions = LayoutOptions.Start,
                IsToggled = false,
            };
            Button btnVolver = new Button
            {
                Text="Volver",
            };
            btnVolver.Clicked += async (sender, args) =>
                await Navigation.PushModalAsync(new MainView());

            this.Content = new StackLayout
            {
                Children = {
                    lblHeader, lblNotifications, swchNotifications, lblIdioma, pkrIdioma,
                    lblFacebook,swchFacebook,btnVolver, 
                }
            };
        }
    }
}