using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using System.Globalization;
using System.Text.RegularExpressions;
#if IOS
using UIKit;
#endif
namespace FormatEntry
{
    // NumericEntry, Entry sınıfından türetilmiş bir sınıf
    public class NumericEntry : Entry
    {
        public NumericEntry()
        {
            this.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // Giriş metnini yalnızca sayılara filtrele
            var filteredText = Regex.Replace(e.NewTextValue, @"[^\d]", string.Empty);

            // Binlik ayıracı ekle
            if (!string.IsNullOrEmpty(filteredText))
            {
                // Sayıyı uzun olarak parse et ve formatla
                var number = long.Parse(filteredText);
                this.Text = FormatWithThousandSeparator(number);
            }
            else
            {
                this.Text = string.Empty; // Giriş temizlenirse metni boş yap
            }
        }

        private string FormatWithThousandSeparator(long number)
        {
            // Binlik ayıracı olarak nokta kullan
            return string.Format(CultureInfo.InvariantCulture, "{0:N0}", number).Replace(",", ".").Replace(" ", "");
        }
    }

#if IOS
    // EntryHandler ile platform bazlı özelleştirmeler
    public class CustomEntryHandler : EntryHandler
    {
        protected override void ConnectHandler(Microsoft.Maui.Platform.MauiTextField platformView)
        {
            base.ConnectHandler(platformView);
            platformView.BorderStyle = UIKit.UITextBorderStyle.None; // iOS özelinde border'ı kaldırır
        }
    }
#endif
}
