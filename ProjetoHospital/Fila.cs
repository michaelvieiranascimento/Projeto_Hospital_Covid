using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoHospital
{
    internal class Fila
    {
        public string Pathfile = @"C:\Users\Michael\source\repos\ProjetoHospital\ProjetoHospital\bin\Debug\net5.0";
        public Paciente Cabeca { get; set; }
        public Paciente Cauda { get; set; }

        public Fila()
        {
            Cabeca = null;
            Cauda = null;
        }
        public void Inserir(Paciente paciente)
        {
            if (Vazia())
            {
                Cabeca = paciente;
                Cauda = paciente;
            }
            else
            {
                Cauda.Proximo = paciente;
                paciente.Anterior = Cauda;
                Cauda = paciente;
            }
        }
        public bool Vazia()
        {
            if (Cabeca == null && Cauda == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void InserirInformacoesPaciente(Paciente paciente, string arquivo)
        {
            bool aguardandoNaFila = false;

            try
            {
                if (!File.Exists($"{Pathfile}\\{arquivo}.txt"))
                {
                    File.Create($"{Pathfile}\\{arquivo}.txt").Close();
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }


            try
            {
                StreamReader sr = new StreamReader($"{Pathfile}\\{arquivo}.txt");
                string line = sr.ReadLine();


                while (line != null)
                {
                    string[] dados = line.Split(";");

                    if (paciente.CPF == dados[0])
                    {
                        aguardandoNaFila = true;
                        sr.Close();
                        break;
                    }
                    line = sr.ReadLine();
                }
                sr.Close();

                

                if (!aguardandoNaFila)
                {
                    
                    StreamWriter sw = new StreamWriter($"{Pathfile}\\{arquivo}.txt",append:true);
                    sw.WriteLine($"{paciente.CPF};{paciente.Nome};{paciente.Sexo};{paciente.DataNascimento.ToString("dd/MM/yyyy")};");
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}


