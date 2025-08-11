namespace SistemaAcademico;

public class Nota
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public int MateriaId { get; set; }
    public decimal ValorNota { get; set; }
    public DateTime DataAvaliacao { get; set; }
}