using System.Data.SQLite;
using SistemaAcademico;

public class DatabaseHelper
{
    private string connectionString = "Data Source=sistema_academico.db";
    
    public void CriarBanco()
    {
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        
        // DDL - Criar tabelas
        string sqlAlunos = @"
            CREATE TABLE IF NOT EXISTS Alunos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Email TEXT UNIQUE NOT NULL,
                DataNascimento DATE NOT NULL
            )";
            
        string sqlMaterias = @"
            CREATE TABLE IF NOT EXISTS Materias (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                CargaHoraria INTEGER NOT NULL
            )";
            
        string sqlNotas = @"
            CREATE TABLE IF NOT EXISTS Notas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                AlunoId INTEGER NOT NULL,
                MateriaId INTEGER NOT NULL,
                ValorNota DECIMAL(4,2) NOT NULL,
                DataAvaliacao DATE NOT NULL,
                FOREIGN KEY (AlunoId) REFERENCES Alunos(Id),
                FOREIGN KEY (MateriaId) REFERENCES Materias(Id)
            )";
        
        ExecutarComando(sqlAlunos);
        ExecutarComando(sqlMaterias);
        ExecutarComando(sqlNotas);
    }
    
    private void ExecutarComando(string sql)
    {
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
        
    }
    
    
    public void InserirAluno(Aluno aluno)
    {
        string sql = @"
            INSERT INTO Alunos (Nome, Email, DataNascimento) 
            VALUES (@nome, @email, @dataNascimento)";
            
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);
        
        command.Parameters.AddWithValue("@nome", aluno.Nome);
        command.Parameters.AddWithValue("@email", aluno.Email);
        command.Parameters.AddWithValue("@dataNascimento", aluno.DataNascimento);
        
        command.ExecuteNonQuery();
    }

    internal void ListarAlunos()
    {
        string sql = "select * from alunos";
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);

        using SQLiteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.Write($"Id: {reader.GetInt32(0)} \n| Nome: {reader.GetString(1)}" +
                $"\n| Email: {reader.GetString(2)}\n| Data Nascimento: {reader.GetDateTime(3)}\n\n");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    internal void ExcluirAlunos(int idAluno)
    {
        string sql = "delete from alunos where id = @idAluno";
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);

        command.Parameters.AddWithValue("@idAluno", idAluno);

        if(command.ExecuteNonQuery() == 0)
        {
            Console.WriteLine("Aluno não excluido");
        }
        else
        {
            Console.WriteLine("Aluno excluido");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    internal void CriarMateria(Materia materia)
    {
        string sql = @"
            INSERT INTO Materias (Nome, CargaHoraria) 
            VALUES (@nome, @cargaHoraria)";

        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", materia.Nome);
        command.Parameters.AddWithValue("@cargaHoraria", materia.CargaHoraria);

        command.ExecuteNonQuery();
    }

    internal void ListarMateria()
    {
        string sql = "select * from materias";
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        using var command = new SQLiteCommand(sql, connection);

        using SQLiteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.Write($"Id: {reader.GetInt32(0)} \n| Nome: {reader.GetString(1)}" +
                $"\n| Carga Horaria: {reader.GetInt32(2)}\n\n");
        }
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}