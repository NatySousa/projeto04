using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto04.Entities
{
    public class Funcionario
    {
        public Guid IdFuncionario{ get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }


    }
}
