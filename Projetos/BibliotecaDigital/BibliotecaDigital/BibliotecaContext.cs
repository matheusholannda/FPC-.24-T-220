using BibliotecaDigital.Models;
using System;
using System.Collections.Generic;

namespace BibliotecaDigital
{
    public class BibliotecaContext
    {
        // Lista de livros disponíveis na biblioteca
        public List<Livro> Livros { get; set; } = new List<Livro> { };

        // Lista de usuários registrados na biblioteca
        public List<Usuario> Usuarios { get; set; } = new List<Usuario> { };

        // Lista de empréstimos realizados na biblioteca
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo> { };
    }
}
