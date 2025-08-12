namespace SistemaAcademico;

class Program
{
    static void Main(string[] args)
    {
        var db = new DatabaseHelper();
        db.CriarBanco();
        
        while (true)
        {
            
            Console.Clear();
            DesenhaMenu();

            var opcao = Console.ReadLine();
            
            switch (opcao)
            {
                case "1":
                    CadastrarAluno(db);
                    break;
                case "2":
                    ListarAlunos(db);
                    break;
                case "3":
                    ExcluirAlunos(db);
                    break;
                
                case "4":
                    CadastrarMateria(db);
                    break;

                case "5":
                    ListarMateria(db);
                    break;
                case "6":
                    //CadastrarNota(db);
                    break;
                
                case "7":
                    LimparTela();
                    break;
                case "8":
                    return;
            }
        }
    }


    private static void DesenhaMenu()
    {
        Console.WriteLine("\n=== SISTEMA ACADÊMICO ===");
        Console.WriteLine("1. Cadastrar Aluno");
        Console.WriteLine("2. Listar Alunos");
        Console.WriteLine("3. Excluir Alunos");
        Console.WriteLine("4. Cadastrar Materia");
        Console.WriteLine("5. Listar Materias");
        Console.WriteLine("6. Cadastrar Nota para aluno");
        Console.WriteLine("7. Limpar Tela");
        Console.WriteLine("8. Sair");
        Console.Write("Opção: ");
    }

    static void LimparTela()
    {
        Console.Clear();
        
    } 
    
    
    static void CadastrarAluno(DatabaseHelper db)
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine();
        
        Console.Write("Email: ");
        var email = Console.ReadLine();
        
        Console.Write("Data Nascimento (dd/mm/aaaa): ");
        var data = DateTime.Parse(Console.ReadLine());
        
        var aluno = new Aluno { Nome = nome, Email = email, DataNascimento = data };
        db.InserirAluno(aluno);
        
        Console.WriteLine("Aluno cadastrado com sucesso! Pressione qualquer tecla para continuar.");
        Console.ReadKey();
        
    }
    private static void ExcluirAlunos(DatabaseHelper db)
    {
        Console.WriteLine("Digite o ID do aluno a ser excluído: ");
        var idAluno = Convert.ToInt32(Console.ReadLine());
        db.ExcluirAlunos(idAluno);
    }

    private static void ListarAlunos(DatabaseHelper db)
    {
        db.ListarAlunos();
    }

    private static void CadastrarMateria(DatabaseHelper db)
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine();

        Console.Write("Carga Horaria: ");
        var cargaHoraria = Convert.ToInt32(Console.ReadLine());

        var curso = new Materia { Nome = nome, CargaHoraria = cargaHoraria };
        db.CriarMateria(curso);

        Console.WriteLine("Materia cadastrada com sucesso! Pressione qualquer tecla para continuar.");
        Console.ReadKey();
    }
    private static void ListarMateria(DatabaseHelper db)
    {
        db.ListarMateria();
    }

}
