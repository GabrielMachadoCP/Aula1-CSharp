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
    
}