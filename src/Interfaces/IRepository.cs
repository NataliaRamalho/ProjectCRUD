using ProjectCRUD.src.Enums;

namespace ProjectCRUD.src.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAll();  
        public T GetById(int id);        
        public List<T> GetByGenre(GenreEnum genre);        
        public void Insert(T entity);    
        public bool IsEmpity();      
        public void Delete(int id);        
        public void Update(int id, T entity);
        public int NextId();
    }
}