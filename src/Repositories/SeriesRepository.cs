using ProjectCRUD.src.Entities;
using ProjectCRUD.src.Enums;
using ProjectCRUD.src.Interfaces;

namespace ProjectCRUD.src.Repositories
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> SeriesList = new List<Series>();
        private int numDeletedSeries = 0;

        public void Delete(int id)
        {
            SeriesList[id].SetIsDelete(true);
            numDeletedSeries++;
        }

        public List<Series> GetAll()
        {
            return SeriesList;
        }

        public List<Series> GetByGenre(GenreEnum genre)
        {
            return SeriesList.FindAll(s => s.GetGenre() == genre && s.GetIsDelete() == false);         
        }
      

        public Series GetById(int id)
        {
            return SeriesList[id];
        }

        public void Insert(Series entity)
        {
            SeriesList.Add(entity);
        }

        public bool IsEmpity()
        {
            if(SeriesList.Count ==  0) return true;

            if(SeriesList.Count == numDeletedSeries) return true;

            return false;
        }

        public int NextId()
        {
            return SeriesList.Count;
        }

        public void Update(int id, Series entity)
        {
            SeriesList[id] = entity;
        }
    }
}