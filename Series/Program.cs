using Series.Classes;
using Series.Enuns;
using Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
           while(opcaoUsuario.ToUpper() != "X") 
            {
                switch (opcaoUsuario) 
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    //case "X":
                    //    //
                    //    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario() 
        {
            Console.WriteLine();
            Console.WriteLine("Séries a seu Dispor");
            Console.WriteLine("Informa a opção desejada:");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X -  Sair");

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return OpcaoUsuario;
        }

        private static void ListarSeries() 
        {
            Console.WriteLine("Suas Séries");

            var lista = repositorio.Lista();
            if (lista.Count == 0) 
            {
                Console.WriteLine("Nenhuma Lista para exibição.");
                return;
            }

            foreach (var serie in lista) 
            {
                var excluido = serie.RetornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), excluido ? "Sim" : "Não");
            }
        }

        private static void InserirSerie() 
        {
            Console.WriteLine("Insira uma Nova Série");

            foreach(int i in Enum.GetValues(typeof(Genero)))  
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o Gênero dentre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Lançamento");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                              Id: repositorio.ProximoId(),
                              Genero: (Genero)entradaGenero,
                              Titulo: entradaTitulo,
                              Ano: entradaAno,
                              Descricao: entradaDescricao
                                );

            repositorio.Insere(novaSerie);
        }

        public static void AtualizarSerie() 
        {
            Console.WriteLine("Qual o ID da série?");
            int idSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o Gênero dentre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Lançamento");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                              Id: idSerie,
                              Genero: (Genero)entradaGenero,
                              Titulo: entradaTitulo,
                              Ano: entradaAno,
                              Descricao: entradaDescricao
                                );

            repositorio.Atualiza(idSerie,novaSerie);
        }

        public static void ExcluirSerie() 
        {
            Console.WriteLine("Qual o ID da Série?");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);
        }

        public static void VisualizarSerie() 
        {
            Console.WriteLine("Qual o ID da Série?");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaId(idSerie);

            Console.WriteLine(serie);
        }
    }
}
