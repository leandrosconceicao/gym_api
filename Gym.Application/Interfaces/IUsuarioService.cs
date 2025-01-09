using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Usuario;

namespace Gym.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Task<ApiResponse<UsuarioCommand.ReadInstrutor>> AddUsuarioAsync(UsuarioCommand.CreateInstrutor dto);
        public Task<ApiResponse<UsuarioCommand.ReadAluno>> AddUsuarioAsync(UsuarioCommand.CreateAluno dto);
        public Task<ApiResponse> DeleteAlunoAsync(Guid id);
        public Task<ApiResponse> DeleteInstrutorAsync(Guid id);
        public Task<ApiResponse<IEnumerable<UsuarioCommand.ReadInstrutor>>> FindAllInstrutores(Guid estabelecimentoId, int offset = 0, int limit = 100);
        public Task<ApiResponse<IEnumerable<UsuarioCommand.ReadAluno>>> FindAllAalunos(Guid estabelecimentoId, int offset = 0, int limit = 100);
        public Task<ApiResponse<UsuarioCommand.ReadInstrutor>> FindInstrutorById(Guid id);
        public Task<ApiResponse<UsuarioCommand.ReadAluno>> FindAlunoById(Guid id);

    }
}
