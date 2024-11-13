using BibliotecaDigital.Models;
using System;
using System.Collections.Generic;

namespace BibliotecaDigital.Controllers
{
    public class EmprestimoController
    {
        // Campo para armazenar o contexto da biblioteca, usado para acessar dados
        private BibliotecaContext _context;

        // Construtor que inicializa o contexto da biblioteca
        public EmprestimoController(BibliotecaContext context)
        {
            _context = context;
        }

        // Método para emprestar um livro a um usuário
        public string EmprestarLivro(int idLivro, int idUsuario)
        {
            // Busca o livro e o usuário pelo ID no contexto
            Livro livro = _context.Livros.Find(l => l.Id == idLivro);
            Usuario usuario = _context.Usuarios.Find(u => u.Id == idUsuario);

            // Verifica se o livro está disponível e se o usuário pode realizar o empréstimo
            if (livro != null && livro.Disponivel && usuario != null && usuario.PodeEmprestar())
            {
                livro.Disponivel = false; // Marca o livro como indisponível
                Emprestimo emprestimo = new Emprestimo(livro, usuario); // Cria um novo empréstimo
                _context.Emprestimos.Add(emprestimo); // Adiciona o empréstimo ao contexto
                usuario.EmprestimosAtivos.Add(emprestimo); // Adiciona o empréstimo ao usuário
                return "Empréstimo realizado com sucesso!";
            }
            else
            {
                return "Empréstimo não permitido!";
            }
        }

        // Método para registrar a devolução de um livro
        public string DevolverLivro(int idLivro)
        {
            // Busca o empréstimo ativo do livro pelo ID, verificando se não foi devolvido ainda
            Emprestimo emprestimo = _context.Emprestimos.Find(e => e.Livro.Id == idLivro && e.DataDevolucao == null);

            if (emprestimo != null)
            {
                emprestimo.RegistrarDevolucao(); // Registra a data de devolução e marca o livro como disponível
                emprestimo.Usuario.EmprestimosAtivos.Remove(emprestimo); // Remove o empréstimo ativo do usuário
                return "Livro devolvido com sucesso!";
            }
            else
            {
                return "Livro não encontrado ou já devolvido!";
            }
        }

        // Método para listar todos os empréstimos no contexto
        public List<Emprestimo> ListarEmprestimos() => _context.Emprestimos;
    }
}