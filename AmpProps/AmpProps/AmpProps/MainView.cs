﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

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
            Picker pkrDividir = new Picker
            {
                TextColor=Color.LimeGreen,
                SelectedItem = "Uno",
                ItemsSource = oListPickerDividir,
                Title = "Personas a dividir la cuenta",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
            };
            Label lblDividirsinPropina = new Label
            {
                BackgroundColor=Color.LimeGreen,
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
                oListPickerServicio.Add("Una Estrella");
                oListPickerServicio.Add("Dos Estrellas");
                oListPickerServicio.Add("Tres Estrellas");
                oListPickerServicio.Add("Cuatro Estrellas");
                oListPickerServicio.Add("Cinco Estrellas");
            Picker pkrServicio = new Picker
            {
                TextColor=Color.LimeGreen,
                SelectedItem = "Una Estrella",
                ItemsSource = oListPickerServicio,
                Title = "Valoracion del servicio",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
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
                IsEnabled = false,
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
                CTipInfo.Importe = double.Parse(edtrImporte.Text);

                CTipInfo.Calculos();

                valDividir = CTipInfo.Dividir.ToString();
                valDividirsinPropina = CTipInfo.DividirsinPropina.ToString();
                valServicio = CTipInfo.Servicio.ToString();

                edtrTotal.Text = CTipInfo.Total.ToString();

                valTotalxPersona = CTipInfo.TotalxPersona.ToString();
                lblTotalxPersona.Text = "Total por persona: " + valTotalxPersona;
                valPropinaTotal = CTipInfo.PropinaTotal.ToString();
                lblPropinaTotal.Text = "Propina Total: " + valPropinaTotal;
                valPropinaxPersona = CTipInfo.PropinaxPersona.ToString();
                lblPropinaxPersona.Text = "Propina por persona: " + valPropinaxPersona;
            };
            pkrDividir.SelectedIndexChanged += (sender, e) =>
            {
                CTipInfo.Importe = double.Parse(edtrImporte.Text);
                CTipInfo.DividirItem = pkrDividir.SelectedItem.ToString();

                CTipInfo.Calculos();

                valDividir = CTipInfo.Dividir.ToString();
                lblDividir.Text = "Dividir: " + valDividir;
                valDividirsinPropina = CTipInfo.DividirsinPropina.ToString();
                lblDividirsinPropina.Text = "Por persona sin propina: " + valDividirsinPropina;

                valServicio = CTipInfo.Servicio.ToString();
                edtrTotal.Text = CTipInfo.Total.ToString();

                valTotalxPersona = CTipInfo.TotalxPersona.ToString();
                lblTotalxPersona.Text = "Total por persona: " + valTotalxPersona;
                valPropinaTotal = CTipInfo.PropinaTotal.ToString();
                lblPropinaTotal.Text = "Propina Total: " + valPropinaTotal;
                valPropinaxPersona = CTipInfo.PropinaxPersona.ToString();
                lblPropinaxPersona.Text = "Propina por persona: " + valPropinaxPersona;
            };
            pkrServicio.SelectedIndexChanged += (sender, e) =>
            {
                CTipInfo.Importe = double.Parse(edtrImporte.Text);
                CTipInfo.DividirItem = pkrDividir.SelectedItem.ToString();
                CTipInfo.ServicioItem = pkrServicio.SelectedItem.ToString();

                CTipInfo.Calculos();

                valDividir = CTipInfo.Dividir.ToString();
                valDividirsinPropina = CTipInfo.DividirsinPropina.ToString();
                valServicio = CTipInfo.Servicio.ToString();
                lblServicio.Text = "Servicio: " + valServicio + "%";

                edtrTotal.Text = CTipInfo.Total.ToString();

                valTotalxPersona = CTipInfo.TotalxPersona.ToString();
                lblTotalxPersona.Text = "Total por persona: " + valTotalxPersona;
                valPropinaTotal = CTipInfo.PropinaTotal.ToString();
                lblPropinaTotal.Text = "Propina Total: " + valPropinaTotal;
                valPropinaxPersona = CTipInfo.PropinaxPersona.ToString();
                lblPropinaxPersona.Text = "Propina por persona: " + valPropinaxPersona;
            };
            #endregion

            #region Layout
            var stackLayout = new StackLayout
            {
                Children =
                {
                    lblHeader, lblImporte, edtrImporte, lblDividir, pkrDividir,
                    lblDividirsinPropina, lblServicio, pkrServicio, lblTotal,
                    edtrTotal, lblTotalxPersona, lblPropinaTotal, lblPropinaxPersona
                }
            };
            Content = new ScrollView
            {
                Content = stackLayout
            };
            #endregion
        }
    }
}