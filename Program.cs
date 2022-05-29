
using ProjectCRUD.src.Entities;
using ProjectCRUD.src.Enums;
using ProjectCRUD.src.Repositories;
using static System.Console;
namespace ProjectCRUD
{
    class Program
    {
        static SeriesRepository seriesRepository = new SeriesRepository();
        static MovieRepository movieRepository = new MovieRepository();
        static void Main(string[] args)
        {
            string ChosenOption;
            do{
                ChosenOption = Menu();
                switch (ChosenOption){
					case "1":
						ListEntities();
						break;
					case "2":
						InsertSerie();
						break;
					case "3":
						InsertMovie();
						break;
					case "4":
						UpdateSerie();
						break;
					case "5":
						UpdateMovie();
						break;
					case "6":
						DeleteSeries();
						break;
					case "7":
						DeleteMovie();
						break;
					case "8":
						GetSeriesById();
						break;
					case "9":
						GetMovieById();
						break;
					case "10":
						GetSeriesByGenre();
						break;
					case "11":
						GetMovieByGenre();
						break;
					case "C":
						Console.Clear();
						break;
					case "X":
						WriteLine("Programa finalizando...");
						break;
					default:
                        WriteLine("Opção inválida!!");
                        break;
                }
                WriteLine("Aperte [Enter] para continuar.");
                ReadLine();
                Console.Clear();

            } while (ChosenOption.ToUpper() != "X");
				
        }
        public static string Menu(){
            WriteLine();
            WriteLine("-------Menu-------");
            WriteLine("1- Listar séries e filmes cadastrados");
            WriteLine("2- Inserir nova série");
            WriteLine("3- Inserir novo filme");
            WriteLine("4- Atualizar série");
            WriteLine("5- Atualizar filme");
            WriteLine("6- Excluir série");
            WriteLine("7- Excluir filme");
            WriteLine("8- Buscar série por id");
            WriteLine("9- Buscar filme por id");
            WriteLine("10- Buscar série por gênero");
            WriteLine("11- Buscar filme por gênero");
            WriteLine("C- Limpar Tela");
            WriteLine("X- Sair");
            Write("Digite a opção desejada: ");

            string ChosenOption = ReadLine()?.ToUpper();
            WriteLine();
            Console.Clear();
            return ChosenOption;
        }
        public static void ListEntities(){
            WriteLine("----- Listar séries e filmes -----");
            if(seriesRepository.IsEmpity() && movieRepository.IsEmpity()){
               WriteLine("Para ver a lista de filmes e séries é necessário ter pelo menos um filme ou série cadastrado.");
               return;
            }

            var listSeries = seriesRepository.GetAll();
            var listMovies = movieRepository.GetAll();
            
            if(!seriesRepository.IsEmpity()){
                WriteLine("SÉRIES: ");
                WriteLine("");
                foreach (Series serie in listSeries){
                    if(!serie.GetIsDelete()){
                        WriteLine(serie);
                        WriteLine("  ******************* ");
                    }
                }
            }
             if(!movieRepository.IsEmpity()){
                WriteLine("FILMES: ");
                WriteLine("");
                foreach (Movie movie in listMovies){
                    if(!movie.GetIsDelete()){
                        WriteLine(movie);
                        WriteLine("  ******************* ");
                    }
                }
            }
        }
        public static void InsertSerie(){
            WriteLine("----- Inserir Série -----");
            Series newSeries = getSeriesData();
			seriesRepository.Insert(newSeries);
            WriteLine("Série cadastrada com sucesso!!");
            return;
        }        
        public static void InsertMovie(){
            WriteLine("----- Inserir Filme -----");
            Movie newMovie = getMovieData();
			movieRepository.Insert(newMovie);
            WriteLine("Filme cadastrado com sucesso!!");
            return;
        }
     
