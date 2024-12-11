namespace Gym.Domain.Entities;

public class Treino : Base
{
    public required Guid Id { get; set; } = Guid.NewGuid();
    public ICollection<Exercicio> Exercicios { get; set; } = [];
    public required string Description { get; set; }
    public Guid AlunoId { get; set; }

    
}
