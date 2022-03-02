using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoHospital
{
    internal class Paciente
    {
        public string Pathfile = @"C:\Users\Michael\source\repos\ProjetoHospital\ProjetoHospital\bin\Debug\net5.0";
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public Paciente Proximo { get; set; }
        public Paciente Anterior { get; set; }


        public Paciente()
        {

        }

        public Paciente(string nome, string cPF, DateTime dataNascimento, string sexo)
        {
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Proximo = null;
            Anterior = null;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nCPF: {CPF}\nSexo: {Sexo}\nData de Nascimento: {DataNascimento.ToString("dd/mm/yyyy")}";
        }

        public void CadastrarPaciente()
        {
            try
            {
                StreamWriter sw = new StreamWriter(Pathfile + "\\Pacientes.txt",append:true);
                sw.WriteLine($"{CPF};{Nome};{Sexo};{DataNascimento.ToString("dd/MM/yyyy")};");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public Paciente BuscarPaciente(string cpf)
        {
            Paciente paciente;
            try
            {
                if(!File.Exists(Pathfile + "\\Pacientes.txt"))
                {
                    File.Create(Pathfile + "\\Pacientes.txt").Close();
                    return null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }


            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Michael\source\repos\ProjetoHospital\ProjetoHospital\bin\Debug\net5.0\Pacientes.txt");
                string line = sr.ReadLine();


                while (line != null)
                {
                    string[] dados = line.Split(";");

                    if (cpf == dados[0])
                    {
                        paciente = new Paciente(dados[1], dados[0], DateTime.Parse(dados[3]), dados[2]);
                        sr.Close();
                        return paciente;
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;

        }

    }
}

