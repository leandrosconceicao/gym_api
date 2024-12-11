using AutoMapper;
using Gym.Domain.Commands.GrupoMuscular;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;

namespace Gym.Domain.Handlers
{
    public class GrupoMuscularHandler(IMapper mapper) : IGrupoMuscularHandler
    {
        public GrupoMuscular Create(GrupoMuscularCommand.CreateGrupoMuscular command)
        {
            return mapper.Map<GrupoMuscular>(command);
        }

        public IApiResponse<GrupoMuscularCommand.ReadGrupoMuscular> Read(GrupoMuscular grupoMuscular)
        {
            return new SuccessResponse<GrupoMuscularCommand.ReadGrupoMuscular>(MapData(grupoMuscular));
        }

        public IApiResponse<IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular>> Read(IEnumerable<GrupoMuscular> grupoMuscular)
        {
            return new SuccessResponse<IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular>>(
                grupoMuscular.Select(grupo => MapData(grupo))
            );
        }

        private GrupoMuscularCommand.ReadGrupoMuscular MapData(GrupoMuscular grupo)
        {
            return mapper.Map<GrupoMuscularCommand.ReadGrupoMuscular>(grupo);
        }
    }
}
