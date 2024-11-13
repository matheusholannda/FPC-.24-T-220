using BibliotecaDigital.Models;
using System;
using System.Collections.Generic;

namespace BibliotecaDigital.Controllers
{
    public class UsuarioController
    {
        // Campo para armazenar o contexto da biblioteca, usado para acessar dados dos usuários
        private BibliotecaContext _context;

        // Construtor que inicializa o contexto da biblioteca
        public UsuarioController(BibliotecaContext context)
        {
            _context = context;
        }

        // Método para adicionar um novo usuário ao contexto
        public void AdicionarUsuario(Usuario usuario) => _context.Usuarios.Add(usuario);

        // Método para listar todos os usuários no contexto
        public List<Usuario> ListarUsuarios() => _context.Usuarios;

        // Método para atualizar o nome de um usuário existente
        public void AtualizarUsuario(int id, string nome)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(l => l.Id == id);
            if (usuario != null)
            {
                usuario.Nome = nome;
            }
        }

        // Método para remover um usuário do contexto
        public void RemoverUsuario(int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(l => l.Id == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
        }
    }
}
