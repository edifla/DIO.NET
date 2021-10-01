using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {   
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                Console.Clear();
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
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine();
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            
            Console.WriteLine("DIO Series a seu dispor!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries: ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            
            foreach (var serie in lista)
            {
                string resp;

                var excluido = serie.retornaExcluido();
                Console.WriteLine("Você quer ver as séries excluídas? [S/N]");
                resp = Console.ReadLine();
                if (resp.ToUpper() == "S" || resp.ToUpper() == "SIM")
                {
                    if (serie.retornaExcluido() == true)
                    {
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("Séries Excluídas: ");                            
                        Console.WriteLine("ID {0}: {1} / Excluído: {2}", serie.retornoId(), serie.retornaTitulo(), excluido? "Excluido" : "");
                    }
                    else
                    {
                        Console.WriteLine("Não existem séries excluídas ainda.");
                    }
                }
                else if (resp.ToUpper() == "N" || resp.ToUpper() == "NAO")
                {
                    if(serie.retornaExcluido() == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ID {0}: {1}", serie.retornoId(), serie.retornaTitulo());
                    }
                }
                else
                {
                    Console.WriteLine("Em caso de ter digitado uma resposta diferente da ofertada, não irá mostrar nada.");
                }
            }   
            Console.WriteLine();       
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");      
            Console.ReadKey();  
            Console.Clear();
 
        }
        private static void InserirSerie()
        {
            bool resultado;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            string entrada = Console.ReadLine();
            int entradaGenero;

            resultado = int.TryParse(entrada, out entradaGenero);
            while (resultado != true || entradaGenero < 0 || entradaGenero > 13)
            {
                if (resultado)
                {
                    while (entradaGenero < 0 || entradaGenero > 13)
                    {
                        if (entradaGenero < 0 || entradaGenero > 13)
                        {
                            Console.WriteLine("Por favor, insira apenas os números mostrados na tela. (DE 1 ATÉ 13)");
                            Console.WriteLine("Digite o gênero entre as opções acima: ");
                            entrada = Console.ReadLine();
                            resultado = int.TryParse(entrada, out entradaGenero);
                            if (resultado)
                            {
                                entradaGenero = int.Parse(entrada);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nada de letras e apenas números de 1 a 13!");
                            entrada = Console.ReadLine();
                            resultado = int.TryParse(entrada, out entradaGenero);
                            if (resultado)
                            {
                                entradaGenero = int.Parse(entrada);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nada de letras e apenas números de 1 a 13!");
                    entrada = Console.ReadLine();
                    resultado = int.TryParse(entrada, out entradaGenero);
                    if (resultado)
                    {
                        entradaGenero = int.Parse(entrada);
                    }
                }
            }
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno;
            string entradaData = Console.ReadLine();
            resultado = false;
            resultado = int.TryParse(entradaData, out entradaAno);
            while (resultado != true || entradaAno < 0 || entradaAno > 2022)
            {
                if (resultado)
                {
                    if (entradaAno < 0 || entradaAno > 2022)
                    {
                        Console.WriteLine("Letras não são bem-vindas!");
                        Console.WriteLine("Bom, sabemos que antes de 0 ano não tinha filme e nem tem filme no futuro ainda, então escreva acima de 0 e abaixo de 2022!");
                        Console.WriteLine("Digite um ano válido: ");
                        entradaData = Console.ReadLine();
                        resultado = int.TryParse(entradaData, out entradaAno);
                        if(resultado)
                        {
                            entradaAno = int.Parse(entradaData);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ai ai, botando letras ou um número errado de novo, né?");
                        Console.WriteLine("Facilite sua vida, digite um ano válido: ");
                        entradaData = Console.ReadLine();
                        resultado = int.TryParse(entradaData, out entradaAno);
                        if(resultado)
                        {
                            entradaAno = int.Parse(entradaData);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Botando letras ou um ano inválido!");
                    Console.WriteLine("Digite um ano válido: ");
                    entradaData = Console.ReadLine();
                    resultado = int.TryParse(entradaData, out entradaAno);
                    if(resultado)
                    {
                        entradaAno = int.Parse(entradaData);
                    }
                }
            }

            Console.WriteLine("Digita a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
            Console.Clear();
        }
        private static void AtualizarSerie()
        {
            bool resultado;
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            string entrada = Console.ReadLine();
            int entradaGenero;

            resultado = int.TryParse(entrada, out entradaGenero);
            while (resultado != true || entradaGenero < 0 || entradaGenero > 13)
            {
                if (resultado)
                {
                    while (entradaGenero < 0 || entradaGenero > 13)
                    {
                        if (entradaGenero < 0 || entradaGenero > 13)
                        {
                            Console.WriteLine("Por favor, insira apenas os números mostrados na tela. (DE 1 ATÉ 13)");
                            Console.WriteLine("Digite o gênero entre as opções acima: ");
                            entrada = Console.ReadLine();
                            resultado = int.TryParse(entrada, out entradaGenero);
                            if (resultado)
                            {
                                entradaGenero = int.Parse(entrada);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nada de letras e apenas números de 1 a 13!");
                            entrada = Console.ReadLine();
                            resultado = int.TryParse(entrada, out entradaGenero);
                            if (resultado)
                            {
                                entradaGenero = int.Parse(entrada);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nada de letras e apenas números de 1 a 13!");
                    entrada = Console.ReadLine();
                    resultado = int.TryParse(entrada, out entradaGenero);
                    if (resultado)
                    {
                        entradaGenero = int.Parse(entrada);
                    }
                }
            }
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno;
            string entradaData = Console.ReadLine();
            resultado = false;
            resultado = int.TryParse(entradaData, out entradaAno);
            while (resultado != true || entradaAno < 0 || entradaAno > 2022)
            {
                if (resultado)
                {
                    if (entradaAno < 0 || entradaAno > 2022)
                    {
                        Console.WriteLine("Letras não são bem-vindas!");
                        Console.WriteLine("Bom, sabemos que antes de 0 ano não tinha filme e nem tem filme no futuro ainda, então escreva acima de 0 e abaixo de 2022!");
                        Console.WriteLine("Digite um ano válido: ");
                        entradaData = Console.ReadLine();
                        resultado = int.TryParse(entradaData, out entradaAno);
                        if(resultado)
                        {
                            entradaAno = int.Parse(entradaData);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ai ai, botando letras ou um número errado de novo, né?");
                        Console.WriteLine("Facilite sua vida, digite um ano válido: ");
                        entradaData = Console.ReadLine();
                        resultado = int.TryParse(entradaData, out entradaAno);
                        if(resultado)
                        {
                            entradaAno = int.Parse(entradaData);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Botando letras ou um ano inválido!");
                    Console.WriteLine("Digite um ano válido: ");
                    entradaData = Console.ReadLine();
                    resultado = int.TryParse(entradaData, out entradaAno);
                    if(resultado)
                    {
                        entradaAno = int.Parse(entradaData);
                    }
                }
            }

            Console.WriteLine("Digita a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.Clear();
        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Você quer mesmo apagar essa série? ");
            var resp = Console.ReadLine();
            if(resp.ToUpper() == "S" || resp.ToUpper() == "SIM")
            {
                repositorio.Exclui(indiceSerie);
                Console.WriteLine("Série Excluída!");
            }
            Console.WriteLine("Aperte qualquer tecla para voltar para o menu.");
            Console.ReadKey();
            Console.Clear();
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.Clear();
            Console.WriteLine(serie);
        }
    }
}
