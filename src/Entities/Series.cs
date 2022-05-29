using ProjectCRUD.src.Enums;

namespace ProjectCRUD.src.Entities
{
    public class Series : BaseEntitie
    {
        public Series(int Id, string Title, string Description, int Year, GenreEnum Genre, int NumSeasons) : base(Id, Title, Description, Year, Genre)
        {
            this.NumSeasons = NumSeasons;
        }

        public int NumSeasons { get; set; }

         public override string ToString(){
            string baseText =  base.ToString();
            baseText += "  Número de temporadas: " + this.NumSeasons;
            return baseText;
        }
    }
}