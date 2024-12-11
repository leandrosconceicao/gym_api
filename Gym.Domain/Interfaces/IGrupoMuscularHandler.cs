using Gym.Domain.Commands.GrupoMuscular;
using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces
{
    public interface IGrupoMuscularHandler
    {
        GrupoMuscular Create(GrupoMuscularCommand.CreateGrupoMuscular command);
        IApiResponse<GrupoMuscularCommand.ReadGrupoMuscular> Read(GrupoMuscular grupoMuscular);
        IApiResponse<IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular>> Read(IEnumerable<GrupoMuscular> grupoMuscular); 
    }
}
