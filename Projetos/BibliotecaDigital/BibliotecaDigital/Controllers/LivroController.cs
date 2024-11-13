using BibliotecaDigital.Models;
using System;
using System.Collections.Generic;

namespace BibliotecaDigital.Controllers
{
    public class LivroController
    {
        // Campo para armazenar o contexto da biblioteca, usado para acessar dados dos livros
        private BibliotecaContext _context;

        // Construtor que inicializa o contexto da biblioteca
        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }

        // Método para adicionar um novo livro ao contexto
        public void AdicionarLivro(Livro livro) => _context.Livros.Add(livro);

        // Método para listar todos os livros no contexto
        public List<Livro> ListarLivros() => _context.Livros;

        // Método para atualizar as informações de um livro existente
        public void AtualizarLivro(int id, string titulo, string autor, int anoPublicacao)
        {
            Livro livro = _context.Livros.FirstOrDefault(l => l.Id == id);
            if (livro != null)
            {
                livro.Titulo = titulo;
                livro.Autor = autor;
                livro.AnoPublicacao = anoPublicacao;
            }
        }

        // Método para remover um livro do contexto
        public void RemoverLivro(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(l => l.Id == id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
            }
        }
    }
}
