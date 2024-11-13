using System;

namespace BibliotecaDigital.Models
{
    public class Emprestimo
    {
        // Propriedades do empréstimo: livro emprestado, usuário que fez o empréstimo, data de empréstimo e data de devolução
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; } // Nullable para permitir que seja nulo antes da devolução

        // Construtor que inicializa o livro, o usuário e define a data de empréstimo como a data atual
        public Emprestimo(Livro livro, Usuario usuario)
        {
            Livro = livro;
            Usuario = usuario;
            DataEmprestimo = DateTime.Now;
        }

        // Método para registrar a devolução do livro, definindo a data atual e atualizando a disponibilidade do livro
        public void RegistrarDevolucao()
        {
            DataDevolucao = DateTime.Now;
            Livro.Disponivel = true;
        }
    }
}
