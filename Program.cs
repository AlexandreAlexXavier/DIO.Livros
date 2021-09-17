using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Livros
{
    class Program
    {
        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarLivro();
						break;
					case "2":
						InserirLivro();
						break;
					case "3":
						AtualizarLivro();
						break;
					case "4":
						ExcluirLivro();
						break;
					case "5":
						VisualizarLivro();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirLivro()
		{
			Console.Write("Digite o id do Livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceLivro);
		}

        private static void VisualizarLivro()
		{
			Console.Write("Digite o id do Livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			var livro = repositorio.RetornaPorId(indiceLivro);

			Console.WriteLine(livro);
		}

        private static void AtualizarLivro()
		{
			Console.Write("Digite o id do Livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Publicação: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Sinopse do Livro: ");
			string entradaDescricao = Console.ReadLine();

			Livro atualizaLivro = new Livro(id: indiceLivro,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceLivro, atualizaLivro);
		}
        private static void ListarLivro()
		{
			Console.WriteLine("Listar Livros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum livro cadastrado.");
				return;
			}

			foreach (var livro in lista)
			{
                var excluido = livro.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", livro.retornaId(), livro.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirLivro()
		{
			Console.Clear();
			Console.WriteLine("Inserir novo Livro");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Publicação: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Sinopse do Livro: ");
			string entradaDescricao = Console.ReadLine();

			Livro novaLivro = new Livro(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaLivro);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.Clear();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;

			Console.WriteLine("     88888888888  888888  888888");
			Console.WriteLine("    88     88     88   88 88  88");
			Console.WriteLine("     8888  88888  888888  88  88   88888 88    88 88   88");
			Console.WriteLine("        88 88     88   88 88  88   88    88    88  88 88");
			Console.WriteLine(" 88888888  88888  888888  888888   8888  88    88   888");
			Console.WriteLine("                                   88    88    88  88 88");
			Console.WriteLine("        LAVÔ, TÁ NOVO!             88    88888 88 88   88");
			Console.WriteLine();
			
			for (int i = 0; i<=60; i++)
				Console.Write((char) 42);
			Console.WriteLine();

			for (int i = 0; i <= 7; i++)
				Console.Write((char)42);
			Console.Write(" SEBO Flix a casa dos livros antigos e usados ");
			for (int i = 0; i <= 6; i++)
				Console.Write((char)42);
			Console.WriteLine();
			for (int i = 0; i <= 60; i++)
				Console.Write((char)42);
			Console.WriteLine();

			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();

			Console.WriteLine("1- Listar livros");
			Console.WriteLine("2- Inserir novo Livro");
			Console.WriteLine("3- Atualizar Livro");
			Console.WriteLine("4- Excluir Livro");
			Console.WriteLine("5- Visualizar Livro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			for (int i = 0; i <= 44; i++)
				Console.Write((char) 42);

			Console.WriteLine(" R3TR0System Ltd");
			Console.WriteLine("MS-DOS Version 4.13x");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
