namespace AppSeries
{
  class Program
  {
    static SerieRepositorio repositorioSeries = new SerieRepositorio();
    static FilmeRepositorio repositorioFilmes = new FilmeRepositorio();

    static string filmesOuSeries;

    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        Console.Write("Escolha uma opção entre Filmes ou Séries: ");
        filmesOuSeries = Console.ReadLine();

        switch (opcaoUsuario)
        {
          case "1":
            Listar();
            break;
          case "2":
            Inserir();
            break;
          case "3":
            Atualizar();
            break;
          case "4":
            Excluir();
            break;
          case "5":
            Visualizar();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static void Listar()
    {
      if (filmesOuSeries.ToUpper() == "F")
      {
        var listaFilmes = repositorioFilmes.Lista();

        if (listaFilmes.Count == 0)
        {
          Console.WriteLine("Nenhum filme cadastrado.");
        }

        foreach (var filme in listaFilmes)
        {
          Console.WriteLine("ID {0}: - {1} {2}", filme.RetornaId(), filme.RetornaTitulo(), filme.RetornaExcluido() ? "Excluído" : "");
        }
      }
      else
      {
        var listaSeries = repositorioSeries.Lista();

        if (listaSeries.Count == 0)
        {
          Console.WriteLine("Nenhuma série cadastrada");
          return;
        }

        foreach (var serie in listaSeries)
        {
          Console.WriteLine("ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), serie.RetornaExcluido() ? "Excluído" : "");
        }
      }
    }

    private static void Inserir()
    {
      if (filmesOuSeries.ToUpper() == "F")
      {
        Console.WriteLine("Inserir novo filme.");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
          Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Informe o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Informe o título do filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Informe a descrição do filme: ");
        string entradaDescricao = Console.ReadLine();

        Console.Write("Informe o ano de lançamento do filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Filme novoFilme = new Filme(id: repositorioFilmes.ProximoId(),
                                      genero: (Genero)entradaGenero,
                                      titulo: entradaTitulo,
                                      descricao: entradaDescricao,
                                      ano: entradaAno);

        repositorioFilmes.Insere(novoFilme);
      }
      else
      {
        Console.WriteLine("Inserir nova série");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
          Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorioSeries.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorioSeries.Insere(novaSerie);
      }
    }

    private static void Atualizar()
    {
      if (filmesOuSeries.ToUpper() == "F")
      {
        Console.Write("Digite o ID do filme: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
          Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título do filme: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início do filme: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição do filme: ");
        string entradaDescricao = Console.ReadLine();

        Filme atualizaFilme = new Filme(id: indiceFilme,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorioFilmes.Atualiza(indiceFilme, atualizaFilme);
      }
      else
      {
        Console.Write("Digite o ID da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
          Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de início da série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorioSeries.Atualiza(indiceSerie, atualizaSerie);
      }
    }

    private static void Excluir()
    {
      if (filmesOuSeries.ToUpper() == "F")
      {
        Console.Write("Digite o ID do filme que deseja excluir: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        repositorioFilmes.Exclui(indiceFilme);
      }
      else
      {
        Console.Write("Digite o ID da série que deseja excluir: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorioSeries.Exclui(indiceSerie);
      }
    }

    private static void Visualizar()
    {
      if (filmesOuSeries.ToUpper() == "F")
      {
        Console.Write("Digite o ID do filme que deseja visualizar: ");
        int indiceFilme = int.Parse(Console.ReadLine());

        var filme = repositorioFilmes.RetornaPorId(indiceFilme);

        Console.WriteLine(filme);
      }
      else
      {
        Console.Write("Digite o ID da série que deseja visualizar: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorioSeries.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar");
      Console.WriteLine("2- Inserir");
      Console.WriteLine("3- Atualizar");
      Console.WriteLine("4- Excluir");
      Console.WriteLine("5- Visualizar");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}