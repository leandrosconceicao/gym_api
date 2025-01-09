namespace Gym.Domain.Entities
{
    public class Exercicio : EntitySimple
    {
        public string Name { get; set; } = string.Empty;
        public Guid GrupoMuscularId { get; set; }
        public virtual GrupoMuscular? GrupoMuscular {get; set;}
    }
}
