using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IndirimOranTutarHesapla.ViewModel
{
    public class FaturaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public double BirimFiyat { get; set; } = 100;
        private double _kdvOrani = 18; // KDV oranı %18 olarak örneklendi
        private double _kdvTutari = 0;
        public double KDVTutari
        {
            get
            {
                return _kdvTutari;
            }
            set
            {
                _kdvTutari = value;
                OnPropertyChanged();
            }
        }
        public double ToplamFiyat
        {
            get
            {
                return IndirimMatrahi + (IndirimMatrahi * (_kdvOrani / 100));
            }
        }
        private double _indirimMatrahi = 0;
        public double IndirimMatrahi
        {
            get
            {
                return _indirimMatrahi;
            }
            set
            {
                if (_indirimMatrahi != value)
                {
                    _indirimMatrahi = value;
                    OnPropertyChanged(nameof(IndirimMatrahi));
                }
            }
        }

        private double _indirimOran1;
        public double IndirimOran1
        {
            get { return _indirimOran1; }
            set
            {
                if (_indirimOran1 != value)
                {
                    _indirimOran1 = value;
                    OnPropertyChanged();
                    SetIndirimTutarlari();
                }
            }
        }

        private double _indirimOran2;
        public double IndirimOran2
        {
            get { return _indirimOran2; }
            set
            {
                if (_indirimOran2 != value)
                {
                    _indirimOran2 = value;
                    OnPropertyChanged();
                    SetIndirimTutarlari();
                }
            }
        }

        private double _indirimOran3;
        public double IndirimOran3
        {
            get { return _indirimOran3; }
            set
            {
                if (_indirimOran3 != value)
                {
                    _indirimOran3 = value;
                    OnPropertyChanged();
                    SetIndirimTutarlari();
                }
            }
        }

        private double _indirimTutar1;
        public double IndirimTutar1
        {
            get { return _indirimTutar1; }
            set
            {
                if (_indirimTutar1 != value)
                {
                    _indirimTutar1 = value;
                    OnPropertyChanged();
                    SetIndirimTutarlari();
                }
            }
        }

        private double _indirimTutar2;
        public double IndirimTutar2
        {
            get { return _indirimTutar2; }
            set
            {
                if (_indirimTutar2 != value)
                {
                    _indirimTutar2 = value;
                    OnPropertyChanged();
                    SetIndirimTutarlari();
                }
            }
        }

        private double _indirimTutar3;
        public double IndirimTutar3
        {
            get { return _indirimTutar3; }
            set
            {
                if (_indirimTutar3 != value)
                {
                    _indirimTutar3 = value;
                    OnPropertyChanged();
                    SetIndirimTutarlari();
                }
            }
        }

        public enmIndirimTuru IndirimTuru1 { get; set; }
        public enmIndirimTuru IndirimTuru2 { get; set; }
        public enmIndirimTuru IndirimTuru3 { get; set; }
        /// <summary>
        /// Hangi indirim turuyle islem yapıyorsak o haric
        /// diğer indirim turleri oran olmalı ki
        /// tutarları tekrardan hesaplansın
        /// </summary>
        /// <param name="id"></param>
        public void SetIndirimTuru(int id)
        {
            switch (id)
            {
                case 1:
                    IndirimTuru2 = IndirimTuru3 = enmIndirimTuru.oran;
                    break;
                case 2:
                    IndirimTuru1 = IndirimTuru3 = enmIndirimTuru.oran;
                    break;
                case 3:
                    IndirimTuru1 = IndirimTuru2 = enmIndirimTuru.oran;
                    break;
            }
        }

        private List<double> GetIndirimOranlar()
        {
            return new List<double>
            {
                IndirimOran1,
                IndirimOran2,
                IndirimOran3,
            };
        }
        private List<double> GetIndirimTutarlar()
        {
            return new List<double>
            {
                IndirimTutar1,
                IndirimTutar2,
                IndirimTutar3,
            };
        }

        private void SetIndirimTutarlari()
        {
            double tempMatrah = BirimFiyat;

            // IndirimTuru1 için işlemler
            if (IndirimTuru1 == enmIndirimTuru.oran)
            {
                if (IndirimOran1 > 0)
                {
                    IndirimTutar1 = tempMatrah * IndirimOran1 / 100;
                    tempMatrah -= IndirimTutar1;
                }
                else
                {
                    IndirimTutar1 = 0;
                }
            }
            else if (IndirimTuru1 == enmIndirimTuru.tutar)
            {
                if (IndirimTutar1 > 0)
                {
                    IndirimOran1 = (IndirimTutar1 / tempMatrah) * 100;
                    tempMatrah -= IndirimTutar1;
                }
                else
                {
                    IndirimOran1 = 0;
                }
            }

            // IndirimTuru2 için işlemler
            if (IndirimTuru2 == enmIndirimTuru.oran)
            {
                if (IndirimOran2 > 0)
                {
                    IndirimTutar2 = tempMatrah * IndirimOran2 / 100;
                    tempMatrah -= IndirimTutar2;
                }
                else
                {
                    IndirimTutar2 = 0;
                }
            }
            else if (IndirimTuru2 == enmIndirimTuru.tutar)
            {
                if (IndirimTutar2 > 0)
                {
                    IndirimOran2 = (IndirimTutar2 / tempMatrah) * 100;
                    tempMatrah -= IndirimTutar2;
                }
                else
                {
                    IndirimOran2 = 0;
                }
            }
            else
            {
                if (IndirimOran2 > 0)
                {
                    IndirimTutar2 = tempMatrah * IndirimOran2 / 100;
                    tempMatrah -= IndirimTutar2;
                }
            }

            // IndirimTuru3 için işlemler
            if (IndirimTuru3 == enmIndirimTuru.oran)
            {
                if (IndirimOran3 > 0)
                {
                    IndirimTutar3 = tempMatrah * IndirimOran3 / 100;
                    tempMatrah -= IndirimTutar3;
                }
                else
                {
                    IndirimTutar3 = 0;
                }
            }
            else if (IndirimTuru3 == enmIndirimTuru.tutar)
            {
                if (IndirimTutar3 > 0)
                {
                    IndirimOran3 = (IndirimTutar3 / tempMatrah) * 100;
                    tempMatrah -= IndirimTutar3;
                }
                else
                {
                    IndirimOran3 = 0;
                }
            }
            else
            {
                if (IndirimOran3 > 0)
                {
                    IndirimTutar3 = tempMatrah * IndirimOran3 / 100;
                    tempMatrah -= IndirimTutar3;
                }
            }

            IndirimMatrahi = tempMatrah;

            // KDV hesaplama
            KDVTutari = IndirimMatrahi * (_kdvOrani / 100);
            double toplamFiyat = IndirimMatrahi + KDVTutari;

            // Sonuçları güncelle
            OnPropertyChanged(nameof(IndirimMatrahi));
            OnPropertyChanged(nameof(IndirimOran1));
            OnPropertyChanged(nameof(IndirimOran2));
            OnPropertyChanged(nameof(IndirimOran3));
            OnPropertyChanged(nameof(IndirimTutar1));
            OnPropertyChanged(nameof(IndirimTutar2));
            OnPropertyChanged(nameof(IndirimTutar3));
            OnPropertyChanged(nameof(ToplamFiyat));
        }
        public FaturaViewModel()
        {
            SetIndirimTutarlari(); // Başlangıçta indirim tutarlarını ve kdv hesapla
        }
    }
}
