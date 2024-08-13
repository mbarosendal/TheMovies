using System.Windows;
using TheMovies.Repository;
using TheMovies.ViewModels;

namespace TheMovies.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IMovieRepository movieRepository = new MovieRepository();
            DataContext = new MainViewModel(movieRepository);
        }
    }
}