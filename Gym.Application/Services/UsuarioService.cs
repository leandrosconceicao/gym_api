using AutoMapper;
using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Usuario;
using Gym.Application.Interfaces.Services;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;
using Gym.Domain.Utils;

namespace Gym.Application.Services
{
    public class UsuarioService(IMapper mapper, IUsuarioRepository repository) : IUsuarioService
    {
        public async Task<ApiResponse<UsuarioCommand.ReadInstrutor>> AddUsuarioAsync(UsuarioCommand.CreateInstrutor dto)
        {
            var newInstrutor = await repository.AddUsuario(mapper.Map<Instrutor>(dto));

            return new ApiResponse<UsuarioCommand.ReadInstrutor>(MapInstrutorData(newInstrutor));
            
        }

        public async Task<ApiResponse<UsuarioCommand.ReadAluno>> AddUsuarioAsync(UsuarioCommand.CreateAluno dto)
        {
            var newAluno = await repository.AddUsuario(mapper.Map<Aluno>(dto));

            return new ApiResponse<UsuarioCommand.ReadAluno>(MapAlunoData(newAluno));
        }

        public async Task<ApiResponse> DeleteAlunoAsync(Guid id)
        {
            var aluno = await AlunoById(id);

            await repository.DeleteAluno(aluno);

            return new ApiResponse();
        }

        public async Task<ApiResponse> DeleteInstrutorAsync(Guid id)
        {
            var instrutor = await InstrutorById(id);

            await repository.DeleteInstrutor(instrutor);

            return new ApiResponse();
        }

        public async Task<ApiResponse<IEnumerable<UsuarioCommand.ReadAluno>>> FindAllAalunos(Guid estabelecimentoId, int offset = 0, int limit = 100)
        {
            var alunos = await repository.FindAllAalunos(estabelecimentoId, offset, limit);

            return new ApiResponse<IEnumerable<UsuarioCommand.ReadAluno>>(mapper.Map<IEnumerable<UsuarioCommand.ReadAluno>>(alunos));
        }

        public async Task<ApiResponse<IEnumerable<UsuarioCommand.ReadInstrutor>>> FindAllInstrutores(Guid estabelecimentoId, int offset = 0, int limit = 100)
        {
            var instrutores = await repository.FindAllInstrutores(estabelecimentoId, offset, limit);

            return new ApiResponse<IEnumerable<UsuarioCommand.ReadInstrutor>>(mapper.Map<IEnumerable<UsuarioCommand.ReadInstrutor>>(instrutores));
        }

        public async Task<ApiResponse<UsuarioCommand.ReadAluno>> FindAlunoById(Guid id)
        {
            var aluno = await AlunoById(id);

            return new ApiResponse<UsuarioCommand.ReadAluno>(MapAlunoData(aluno));
        }

        public async Task<ApiResponse<UsuarioCommand.ReadInstrutor>> FindInstrutorById(Guid id)
        {
            var instrutor = await InstrutorById(id);

            return new ApiResponse<UsuarioCommand.ReadInstrutor>(MapInstrutorData(instrutor));
        }

        private async Task<Aluno> AlunoById(Guid id) {
            return await repository.FindAlunoById(id) ?? throw new NotFoundError("Aluno não localizado");
        }

        private async Task<Instrutor> InstrutorById(Guid id) {
            return await repository.FindInstrutorById(id) ?? throw new NotFoundError("Instrutor não localizado");
        }

        private UsuarioCommand.ReadAluno MapAlunoData(Aluno aluno) => mapper.Map<UsuarioCommand.ReadAluno>(aluno);
        private UsuarioCommand.ReadInstrutor MapInstrutorData(Instrutor instrutor) => mapper.Map<UsuarioCommand.ReadInstrutor>(instrutor);
    }
}
