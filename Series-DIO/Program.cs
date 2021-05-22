using System;
using Series_DIO.Classes;
using Series_DIO.Enums;

namespace Series_DIO
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            var escolha = ObterOpcaoUsuario();

            while (escolha != "X")
            {
                switch (escolha)
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
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                escolha = ObterOpcaoUsuario();
            }

            Console.WriteLine("    -------------------------");
            Console.WriteLine(">>> | OBRIGADO POR UTILIZAR | <<<\n>>> |    NOSSOS SERVIÇOS    | <<<");
            Console.WriteLine("    -------------------------");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\n>>> Bem vindo ao DIO Séries <<<\n");
            
            Console.WriteLine("/-----------------------------\\");
            Console.WriteLine("| Informe a opção desejada:   |");
            Console.WriteLine("| 1. Listar séries            |");
            Console.WriteLine("| 2. Inserir nova série       |");
            Console.WriteLine("| 3. Atualizar série          |");
            Console.WriteLine("| 4. Excluir série            |");
            Console.WriteLine("| 5. Vizualizar série         |");
            Console.WriteLine("| C. Limpar tela              |");
            Console.WriteLine("| X. Sair                     |");
            Console.WriteLine("\\-----------------------------/\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine(">>> LISTAR SÉRIES <<<\n");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada!\n");
                return;
            }

            foreach (var e in lista)
            {
                Console.WriteLine($"#ID {e.retornaId()}: {e.retornaTitulo()}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine(">>> INSERIR NOVA SÉRIE <<<\n");

            var novaSerie = CriarSerie(repositorio.ProximoId());
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine(">>> ATUALIZAR SÉRIE <<<\n");

            Console.Write("Digite o ID da série que deseja atualizar: ");
            var serieAtualizaId = int.Parse(Console.ReadLine());

            var atualizaSerie = CriarSerie(serieAtualizaId); 

            repositorio.Atualiza(serieAtualizaId, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine(">>> EXCLUIR SÉRIE <<<\n");

            var lista = repositorio.Lista();

            Console.Write("Digite o ID da série que deseja excluir: ");
            var serieExcluiId = int.Parse(Console.ReadLine());

            Console.Write($"Deseja mesmo excluir {lista[serieExcluiId].retornaTitulo()}? [Y / N]");

            do
            {
                var confirmacao = Console.ReadLine().ToUpper();

                if (confirmacao == "Y")
                {
                    repositorio.Exclui(serieExcluiId);
                    return;
                }
                else if (confirmacao == "N")
                {
                    Console.WriteLine("Operação cancelada!");
                    return;
                }
                else
                {
                    continue;
                }
            } while (true);
        }

        private static void VizualizarSerie()
        {
            Console.WriteLine(">>> VIZUALIZAR SÉRIE <<<\n");

            Console.Write("Digite o ID da série que deseja vizualizar: ");
            var serieId = int.Parse(Console.ReadLine());

            var serieEscolhida = repositorio.RetornaPorId(serieId);

            Console.WriteLine(serieEscolhida);
        }

        private static Serie CriarSerie(int x)
        {
            var contador = 1;
            for (var i = 1; i < 6; i++)
            {
                for (var j = 1; j < 4; j++)
                {
                    Console.Write($"{contador} - {Enum.GetName(typeof(Genero), contador)}\t\t\t");
                    contador++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Digite o gênero dentre as opções acima: ");
            var serieGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            var serieTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            var serieAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            var serieDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: x, genero: (Genero)serieGenero, titulo: serieTitulo, descricao: serieDescricao, ano: serieAno);

            return novaSerie;
        }
    }
}
