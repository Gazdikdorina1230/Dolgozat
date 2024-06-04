using Dolgozat.Command;
using Dolgozat.Nezetek;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat.Fo
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }

        HomeView homeView;
        AbraKilenc abraKilenc;
        SqlView sqlView;

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand openMain { get; }
        public RelayCommand kilencesAbra { get; }
        public RelayCommand sqlNezet { get; }

        public MainViewModel()
        {
            homeView = new HomeView();
            abraKilenc = new AbraKilenc();
            sqlView = new SqlView();

            openMain = new RelayCommand(X => CurrentView = homeView);
            kilencesAbra = new RelayCommand(X => CurrentView = abraKilenc);
            sqlNezet = new RelayCommand(X => CurrentView = sqlView);

            CurrentView = homeView;
        }
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
