using Gym.Application.Services;
using Gym.Domain.Interfaces.Services;
using Gym.Domain.Interfaces.Repositories;
using Gym.Infra.Data.Context;
using Gym.Repository;
using Gym.Repository.RepositoryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gym.Application.Interfaces.Services;
using Gym.Application.Mappings;

namespace Gym.Iot
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("SqlConnection") ?? throw new NullReferenceException("String de conexão inválida");

            services.AddDbContext<ApplicationDbContext>(opts => opts.UseMySQL(
                connection, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)    
            ));

            services
                .AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IGrupoMuscularRepository, GrupoMuscularRepository>()
                .AddScoped<IExercicioRepository, ExercicioRepository>()
                .AddScoped<ITreinoRepository, TreinoRepository>()
                .AddScoped<IProprietarioRepository, ProprietarioRepository>()
                .AddScoped<IEstabelecimentoService, EstabelecimentoService>()
                .AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IGrupoMuscularService, GrupoMuscularService>()
                .AddScoped<IExercicioService, ExercicioService>()
                .AddScoped<ITreinoService, TreinoService>()
                .AddScoped<IProprietarioService, ProprietarioService>()
                ;

            services.AddAutoMapper(typeof(DomainDtoMappings).Assembly);

            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
