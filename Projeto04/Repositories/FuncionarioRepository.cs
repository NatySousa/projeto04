using Dapper;
using Projeto04.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

//localização da classe no projeto
namespace Projeto04.Repositories
{
    //definição da classe
    //public -> acesso total!
    public class FuncionarioRepository
    {
        private string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAula04;Integrated Security=True;
              Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //método para inserir um funcionario na base de dados
        public void Inserir(Funcionario funcionario)
        {

            //escrevendo o comando SQL (INSERT)
            var sql = @"
                    	INSERT INTO FUNCIONARIO(IDFUNCIONARIO, NOME, CPF, MATRICULA, DATAADMISSAO)                              
                    	VALUES(NEWID(), @Nome, @Cpf, @Matricula, @DataAdmissao)
                     ";
            //conectando no banco de dados..
            using (var connection = new SqlConnection(connectionstring))
            {
                //executando o comando SQL..
                connection.Execute(sql, funcionario);
            }

        }
        //método para atualizar um funcionário na base de dados
        public void Atualizar(Funcionario funcionario)
        {
            var sql = @"
                    UPDATE FUNCIONARIO 
                    SET
                        NOME = @Nome,
                        CPF = @Cpf,
                        MATRICULA = @Matricula,
                        DATAADMISSAO = @DataAdmissao
                    WHERE
                        IDFUNCIONARIO = @IdFuncionario
                ";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, funcionario);
            }

        }
        //método para excluir um funcionário na base de dados..
        public void Excluir(Funcionario funcionario)
        {
            var sql = @"
                    DELETE FROM FUNCIONARIO
                    WHERE IDFUNCIONARIO = @IdFuncionario
                ";

            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Execute(sql, funcionario);
            }

        }

        //método para consultar todos os funcionarios na base de dados..
        public List<Funcionario> Consultar()
        {
            var sql = @"
                    SELECT * FROM FUNCIONARIO
                    ORDER BY NOME
                ";

            using (var connection = new SqlConnection(connectionstring))
            {
                return connection.Query<Funcionario>(sql).ToList();

            }
        }
    }
}