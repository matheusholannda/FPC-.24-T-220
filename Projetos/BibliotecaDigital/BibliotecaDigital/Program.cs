using BibliotecaDigital;
using BibliotecaDigital.Controllers;
using BibliotecaDigital.Models;

// Criação do contexto e dos controladores
BibliotecaContext context = new BibliotecaContext();
LivroController livroController = new LivroController(context);
UsuarioController usuarioController = new UsuarioController(context);
EmprestimoController emprestimoController = new EmprestimoController(context);

while (true)
{
    Console.Clear();
    Console.WriteLine("Biblioteca do Holandinha");
    Console.WriteLine("1. Gerenciar Livros");
    Console.WriteLine("2. Gerenciar Usuários");
    Console.WriteLine("3. Gerenciar Empréstimos");
    Console.WriteLine("4. Sair");
    Console.WriteLine();
    Console.Write("Escolha uma opção: ");
    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            GerenciarLivros(livroController); // Gerenciar livros
            break;
        case 2:
            GerenciarUsuarios(usuarioController); // Gerenciar usuários
            break;
        case 3:
            GerenciarEmprestimos(emprestimoController, usuarioController, livroController); // Gerenciar empréstimos
            break;
        case 4:
            break; // Sair
        default:
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar");
            break;
    }
}

// Método para gerenciar livros
static void GerenciarLivros(LivroController livroController)
{
    Console.Clear();
    Console.WriteLine("Gerenciamento de Livros");
    Console.WriteLine("1. Adicionar Livro");
    Console.WriteLine("2. Listar Livros");
    Console.WriteLine("3. Atualizar Livro");
    Console.WriteLine("4. Remover Livro");
    Console.WriteLine("5. Voltar");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Adicionar um novo livro
            Console.Write("Digite o ID do Livro: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite o Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite o Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Digite o Ano de Publicação: ");
            int anoPublicacao = int.Parse(Console.ReadLine());

            livroController.AdicionarLivro(new Livro(id, titulo, autor, anoPublicacao));
            Console.WriteLine("Livro adicionado com sucesso!");
            break;

        case "2":
            // Listar todos os livros
            foreach (var livro in livroController.ListarLivros())
            {
                Console.WriteLine($"ID: {livro.Id}, Título: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.AnoPublicacao}, Disponível: {livro.Disponivel}");
            }
            break;

        case "3":
            // Atualizar informações de um livro
            Console.Write("Digite o ID do Livro que deseja atualizar: ");
            int livroId = int.Parse(Console.ReadLine());
            Console.Write("Novo Título: ");
            string novoTitulo = Console.ReadLine();
            Console.Write("Novo Autor: ");
            string novoAutor = Console.ReadLine();
            Console.Write("Novo Ano de Publicação: ");
            int novoAno = int.Parse(Console.ReadLine());

            livroController.AtualizarLivro(livroId, novoTitulo, novoAutor, novoAno);
            Console.WriteLine("Livro atualizado com sucesso!");
            break;

        case "4":
            // Remover um livro
            Console.Write("Digite o ID do Livro que deseja remover: ");
            int idRemover = int.Parse(Console.ReadLine());

            livroController.RemoverLivro(idRemover);
            Console.WriteLine("Livro removido com sucesso!");
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("Pressione qualquer tecla para voltar...");
    Console.ReadKey();
}

// Método para gerenciar usuários
static void GerenciarUsuarios(UsuarioController usuarioController)
{
    Console.Clear();
    Console.WriteLine("Gerenciamento de Usuários");
    Console.WriteLine("1. Adicionar Usuário");
    Console.WriteLine("2. Listar Usuários");
    Console.WriteLine("3. Atualizar Usuário");
    Console.WriteLine("4. Remover Usuário");
    Console.WriteLine("5. Voltar");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Adicionar um novo usuário
            Console.Write("Digite o ID do Usuário: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome do Usuário: ");
            string nome = Console.ReadLine();
            Console.Write("Tipo de Usuário (1 = Regular, 2 = Premium): ");
            int tipo = int.Parse(Console.ReadLine());

            Usuario usuario = tipo == 1 ? new UsuarioRegular(id, nome) : new UsuarioPremium(id, nome);
            usuarioController.AdicionarUsuario(usuario);
            Console.WriteLine("Usuário adicionado com sucesso!");
            break;

        case "2":
            // Listar todos os usuários
            foreach (var u in usuarioController.ListarUsuarios())
            {
                Console.WriteLine($"ID: {u.Id}, Nome: {u.Nome}, Limite: {u.LimiteEmprestimos}");
            }
            break;

        case "3":
            // Atualizar informações de um usuário
            Console.Write("Digite o ID do Usuário que deseja atualizar: ");
            int usuarioId = int.Parse(Console.ReadLine());
            Console.Write("Novo Nome: ");
            string novoNome = Console.ReadLine();

            usuarioController.AtualizarUsuario(usuarioId, novoNome);
            Console.WriteLine("Usuário atualizado com sucesso!");
            break;

        case "4":
            // Remover um usuário
            Console.Write("Digite o ID do Usuário que deseja remover: ");
            int idRemover = int.Parse(Console.ReadLine());

            usuarioController.RemoverUsuario(idRemover);
            Console.WriteLine("Usuário removido com sucesso!");
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("Pressione qualquer tecla para voltar...");
    Console.ReadKey();
}

// Método para gerenciar empréstimos
static void GerenciarEmprestimos(EmprestimoController emprestimoController, UsuarioController usuarioController, LivroController livroController)
{
    Console.Clear();
    Console.WriteLine("Gerenciamento de Empréstimos");
    Console.WriteLine("1. Emprestar Livro");
    Console.WriteLine("2. Devolver Livro");
    Console.WriteLine("3. Listar Empréstimos");
    Console.WriteLine("4. Voltar");
    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Emprestar um livro
            Console.Write("Digite o ID do Usuário: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("Digite o ID do Livro: ");
            int idLivro = int.Parse(Console.ReadLine());

            string resultadoEmprestimo = emprestimoController.EmprestarLivro(idLivro, idUsuario);
            Console.WriteLine(resultadoEmprestimo);
            break;

        case "2":
            // Devolver um livro
            Console.Write("Digite o ID do Livro para devolução: ");
            int idLivroDevolucao = int.Parse(Console.ReadLine());

            string resultadoDevolucao = emprestimoController.DevolverLivro(idLivroDevolucao);
            Console.WriteLine(resultadoDevolucao);
            break;

        case "3":
            // Listar todos os empréstimos
            foreach (var emprestimo in emprestimoController.ListarEmprestimos())
            {
                Console.WriteLine($"Livro: {emprestimo.Livro.Titulo}, Usuário: {emprestimo.Usuario.Nome}, Data Empréstimo: {emprestimo.DataEmprestimo}, Data Devolução: {(emprestimo.DataDevolucao.HasValue ? emprestimo.DataDevolucao.Value.ToString() : "Em aberto")}");
            }
            break;

        case "4":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("Pressione qualquer tecla para voltar...");
    Console.ReadKey();
}