        public static void UpdateSerie(){
            WriteLine("----- Atualizar séries -----");
            if(seriesRepository.IsEmpity()){
               WriteLine("Para atualizar uma série é nescessário cadastrar uma série primeiro.");
               return;
            }
            Write("Digite o id da serie que deseja atualizar: ");
            int seriesId = int.Parse(ReadLine());

            if(IsSeriesIdValid(seriesId)){
                Series newSeries = getSeriesData(seriesId);
			    seriesRepository.Update(seriesId, newSeries);
                WriteLine("Série atualizada com sucesso!!");
            };
            return;
        }

        public static void UpdateMovie(){
            WriteLine("----- Atualizar filme -----");
            if(movieRepository.IsEmpity()){
               WriteLine("Para atualizar um filme é nescessário cadastrar um filme primeiro.");
               return;
            }
            Write("Digite o id do filme que deseja atualizar: ");
            int movieId = int.Parse(ReadLine());
            if(IsMovieIdValid(movieId)){
                Movie newMovie = getMovieData(movieId);
			    movieRepository.Update(movieId, newMovie);
                WriteLine("Filme atualizado com sucesso!!");
            }
            return;
        }
        public static void DeleteSeries(){
            WriteLine("----- Deletar série -----");
            if(seriesRepository.IsEmpity()){
               WriteLine("Para deletar uma série é nescessário cadastrar uma série primeiro.");
               return;
            }
            Write("Digite o id da série que deseja deletar: ");
            int seriesId = int.Parse(ReadLine());

            if(IsSeriesIdValid(seriesId)){
                Series series = seriesRepository.GetById(seriesId);
                WriteLine("Tem certeza que deseja deletar a série de título: " + series.GetTitle() + "?");
                Write("Digite 'S' para confirmar ou 'N' para cancelar a operação: ");
                string ChosenOption = ReadLine()?.ToUpper();
                if(ChosenOption == "S"){
                    seriesRepository.Delete(seriesId);
                    WriteLine("Série deletada com sucesso!!");
                }
                else{
                    WriteLine("Operação cancelada!!");
                }
            }
            return;
        }
        public static void DeleteMovie(){
            WriteLine("----- Deletar filme -----");
            if(movieRepository.IsEmpity()){
               WriteLine("Para deletar um filme é nescessário cadastrar um filme primeiro.");
               return;
            }
            Write("Digite o id do filme que deseja deletar: ");
            int movieId = int.Parse(ReadLine());

            if(IsMovieIdValid(movieId)){
                Movie movie = movieRepository.GetById(movieId);
                WriteLine("Tem certeza que deseja deletar o filme de título: " + movie.GetTitle() + "?");
                Write("Digite 'S' para confirmar ou 'N' para cancelar a operação: ");
                string ChosenOption = ReadLine()?.ToUpper();
                if(ChosenOption == "S"){
                    movieRepository.Delete(movieId);
                    WriteLine("Filme deletada com sucesso!!");
                }
                else{
                    WriteLine("Operação cancelada!!");
                }
            }
            return;
        }

        public static void GetSeriesById(){
            WriteLine("----- Buscar série pelo id -----");
            if(seriesRepository.IsEmpity()){
               WriteLine("Para buscar uma série é nescessário cadastrar esta série primeiro.");
               return;
            }
            Write("Digite o id da série que deseja buscar: ");
            int seriesId = int.Parse(ReadLine());
            if(IsSeriesIdValid(seriesId)){
                Series series = seriesRepository.GetById(seriesId);
                Write(series);
            }
        }
        public static void GetMovieById(){
            WriteLine("----- Buscar filme pelo id -----");
            if(movieRepository.IsEmpity()){
               WriteLine("Para buscar um filme é nescessário cadastrar este filme primeiro.");
               return;
            }
            Write("Digite o id do filme que deseja buscar: ");
            int movieId = int.Parse(ReadLine());
            if(IsMovieIdValid(movieId)){
                Movie movie = movieRepository.GetById(movieId);
                Write(movie);
            }
        }

