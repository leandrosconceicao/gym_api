namespace Gym.Domain.Entities;

public class Treino : EstabelecimentoEntity
{
    public ICollection<Exercicio> Exercicios { get; set; } = [];
    public string Description { get; set; } = string.Empty;
    public Guid AlunoId { get; set; }
    public virtual Aluno? Aluno {get; set;}

    
}
