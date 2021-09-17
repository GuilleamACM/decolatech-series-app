using System;
using Series.Classes;
using Series.Enums;

namespace Series
{
    class Program
    {
	    private static SeriesRepository _repository = new SeriesRepository();
	    
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opção inválida, por favor tente novamente.");
	                    break;
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        
        private static void ListSeries()
        {
	        Console.WriteLine("Listar séries");

	        var list = _repository.List();

	        if (list.Count == 0)
	        {
		        Console.WriteLine("Nenhuma série cadastrada.");
		        return;
	        }

	        foreach (var series in list)
	        {
		        var deleted = series.Deleted;
                
		        Console.WriteLine("#ID {0}: - {1} {2}", series.Id, series.Title, (deleted ? "*Excluído*" : ""));
	        }
        }
        
        private static void InsertSeries()
        {
	        Console.WriteLine("Inserir nova série");
	        
	        foreach (int i in Enum.GetValues(typeof(Genre)))
	        {
		        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
	        }
	        
	        Console.Write("Digite o gênero entre as opções acima: ");
	        var genre = int.Parse(Console.ReadLine());

	        Console.Write("Digite o Título da Série: ");
	        var title = Console.ReadLine();

	        Console.Write("Digite o Ano de Início da Série: ");
	        var year = int.Parse(Console.ReadLine());

	        Console.Write("Digite a Descrição da Série: ");
	        var description = Console.ReadLine();

	        var newSeries = new TvSeries(_repository.NextId(), (Genre)genre, title, description, year);

	        _repository.Insert(newSeries);
        }
        
        private static void UpdateSeries()
        {
	        Console.Write("Digite o id da série: ");
	        var seriesIndex = int.Parse(Console.ReadLine());
	        
	        foreach (int i in Enum.GetValues(typeof(Genre)))
	        {
		        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
	        }
	        Console.Write("Digite o gênero entre as opções acima: ");
	        
	        var genre = int.Parse(Console.ReadLine());

	        Console.Write("Digite o Título da Série: ");
	        var title = Console.ReadLine();

	        Console.Write("Digite o Ano de Início da Série: ");
	        var year = int.Parse(Console.ReadLine());

	        Console.Write("Digite a Descrição da Série: ");
	        var description = Console.ReadLine();

	        var updatedSeries = new TvSeries(seriesIndex, (Genre)genre, title, description, year);

		        _repository.Update(seriesIndex, updatedSeries);
        }
        
        private static void DeleteSeries()
		{
			Console.Write("Digite o id da série: ");
			int seriesIndex = int.Parse(Console.ReadLine());

			_repository.Remove(seriesIndex);
		}

        private static void ViewSeries()
		{
			Console.Write("Digite o id da série: ");
			int seriesIndex = int.Parse(Console.ReadLine());

			var series = _repository.GetById(seriesIndex);

			Console.WriteLine(series);
		}

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries disponíveis");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            var userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
