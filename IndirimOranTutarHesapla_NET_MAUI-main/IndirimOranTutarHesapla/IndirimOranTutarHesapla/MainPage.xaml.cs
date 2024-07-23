using IndirimOranTutarHesapla.ViewModel;

namespace IndirimOranTutarHesapla
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        FaturaViewModel faturaViewModel;

        public MainPage()
        {
            InitializeComponent();
            faturaViewModel = new FaturaViewModel();
            BindingContext = faturaViewModel;
        }

        private void entry_indirimorani_1_Focused(object sender, FocusEventArgs e)
        {
            faturaViewModel.IndirimTuru1 = enmIndirimTuru.oran;
            faturaViewModel.SetIndirimTuru(1);
        }

        private void entry_indirimorani_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Gelen metni al
                string text = entry.Text;

                // Metin double değil, muhtemelen ""
                if (!double.TryParse(text, out double value))
                {
                    faturaViewModel.IndirimOran1 = 0;
                }
            }
        }

        private void entry_indirim_tutari_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Gelen metni al
                string text = entry.Text;

                // Metin double değil, muhtemelen ""
                if (!double.TryParse(text, out double value))
                {
                    faturaViewModel.IndirimTutar1 = 0;
                }
            }
        }

        private void entry_indirimorani_2_Focused(object sender, FocusEventArgs e)
        {
            faturaViewModel.IndirimTuru2 = enmIndirimTuru.oran;
            faturaViewModel.SetIndirimTuru(2);
        }

        private void entry_indirim_tutari_2_Focused(object sender, FocusEventArgs e)
        {
            faturaViewModel.IndirimTuru2 = enmIndirimTuru.tutar;
            faturaViewModel.SetIndirimTuru(2);
        }

        private void entry_indirim_tutari_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Gelen metni al
                string text = entry.Text;

                // Metin double değil, muhtemelen ""
                if (!double.TryParse(text, out double value))
                {
                    faturaViewModel.IndirimTutar2 = 0;
                }
            }
        }

        private void entry_indirimorani_3_Focused(object sender, FocusEventArgs e)
        {
            faturaViewModel.IndirimTuru3 = enmIndirimTuru.oran;
            faturaViewModel.SetIndirimTuru(3);
        }

        private void entry_indirimorani_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Gelen metni al
                string text = entry.Text;

                // Metin double değil, muhtemelen ""
                if (!double.TryParse(text, out double value))
                {
                    faturaViewModel.IndirimOran3 = 0;
                }
            }
        }

        private void entry_indirim_tutari_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Gelen metni al
                string text = entry.Text;

                // Metin double değil, muhtemelen ""
                if (!double.TryParse(text, out double value))
                {
                    faturaViewModel.IndirimTutar3 = 0;
                }
            }
        }

        private void entry_indirim_tutari_3_Focused(object sender, FocusEventArgs e)
        {
            faturaViewModel.IndirimTuru3 = enmIndirimTuru.tutar;
            faturaViewModel.SetIndirimTuru(3);
        }

        private void entry_indirim_tutari_1_Focused(object sender, FocusEventArgs e)
        {
            faturaViewModel.IndirimTuru1 = enmIndirimTuru.tutar;
            faturaViewModel.SetIndirimTuru(1);
        }

        private void entry_indirimorani_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // Gelen metni al
                string text = entry.Text;

                // Metin double değil, muhtemelen ""
                if (!double.TryParse(text, out double value))
                {
                    faturaViewModel.IndirimOran2 = 0;
                }
            }
        }
    }
}
