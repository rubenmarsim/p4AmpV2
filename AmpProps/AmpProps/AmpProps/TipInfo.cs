using System;
using System.Collections.Generic;
using System.Text;

namespace AmpProps
{
    public class TipInfo
    {
        private double _Importe;
        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }
        private double _Dividir;
        public double Dividir
        {
            get { return _Dividir; }
            set { _Dividir = value; }
        }
        private string _DividirItem;
        public string DividirItem
        {
            get { return _DividirItem; }
            set { _DividirItem = value; }
        }
        private double _DividirsinPropina;

        public double DividirsinPropina
        {
            get { return _DividirsinPropina; }
            set { _DividirsinPropina = value; }
        }
        private double _Servicio;
        public double Servicio
        {
            get { return _Servicio; }
            set { _Servicio = value; }
        }
        private string _ServicioItem;
        public string ServicioItem
        {
            get { return _ServicioItem; }
            set { _ServicioItem = value; }
        }
        private double _Total;

        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        private double _TotalxPersona;

        public double TotalxPersona
        {
            get { return _TotalxPersona; }
            set { _TotalxPersona = value; }
        }
        private double _PropinaTotal;

        public double PropinaTotal
        {
            get { return _PropinaTotal; }
            set { _PropinaTotal = value; }
        }
        private double _PropinaxPersona;

        public double PropinaxPersona
        {
            get { return _PropinaxPersona; }
            set { _PropinaxPersona = value; }
        }

        public void Calculos()
        {
            Dividir = 1;
            Servicio = 5;
            GetPersonasDividir();
            DividirsinPropina = Importe / Dividir;
            GetServicio();
            Total = Importe + Importe*Servicio / 100;
            TotalxPersona = Total / Dividir;
            PropinaTotal = Total - Importe;
            PropinaxPersona = PropinaTotal / Dividir;
        }
        public void GetPersonasDividir()
        {
            switch (DividirItem)
            {
                case "Uno":
                    Dividir = 1;
                    break;
                case "Dos":
                    Dividir = 2;
                    break;
                case "Tres":
                    Dividir = 3;
                    break;
                case "Cuatro":
                    Dividir = 4;
                    break;
                case "Cinco":
                    Dividir = 5;
                    break;
                case "Seis":
                    Dividir = 6;
                    break;
                case "Siete":
                    Dividir = 7;
                    break;
                case "Ocho":
                    Dividir = 8;
                    break;
                case "Nueve":
                    Dividir = 9;
                    break;
                case "Diez":
                    Dividir = 10;
                    break;
                case "Once":
                    Dividir = 11;
                    break;
                case "Doce":
                    Dividir = 12;
                    break;
                case "Trece":
                    Dividir = 13;
                    break;
                case "Catorce":
                    Dividir = 14;
                    break;
                case "Quince":
                    Dividir = 15;
                    break;
                case "Dieciseis":
                    Dividir = 16;
                    break;
                case "Diecisiete":
                    Dividir = 17;
                    break;
                case "Dieciocho":
                    Dividir = 18;
                    break;
                case "Diecinueve":
                    Dividir = 19;
                    break;
                case "Veinte":
                    Dividir = 20;
                    break;
            }
                
        }
        public void GetServicio()
        {
            switch (ServicioItem)
            {
                case "Una Estrella 5%":
                    Servicio = 5;
                    break;
                case "Dos Estrellas 10%":
                    Servicio = 10;
                    break;
                case "Tres Estrellas 15%":
                    Servicio = 15;
                    break;
                case "Cuatro Estrellas 20%":
                    Servicio = 20;
                    break;
                case "Cinco Estrellas 25%":
                    Servicio = 25;
                    break;
            }
        }

    }
}
