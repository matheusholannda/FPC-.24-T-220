using System;
using System.Collections.Generic;

namespace BibliotecaDigital.Models
{
    public class Usuario
    {
        // Propriedades do usuário: identificador, nome, limite de empréstimos e lista de empréstimos ativos
        public int Id { get; set; }
        public string Nome { get; set; }
        public int LimiteEmprestimos { get; set; }
        public List<Emprestimo> EmprestimosAtivos { get; set; } = new List<Emprestimo>();

        // Construtor que inicializa o ID, nome e limite de empréstimos do usuário
        public Usuario(int id, string nome, int limiteEmprestimos)
        {
            Id = id;
            Nome = nome;
            LimiteEmprestimos = limiteEmprestimos;
        }

        // Método que verifica se o usuário pode realizar um novo empréstimo
        public bool PodeEmprestar() => EmprestimosAtivos.Count < LimiteEmprestimos;
    }
}
