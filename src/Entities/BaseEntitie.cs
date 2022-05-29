using ProjectCRUD.src.Enums;

namespace ProjectCRUD.src.Entities
{
    public abstract class BaseEntitie
    {
        protected int Id;
        protected string Title;

        protected string Description;

        protected int Year;
        protected bool IsDelete;

        protected GenreEnum Genre;

        public BaseEntitie(int Id, string Title, string Description, int Year, GenreEnum Genre)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;
            this.Genre = Genre;
            this.IsDelete = false;
        }
             
        public int GetId(){
            return this.Id;
        }
        public bool GetIsDelete(){
            return this.IsDelete;
        }

        public void SetIsDelete(bool status){
            this.IsDelete = status;
        }

        public GenreEnum GetGenre(){
            return this.Genre;
        }


        public string GetTitle(){
            return this.Title;
        }

        public override string ToString()
        {
            string isDelete = this.IsDelete ? "Sim" : "Não";
            string text = "";
            text += "  Id: " + this.Id + Environment.NewLine;
            text += "  Titulo: " + this.Title + Environment.NewLine;
            text += "  Ano: " + this.Year + Environment.NewLine;
            text += "  Gênero: " + this.Genre + Environment.NewLine;
            text += "  Descrição: " + this.Description + Environment.NewLine;
			return text;
        }
    }
}