        public static void GetSeriesByGenre(){
            WriteLine("----- Buscar séries por gênero -----");
            if(seriesRepository.IsEmpity()){
               WriteLine("Para realizar a busca é necessário ter pelo menos uma série cadastrado.");
               return;
            }

            int genreCode = WriteGenres();
            var listSeries = seriesRepository.GetByGenre((GenreEnum)genreCode);
            if(listSeries.Count > 0){
                WriteLine("SÉRIES: ");
                WriteLine("");
                foreach (Series serie in listSeries){
                    if(!serie.GetIsDelete()){
                        WriteLine(serie);
                        WriteLine("  ******************* ");
                    }
                }
            }
            else{
                WriteLine($"Nenhuma série do gênero {(GenreEnum)genreCode} foi encontrada!");
            }
            return;
        }
        public static void GetMovieByGenre(){
            WriteLine("----- Buscar filmes por gênero -----");
            if(movieRepository.IsEmpity()){
               WriteLine("Para realizar a busca é necessário ter pelo menos um filme cadastrado.");
               return;
            }

            int genreCode = WriteGenres();
            var listMovie = movieRepository.GetByGenre((GenreEnum)genreCode);
            if(listMovie.Count > 0){
                WriteLine("SÉRIES: ");
                WriteLine("");
                foreach (Movie movie in listMovie){
                    if(!movie.GetIsDelete()){
                        WriteLine(movie);
                        WriteLine("  ******************* ");
                    }
                }
            }
            else{
                WriteLine($"Nenhuma filme do gênero {(GenreEnum)genreCode} foi encontrado!");
            }
            return;
        }

        public static Series getSeriesData(int id = -1){         
          	Write("Digite o Título da Série: ");
			string title = ReadLine();

            Write("Digite a Descrição da Série: ");
			string description = ReadLine();

            Write("Digite o Ano de Início da Série: ");
			int year = int.Parse(ReadLine());
            WriteLine();
			int genreCode = WriteGenres();

			Write("Digite o Numero de temporadas da Série: ");
			int numSeasons = int.Parse(ReadLine());
            if(id == -1){
                id = seriesRepository.NextId();
            }
			return new Series(id, title, description, year,(GenreEnum)genreCode, numSeasons);
        }

        public static Movie getMovieData(int id = -1){   
            Write("Digite o Título do Filme: ");
			string title = ReadLine();

            Write("Digite a Descrição do Filme: ");
			string description = ReadLine();

            Write("Digite o Ano do Filme: ");
			int year = int.Parse(ReadLine());

			int genreCode = WriteGenres();

			Write("Digite o tempo de duração em minutos: ");
			double duration = double.Parse(ReadLine());
            if(id== -1){
                id = movieRepository.NextId();
            }
			return new Movie(id, title, description, year,(GenreEnum)genreCode, duration);
        }

        public static int WriteGenres(){
            WriteLine("Gêneros: ");
            foreach (int i in Enum.GetValues(typeof(GenreEnum)))
			{
				WriteLine(" {0} - {1}", i, Enum.GetName(typeof(GenreEnum), i));
			}
            Write("Digite o número que representa o gênero entre as opções acima: ");
            return int.Parse(ReadLine());
        }
        public static bool IsSeriesIdValid(int id){
            if(seriesRepository.GetAll().Count > id){
                if(seriesRepository.GetById(id).GetIsDelete()){
                    WriteLine($"A série com o id {id}, já foi excluída.");
                    return false;
                }
                else{
                    return true;
                }
            }
            else{
                WriteLine($"O id: {id} ainda não foi cadastrado!");
                return false;
            }
        }
        public static bool IsMovieIdValid(int id){
            if(movieRepository.GetAll().Count > id){
                if(movieRepository.GetById(id).GetIsDelete()){
                    WriteLine($"O filme com o id {id} já foi excluído!");
                    return false;
                }
                else{
                    return true;
                }
            }
            else{
                WriteLine($"O id: {id} ainda não foi cadastrado!");
                return false;
            }
        }
    }
}

