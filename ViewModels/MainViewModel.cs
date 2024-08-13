using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheMovies.Commands;
using TheMovies.Models;
using TheMovies.Repository;

namespace TheMovies.ViewModels
{
    public class MainViewModel
    {
        private readonly IMovieRepository _movieRepository;
        public ObservableCollection<MovieViewModel> Movies { get; set; }
        public MovieViewModel MovieToAdd { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public MainViewModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            MovieToAdd =  new MovieViewModel(new Movie());
            Movies = new ObservableCollection<MovieViewModel>(_movieRepository.GetAllMovies()
                                                            .Select(movie => new MovieViewModel(movie))); // FilmViewModel's constructor takes Film objects, which we get from the repository'.s GetAll()
            AddCommand = new RelayCommand(x => AddMovie(), x => CanAddMovie());          // Convert each Film object retrieved from the repository into a FilmViewModel object before adding it to the ObservableCollection<FilmViewModel>.
            ClearCommand = new RelayCommand(x => ClearFields()/*, x => CanClearFields()*/);          // Convert each Film object retrieved from the repository into a FilmViewModel object before adding it to the ObservableCollection<FilmViewModel>.

        }

        private void ClearFields()
        {
            MovieToAdd.Title = string.Empty;
            MovieToAdd.Duration = 0;
            MovieToAdd.Genre = string.Empty;
            Debug.WriteLine("Clearing fields");
        }

        private bool CanAddMovie()
        {
            return _movieRepository.CanAddMovie();
        }

        private void AddMovie()
        {
            // Lav et nyt Film objekt til lagring ud fra FilmToAdd
            var newMovie = new Movie
            {
                Title = MovieToAdd.Title,
                Duration = MovieToAdd.Duration,
                Genre = MovieToAdd.Genre,
            };

            _movieRepository.AddMovie(newMovie);

            // Opdater ObservableCollection med det nye data
            Movies.Add(new MovieViewModel(newMovie));

            ClearFields();
        }
    }
}
