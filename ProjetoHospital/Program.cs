using System;

namespace ProjetoHospital
{
    internal class Program
    {
            public static Fila fila_normal = new Fila();
            public static Fila fila_preferencial = new Fila();
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo Aplicativo do Hospital");

            string opcoesMenu;
            do
            {

                Console.Clear();
                switch (opcoesMenu = Menu())
                {
                    case "0":
                        break;



                    case "1":
                        Console.Clear();
                        NovoPaciente();
                      
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
            if((DateTime.Now.Year - paciente.DataNascimento.Year) >= 60)
            {
                fila_preferencial.InserirInformacoesPaciente(paciente, "FilaPreferencial");
                fila_preferencial.Inserir(paciente);
            }
            else
            {
                fila_normal.InserirInformacoesPaciente(paciente, "FilaNormal");
                fila_normal.Inserir(paciente);
            }
            
        }

    }
}
