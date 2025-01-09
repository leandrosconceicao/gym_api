namespace Gym.Domain.Entities
{
    public class EstabelecimentoEntity : Entity
    {
        public Guid EstabelecimentoId { get; set; }
        public Estabelecimento? Estabelecimento { get; set; }
    }
}
