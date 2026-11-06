using Konsola;
using System.Collections.ObjectModel;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<RekordRozliczenia> Rozliczenia { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Rozliczenia = [];
            rejestrDataGrid.ItemsSource = Rozliczenia;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!float.TryParse(bruttoTextBox.Text, out float brutto))
                return;

            if (brutto <= 0)
                return;

            bool czyUlga = ulgaCheckBox.IsChecked!.Value;

            bool czyZlecenie = umowaZlecenieRadio.IsChecked!.Value;

            Kalkulator k = new(brutto, czyZlecenie, czyUlga);

            nettoTextBlock.Text = $" {k.KwotaNetto()} PLN";
            zusTextBlock.Text = $" {k.SkladkaZus()} PLN";
            skladkaZdrowotnaTextBlock.Text = $" {k.SkladkaZdrowotna()} PLN";
            pitTextBlock.Text = $" {k.ZaliczkaPit()} PLN";

            RekordRozliczenia rekordRozliczenia = new();

            rekordRozliczenia.Data = DateTime.Today.ToString("d");
            rekordRozliczenia.Brutto = brutto;

            if (czyZlecenie)
                rekordRozliczenia.Umowa = "Zlecenie";
            else
                rekordRozliczenia.Umowa = "O pracę";

            rekordRozliczenia.Netto = k.KwotaNetto();

            if (czyUlga)
                rekordRozliczenia.Ulga = "Tak";
            else
                rekordRozliczenia.Ulga = "Nie";

            Rozliczenia.Add(rekordRozliczenia);

        }
    }

    public class RekordRozliczenia
    {
        public string Data { get; set; }
        public float Brutto { get; set; }
        public string Umowa { get; set; }
        public float Netto { get; set; }
        public string Ulga { get; set; }
    }
}