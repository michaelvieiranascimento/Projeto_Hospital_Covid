using System;

namespace ProjetoHospital
{
    internal class Program
    {
        public static Fila fila_normal = new Fila();
        public static Fila fila_preferencial = new Fila();
        static void Main(string[] args)
        {

            fila_normal.CarregarDadosDoArquivo(fila_normal, "FilaNormal");
            fila_preferencial.CarregarDadosDoArquivo(fila_preferencial, "FilaPreferencial");

            int preferencial = 0;



            Console.WriteLine("Bem vindo Aplicativo do Hospital");

            string opcoesMenu;
            do
            {

                Console.Clear();
                switch (opcoesMenu = Menu())
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine("<><Programa Fechando><>");
                        break;


                    case "1":

                        Console.Clear();
                        NovoPaciente();



                        break;

                    case "2":
                        if (fila_preferencial.Elementos > 0 && preferencial < 2)
                        {
                            Console.WriteLine(fila_preferencial.Cabeca.ToString());
                            preferencial++;
                            ChamarExame(fila_preferencial, "Fila Preferencial");
                        }
                        else if (fila_normal.Elementos > 0)
                        {
                            Console.WriteLine(fila_normal.Cabeca.ToString());
                            preferencial = 0;
                            ChamarExame(fila_normal, "Fila Normal");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("**** Filas estão vazias ****");
                            preferencial = 0;
                        }
                        break;

                    case "3":
                        Console.Clear();
                        BuscarPacienteNaFila();
                        break;

                    case "4":
                        Console.Clear();
                        BuscarHistorico();
                        break;


                    case "5":
                        Console.Clear();
                        fila_normal.ImprimirDados();

                        break;

                    case "6":
                        Console.Clear();
                        fila_preferencial.ImprimirDados();

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ação Inválida");
                        break;
                }
                Console.ReadKey();
            } while (opcoesMenu != "0");

        }

        public static string Menu()
        {
            Console.WriteLine("----Menu---");
            Console.WriteLine("[1] Chamar Paciente");
            Console.WriteLine("[2] Chamar Paciente para exame");
            Console.WriteLine("[3] Buscar Paciente");
            Console.WriteLine("[4] Buscar Historico Paciente");
            Console.WriteLine("[5] Imprimir Fila Normal");
            Console.WriteLine("[6] Imprimir Fila Preferencial");
            Console.WriteLine("");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("****");
            Console.WriteLine();

            return Console.ReadLine();

        }
        public static Paciente CadastrarPaciente(string cpf)
        {

            string sexo;

            Console.WriteLine($"Informe o CPF:\n{cpf}");

            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine().ToUpper();

            do
            {
                Console.Write("Informe o sexo [Masculino [M], Feminino [F]:");
                sexo = Console.ReadLine().ToUpper();
                if (sexo != "M" && sexo != "F")
                {
                    Console.WriteLine("Opcao Invalida, tente novamente");
                }

            } while (sexo != "M" && sexo != "F");

            Console.Write("Informe a data de nascimento:");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Paciente paciente = new Paciente(nome, cpf, data, sexo);

            paciente.CadastrarPaciente();
            return paciente;
        }
        public static void NovoPaciente()
        {
            Console.WriteLine("Informe o cpf:");
            string cpf = Console.ReadLine();
            Paciente paciente = new Paciente();
            paciente = paciente.BuscarPaciente(cpf);

            if (paciente == null)
            {
                paciente = CadastrarPaciente(cpf);
            }
            else
            {
                Console.WriteLine(paciente.ToString());
            }
            if ((DateTime.Now.Year - paciente.DataNascimento.Year) >= 60)
            {
                fila_preferencial.InserirDadosNoArquivo(paciente, "FilaPreferencial");
            }
            else
            {
                fila_normal.InserirDadosNoArquivo(paciente, "FilaNormal");

            }
        }

