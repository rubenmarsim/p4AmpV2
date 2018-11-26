using Android.Content;
using Android.Widget;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AmpProps
{
    public class MainView : ContentPage
	{
        #region variables
        string valDividir;
        string valDividirsinPropina;
        string valServicio;
        string valTotalxPersona;
        string valPropinaTotal;
        string valPropinaxPersona;
        private Context Context;
        #endregion
        public MainView ()
		{
            #region Instancias
            var CTipInfo = new TipInfo();
            #endregion

            #region Layout
            Label lblHeader = new Label
            {
                Text = "Ampliacion Propinas Ruben Martinez",
                FontSize = 23,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Xamarin.Forms.Button btnClear = new Xamarin.Forms.Button
            {
                IsEnabled=false,
                Text = "Borrar",
            };
            Xamarin.Forms.Button btnConfig = new Xamarin.Forms.Button
            {
                Text = "Config"
            };
            Label lblImporte = new Label
            {
                FontSize = 20,
                Text = "Tu Cuenta es:",
                HorizontalOptions=LayoutOptions.Fill,
            };
            Editor edtrImporte = new Editor
            {                
                TextColor=Color.LimeGreen,
                Keyboard = Keyboard.Numeric,
            };
            Label lblDividir = new Label
            {
                FontSize = 20,
                Text = "Dividir: ",
                HorizontalOptions = LayoutOptions.Fill,
            };
            var oListPickerDividir = new List<string>();
                oListPickerDividir.Add("Uno");
                oListPickerDividir.Add("Dos");
                oListPickerDividir.Add("Tres");
                oListPickerDividir.Add("Cuatro");
                oListPickerDividir.Add("Cinco");
                oListPickerDividir.Add("Seis");
                oListPickerDividir.Add("Siete");
                oListPickerDividir.Add("Ocho");
                oListPickerDividir.Add("Nueve");
                oListPickerDividir.Add("Diez");
                oListPickerDividir.Add("Once");
                oListPickerDividir.Add("Doce");
                oListPickerDividir.Add("Trece");
                oListPickerDividir.Add("Catorce");
                oListPickerDividir.Add("Quince");
                oListPickerDividir.Add("Dieciseis");
                oListPickerDividir.Add("Diecisiete");
                oListPickerDividir.Add("Dieciocho");
                oListPickerDividir.Add("Diecinueve");
                oListPickerDividir.Add("Veinte");
            Picker pkrDividir = new Picker
            {
                TextColor =Color.LimeGreen,
                SelectedItem = "Uno",
                ItemsSource = oListPickerDividir,
                Title = "Personas a dividir la cuenta",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = false,
            };
            Label lblDividirsinPropina = new Label
            {
                BackgroundColor =Color.LimeGreen,
                FontSize = 20,
                Text = "Por persona sin propina: ",
                HorizontalOptions = LayoutOptions.Fill,
            };
            Label lblServicio = new Label
            {
                FontSize = 20,
                Text = "Servicio: ",
                HorizontalOptions = LayoutOptions.Fill,
            };
            var oListPickerServicio = new List<string>();
                oListPickerServicio.Add("Una Estrella 5%");
                oListPickerServicio.Add("Dos Estrellas 10%");
                oListPickerServicio.Add("Tres Estrellas 15%");
                oListPickerServicio.Add("Cuatro Estrellas 20%");
                oListPickerServicio.Add("Cinco Estrellas 25%");
            Picker pkrServicio = new Picker
            {
                TextColor =Color.LimeGreen,
                SelectedItem = "Una Estrella",
                ItemsSource = oListPickerServicio,
                Title = "Valoracion del servicio",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = false,
            };
            Label lblTotal = new Label
            {
                BackgroundColor = Color.LimeGreen,
                FontSize = 20,
                Text = "Total con propina: ",
                HorizontalOptions = LayoutOptions.Fill,
            };
            Editor edtrTotal = new Editor
            {
                BackgroundColor = Color.LimeGreen,
                TextColor = Color.Black,
                IsEnabled = false,
                FontAttributes = FontAttributes.Bold,
            };
            Label lblTotalxPersona = new Label
            {
                FontSize = 20,
                Text = "Total por persona: ",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Label lblPropinaTotal = new Label
            {
                FontSize = 20,
                Text = "Propina Total: ",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            Label lblPropinaxPersona = new Label
            {
                FontSize = 20,
                Text = "Propina por persona: ",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            #endregion

            #region Eventos
            edtrImporte.Unfocused += (sender, e) =>
            {
                if (edtrImporte.Text.Equals(""))
                {
                    pkrDividir.IsEnabled = false;
                    pkrServicio.IsEnabled = false;
                    btnClear.IsEnabled = false;
                    Android.Widget.Toast.MakeText(Android.App.Application.Context, "Introduce un valor valido", ToastLength.Long).Show();
                }
                else
                {
                    pkrDividir.IsEnabled = true;
                    btnClear.IsEnabled = true;                    
                    CTipInfo.Importe = double.Parse(edtrImporte.Text);
                    pkrDividir.SelectedItem = "Uno";
                    pkrServicio.SelectedItem = "Una Estrella 5%";

                    CTipInfo.Calculos();

                    valDividir = CTipInfo.Dividir.ToString("#.##");
                    valDividirsinPropina = CTipInfo.DividirsinPropina.ToString("#.##");
                    valServicio = CTipInfo.Servicio.ToString("#.##");

                    edtrTotal.Text = "$" + CTipInfo.Total.ToString("#.##");

                    valTotalxPersona = CTipInfo.TotalxPersona.ToString("#.##");
                    lblTotalxPersona.Text = "Total por persona: $" + valTotalxPersona;
                    valPropinaTotal = CTipInfo.PropinaTotal.ToString("#.##");
                    lblPropinaTotal.Text = "Propina Total: $" +valPropinaTotal;
                    valPropinaxPersona = CTipInfo.PropinaxPersona.ToString("#.##");
                    lblPropinaxPersona.Text = "Propina por persona: $" +valPropinaxPersona;
                }                 
            };
            pkrDividir.SelectedIndexChanged += (sender, e) =>
            {
                if (edtrImporte.Text.Equals(""))
                {
                    pkrDividir.IsEnabled = false;
                    pkrServicio.IsEnabled = false;
                    btnClear.IsEnabled = false;
                    Android.Widget.Toast.MakeText(Android.App.Application.Context, "Introduce un valor valido", ToastLength.Long).Show();
                }
                else
                {
                    CTipInfo.Importe = double.Parse(edtrImporte.Text);
                    CTipInfo.DividirItem = pkrDividir.SelectedItem.ToString();

                    CTipInfo.Calculos();

                    valDividir = CTipInfo.Dividir.ToString("#.##");
                    lblDividir.Text = "Dividir: " + valDividir;
                    valDividirsinPropina = CTipInfo.DividirsinPropina.ToString("#.##");
                    lblDividirsinPropina.Text = "Por persona sin propina: " + valDividirsinPropina;

                    valServicio = CTipInfo.Servicio.ToString("#.##");
                    edtrTotal.Text = "$" + CTipInfo.Total.ToString();

                    valTotalxPersona = CTipInfo.TotalxPersona.ToString("#.##");
                    lblTotalxPersona.Text = "Total por persona: $" + valTotalxPersona;
                    valPropinaTotal = CTipInfo.PropinaTotal.ToString("#.##");
                    lblPropinaTotal.Text = "Propina Total: $" + valPropinaTotal;
                    valPropinaxPersona = CTipInfo.PropinaxPersona.ToString("#.##");
                    lblPropinaxPersona.Text = "Propina por persona: $" + valPropinaxPersona;
                    pkrServicio.IsEnabled = true;
                }
                
            };
            pkrServicio.SelectedIndexChanged += (sender, e) =>
            {
                if (edtrImporte.Text.Equals(""))
                {
                    pkrDividir.IsEnabled = false;
                    pkrServicio.IsEnabled = false;
                    btnClear.IsEnabled = false;
                    Android.Widget.Toast.MakeText(Android.App.Application.Context, "Introduce un valor valido", ToastLength.Long).Show();
                }
                else
                {
                    CTipInfo.Importe = double.Parse(edtrImporte.Text);
                    CTipInfo.DividirItem = pkrDividir.SelectedItem.ToString();
                    CTipInfo.ServicioItem = pkrServicio.SelectedItem.ToString();

                    CTipInfo.Calculos();

                    valDividir = CTipInfo.Dividir.ToString("#.##");
                    valDividirsinPropina = CTipInfo.DividirsinPropina.ToString("#.##");
                    valServicio = CTipInfo.Servicio.ToString("#.##");
                    lblServicio.Text = "Servicio: " + valServicio + "%";

                    edtrTotal.Text = "$" + CTipInfo.Total.ToString("#.##");

                    valTotalxPersona = CTipInfo.TotalxPersona.ToString("#.##");
                    lblTotalxPersona.Text = "Total por persona: $" + valTotalxPersona;
                    valPropinaTotal = CTipInfo.PropinaTotal.ToString("#.##");
                    lblPropinaTotal.Text = "Propina Total: $" + valPropinaTotal;
                    valPropinaxPersona = CTipInfo.PropinaxPersona.ToString("#.##");
                    lblPropinaxPersona.Text = "Propina por persona: $" + valPropinaxPersona;
                }
            };
            btnClear.Clicked += (sender, e) =>
            {
                if (edtrImporte.Text.Equals(""))
                {
                    pkrDividir.IsEnabled = false;
                    pkrServicio.IsEnabled = false;
                    btnClear.IsEnabled = false;
                    Android.Widget.Toast.MakeText(Android.App.Application.Context, "Introduce un valor valido", ToastLength.Long).Show();
                }
                else
                {
                    edtrImporte.Text = "";
                    lblDividir.Text = "Dividir:";
                    pkrDividir.SelectedItem = "Uno";
                    lblDividirsinPropina.Text = "Por Persona sin Propina:";
                    lblServicio.Text = "Servicio:";
                    pkrServicio.SelectedItem = "Una Estrella";
                    edtrTotal.Text = "";
                    lblTotalxPersona.Text = "Total por persona";
                    lblPropinaTotal.Text = "Total Propina";
                    lblPropinaxPersona.Text = "Propina por persona";
                    edtrImporte.Focus();
                    Toast.MakeText(Android.App.Application.Context, "Borrado correctamente", ToastLength.Long).Show();
                }
            };
            edtrImporte.Focused += (sender, e) =>
            {
                edtrImporte.Text = "";
            };
            btnConfig.Clicked += async (sender, args) =>
                await Navigation.PushModalAsync(new ConfigView());
            #endregion

            #region Layout
            var stackLayout = new StackLayout
            {
                Children =
                {
                    lblHeader, btnClear, btnConfig, lblImporte, edtrImporte, lblDividir,
                    pkrDividir, lblDividirsinPropina, lblServicio, pkrServicio, lblTotal,
                    edtrTotal, lblTotalxPersona, lblPropinaTotal, lblPropinaxPersona
                }
            };
            Content = new Xamarin.Forms.ScrollView
            {
                Content = stackLayout
            };
            #endregion
        }
    }
}