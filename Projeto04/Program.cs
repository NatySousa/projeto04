using Projeto04.Entities;
using Projeto04.Repositories;
using System;

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n*** CADASTRO DE FUNCIONÁRIOS ***\n");
            try
            {
                //criando um objeto da classe Funcionario
                var funcionario = new Funcionario();

                Console.Write("\nInforme o nome do funcionário:");
                funcionario.Nome = Console.ReadLine();

                Console.Write("\nInforme o cpf do funcionário:");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("\nInforme a matricula do funcionário:");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("\nInforme a data de admissão do funcionário: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                //gravando o funcionário na base de dados
                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Inserir(funcionario);

                Console.WriteLine("\nFuncionário cadastrado com sucesso.");

                Console.WriteLine("\n*** CONSULTA DE FUNCIONÁRIOS ***\n");

                //consultar e imprimir os funcionários cadastrados
                foreach (var item in funcionarioRepository.Consultar())
                {
                    Console.WriteLine("Id do Funcionário..: " + item.IdFuncionario);
                    Console.WriteLine("Nome...............: " + item.Nome);
                    Console.WriteLine("CPF................: " + item.Cpf);
                    Console.WriteLine("Matricula..........: " + item.Matricula);
                    Console.WriteLine("Data de Admissão...: " + item.DataAdmissao);
                    Console.WriteLine("---");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}