        private static void BuscarHistorico()
        {
            Console.Clear();

            Paciente paciente = new Paciente();

            Console.WriteLine("****************** Buscar Paciente ****************");
            Console.Write("\nInforme o CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("\n***************************************************");

            paciente = paciente.BuscarPaciente(cpf);

            if (paciente != null)
            {
                Console.Clear();

                Console.WriteLine("******************** Ficha do Paciente ******************");
                Console.WriteLine(paciente.ToString());
                Console.WriteLine("\n****************** Histórico do Paciente ****************");
                paciente.CarregarHistoricoDoPaciente(cpf);
                Console.WriteLine("\n*********************************************************");
            }
            else
                Console.WriteLine("Histórico não encontrado");

        }
        public static void ChamarExame(Fila fila, string arquivo)
        {
            Console.Clear();

            Console.WriteLine(fila.Cabeca.ToString());

            string opcao;

            do
            {
                Console.WriteLine("\nQual o resultado do teste de Covid-19?");
                Console.WriteLine("[1] Positivo");
                Console.WriteLine("[2] Negativo");
                Console.WriteLine("[3] Não Reagente");
                opcao = Console.ReadLine();

            } while (opcao != "1" && opcao != "2" && opcao != "3");

            string resultadoTeste = (opcao == "1")
                ? "Positivo"
                : (opcao == "2")
                ? "Negativo"
                : "Não Reagente";

            Console.WriteLine("\nQuantidade em dias com os sintomas: ");
            int dias = int.Parse(Console.ReadLine());


            string[] sintomas = Sintomas();

            string[] comorbidades = Comorbidades();


            Console.Clear();

            Console.WriteLine(fila.Cabeca.ToString());

            Console.WriteLine($"\nResultado teste de Covid: {resultadoTeste}");

            Console.WriteLine("\n[Sintomas]");
            Console.WriteLine($"Febre: {sintomas[0]} \n" +
                $"Dor de Cabeça: {sintomas[1]}\n" +
                $"Falta de Paladar: {sintomas[2]}\n" +
                $"Falta de Olfato:  {sintomas[3]}");
            Console.WriteLine($"\nQuantidade de dias com sintomas: {dias}");

        }
    
        private static string[] Sintomas()
            {
                string[] sintomas = new string[4] { "NÃO", "NÃO", "NÃO", "NÃO" };

                string febre, dorCabeca, semPaladar, semOfato;

                do
                {
                    Console.WriteLine("Esta ou esteve com febre? [S - SIM] [N - NÃO]");
                    febre = Console.ReadLine().ToUpper();
                    if (febre == "S")
                    {
                        sintomas[0] = "SIM";
                    }
                    else if (febre == "N")
                    {
                        sintomas[0] = "NÃO";
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!!!");
                    }
                } while (febre != "S" && febre != "N");
                do
                {
                    Console.WriteLine("Esta ou esteve com dor de cabeça? [S - SIM] [N - NÃO]");
                    dorCabeca = Console.ReadLine().ToUpper();
                    if (dorCabeca == "S")
                    {
                        sintomas[1] = "SIM";
                    }
                    else if (dorCabeca == "N")
                    {
                        sintomas[1] = "NÃO";
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!!!");
                    }
                } while (dorCabeca != "S" && dorCabeca != "N");
                do
                {
                    Console.WriteLine("Esta ou esteve com falta de paladar [S - SIM] [N - NÃO]");
                    semPaladar = Console.ReadLine().ToUpper();
                    if (semPaladar == "S")
                    {
                        sintomas[2] = "SIM";
                    }
                    else if (semPaladar == "N")
                    {
                        sintomas[2] = "NÃO";
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!!!");
                    }
                } while (semPaladar != "S" && semPaladar != "N");
                do
                {
                    Console.WriteLine("Esta ou esteve com falta de ofato? [S - SIM] [N - NÃO]");
                    semOfato = Console.ReadLine().ToUpper();
                    if (semOfato == "S")
                    {
                        sintomas[3] = "SIM";
                    }
                    else if (semOfato == "N")
                    {
                        sintomas[3] = "NÃO";
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!!!");
                    }

                } while (semOfato != "S" && semOfato != "N");
                return sintomas;
            }

        public static void BuscarPacienteNaFila()
            {
                Console.WriteLine("Informe o cpf:");
                string cpf = Console.ReadLine();
                Paciente paciente = new Paciente();

                if ((paciente = fila_normal.Buscar(cpf)) != null)
                {
                    Console.Write(paciente.ToString());
                    Console.WriteLine("\n\n***Paciente aguardando na Fila Normal****");
                }
                else if ((paciente = fila_preferencial.Buscar(cpf)) != null)
                {
                    Console.WriteLine(paciente.ToString());
                    Console.WriteLine("\n\n****Paciente aguardando na Fila Preferencial****");
                }
                else
                {
                    Console.WriteLine("\n\n****Paciente não está em nenhuma fila****");
                }
            }

        public static string[] Comorbidades()
            {
                string[] comorbidadeArray = new string[5] { null, null, null, null, null };
                Console.WriteLine("Possui comorbidade? [S - SIM] [N - NÃO]");
                string comorbidade = Console.ReadLine().ToUpper();
                int i = 1, x = 0;

                do
                {
                    if (comorbidade == "N")
                    {
                        break;
                    }
                    do
                    {
                        if (comorbidade != "S" && comorbidade != "N")
                        {
                            Console.WriteLine("Opção inválida, tente novamente!");
                            Console.WriteLine("Possui comorbidade? [S - SIM] [N - NÃO]");
                            comorbidade = Console.ReadLine().ToUpper();
                        }
                    } while (comorbidade != "S" && comorbidade != "N");
                    if (comorbidade == "S")
                    {
                        Console.Write($"Informe a comorbidade {i}: ");
                        comorbidadeArray[x] = Console.ReadLine();
                        Console.WriteLine("Possui mais alguma comorbidade? [S - SIM] [N - NÃO]");
                        comorbidade = Console.ReadLine().ToUpper();
                        x++;
                        i++;
                    }
                } while (comorbidade != "N");
                return comorbidadeArray;

            }

        }
    }

