using ProjectCRUD.src.Enums;

namespace ProjectCRUD.src.Entities
{
    public class Movie : BaseEntitie
    {
        public Movie(int Id, string Title, string Description, int Year, GenreEnum Genre, double Duration) : base(Id, Title, Description, Year, Genre)
        {
            this.Duration = Duration;
        }

        public double Duration { get; set; }

        public override string ToString(){
            string baseText =  base.ToString();
            baseText +="  Duração: " + this.Duration;
            return baseText;
        }
    }
}