using System;

namespace BibliotecaDigital.Models
{
    // Classe UsuarioRegular que herda da classe Usuario
    public class UsuarioRegular : Usuario
    {
        // Construtor que inicializa um usuário regular com limite de empréstimos fixo de 5
        public UsuarioRegular(int id, string nome) : base(id, nome, 5) { }
    }
}
