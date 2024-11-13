using System;

namespace BibliotecaDigital.Models
{
    // Classe UsuarioPremium que herda da classe Usuario
    public class UsuarioPremium : Usuario
    {
        // Construtor que inicializa um usuário premium com limite de empréstimos fixo de 10
        public UsuarioPremium(int id, string nome) : base(id, nome, 10) { }
    }
}
