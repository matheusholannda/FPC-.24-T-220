using System;

namespace BibliotecaDigital.Models
{
    public class Livro
    {
        // Propriedades do livro
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public bool Disponivel { get; set; }

        // Construtor que inicializa as propriedades e define Disponivel como true
        public Livro(int id, string titulo, string autor, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Disponivel = true;
        }
    }
}
