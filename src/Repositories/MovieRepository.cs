using ProjectCRUD.src.Entities;
using ProjectCRUD.src.Enums;
using ProjectCRUD.src.Interfaces;

namespace ProjectCRUD.src.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> MovieList = new List<Movie>();
        private int numDeletedMovies = 0;

        public void Delete(int id)
        {
            MovieList[id].SetIsDelete(true);
            numDeletedMovies++;
        }

        public List<Movie> GetAll()
        {
            return MovieList;
        }

        public List<Movie> GetByGenre(GenreEnum genre)
        {
            return MovieList.FindAll(m => m.GetGenre() == genre && m.GetIsDelete() == false);
        }

        public Movie GetById(int id)
        {
            return MovieList[id];
        }

        public void Insert(Movie entity)
        {
            MovieList.Add(entity);
        }

        public bool IsEmpity()
        {
            if(MovieList.Count ==  0) return true;

            if(MovieList.Count == numDeletedMovies) return true;

            return false;
        }

        public int NextId()
        {
            return MovieList.Count;
        }
        public void Update(int id, Movie entity)
        {
            MovieList[id] = entity;
        }

        List<Movie> IRepository<Movie>.GetByGenre(GenreEnum genre)
        {
            throw new NotImplementedException();
        }
    }
}