namespace Gym.Domain.Entities
{
    public class GrupoMuscular : EstabelecimentoEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Exercicio> Exercicios { get; set; } = [];
    }
}
