using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double ilkSayi = 0;
        private double ikinciSayi = 0;
        private string aktifIslem = ""; 
        private bool yeniSayiGirisi = true;
        private void Numara_Click(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            string girilenDeger = button.Content.ToString();  
            if (!yeniSayiGirisi) 
            {
                string sonIslem = aktifIslem;
            }


            if (yeniSayiGirisi)
            {
                
                if (girilenDeger == ".")
                {
                    SonucEkran.Text = "0.";
                }
                else
                {
                    SonucEkran.Text = girilenDeger;
                }
                
                yeniSayiGirisi = false; 
            }
            else
            {
                if (girilenDeger == ".")
                {
                    if (!SonucEkran.Text.Contains("."))
                    {
                        SonucEkran.Text += girilenDeger;
                    }
                }
                else if (SonucEkran.Text == "0")
                {
                    SonucEkran.Text = girilenDeger;
                }
                else
                {
                    SonucEkran.Text += girilenDeger;
                }
            }
            if (string.IsNullOrEmpty(aktifIslem))
            {
                GecmisEkran.Text = SonucEkran.Text;
            }
            
            else
            {
                GecmisEkran.Text = ilkSayi.ToString() + " " + aktifIslem + " " + SonucEkran.Text;
            }
        }
        private void Islem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string islem = button.Content.ToString();

            
            if (islem == "+" || islem == "-" || islem == "*" || islem == "/")
            {
                
                if (double.TryParse(SonucEkran.Text, out double mevcutDeger))
                {
                    ilkSayi = mevcutDeger;
                }
                aktifIslem = islem;
                GecmisEkran.Text = ilkSayi.ToString() + " " + aktifIslem;

                yeniSayiGirisi = true;
                

            }

            else if (islem == "%")
            {
                
                if (double.TryParse(SonucEkran.Text, out double mevcutDeger))
                {
                    SonucEkran.Text = (mevcutDeger / 100).ToString();
                }
                yeniSayiGirisi = true;
            }
            
            else if (islem == "clr") 
            {
                SonucEkran.Text = "0";
                
                ilkSayi = 0;
                ikinciSayi = 0;
                aktifIslem = "";
                yeniSayiGirisi = true;
            }
            else if (islem == "DEL") 
            {
                if (SonucEkran.Text.Length > 1)
                {
                    SonucEkran.Text = SonucEkran.Text.Remove(SonucEkran.Text.Length - 1);
                }
                else 
                {
                    SonucEkran.Text = "0";
                    yeniSayiGirisi = true;
                }
            }
        }
        private void Esittir_Click(object sender, RoutedEventArgs e)
        {
            
            if (double.TryParse(SonucEkran.Text, out double mevcutDeger))
            {
                ikinciSayi = mevcutDeger;
            }
            else
            {
                return; 
            }
            string tamIslem = ilkSayi.ToString() + " " + aktifIslem + " " + ikinciSayi.ToString() + " =";
            GecmisEkran.Text = tamIslem;
            double sonuc = 0;

            
            switch (aktifIslem)
            {
                case "+":
                    sonuc = ilkSayi + ikinciSayi;
                    break;
                case "-":
                    sonuc = ilkSayi - ikinciSayi;
                    break;
                case "*":
                    sonuc = ilkSayi * ikinciSayi;
                    break;
                case "/":
                    
                    if (ikinciSayi != 0)
                    {
                        sonuc = ilkSayi / ikinciSayi;
                    }
                    else
                    {
                        SonucEkran.Text = "Hata";
                        
                        ilkSayi = 0;
                        aktifIslem = "";
                        yeniSayiGirisi = true;
                        GecmisEkran.Text = "";
                        return;
                    }
                    break;
                default:
                    
                    SonucEkran.Text = ikinciSayi.ToString(); 
                    return;
            }
            

            SonucEkran.Text = sonuc.ToString();

            
            ilkSayi = sonuc; 
            aktifIslem = "";
            yeniSayiGirisi = true; 
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}