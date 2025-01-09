namespace Gym.Domain.Entities
{
    public class Estabelecimento : Entity
    {
        public string Name { get; set; } = string.Empty;
        public Guid ProprietarioId { get; set; }
        public Proprietario? Proprietario { get; set; }

        public ICollection<Aluno> Alunos { get; set; } = [];
        public ICollection<Instrutor> Instrutores { get; set; } = [];

        public ICollection<GrupoMuscular> GruposMusculares { get; set; } = [];
    }
}
