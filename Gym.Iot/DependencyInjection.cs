using Gym.Domain.Handlers;
using Gym.Domain.Interfaces;
using Gym.Domain.Profiles;
using Gym.Repository;
using Gym.Repository.RepositoryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gym.Iot
{
    public class DependencyInjection
    {
        public static void BuildInfraestructure(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("SqlConnection") ?? throw new NullReferenceException("String de conexão inválida");

            builder.Services.AddDbContext<ApiContext>(opts =>
                    opts.UseMySQL(connectionString, b => b.MigrationsAssembly("Gym.Repository")));

            builder.Services
                .AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IGrupoMuscularRepository, GrupoMuscularRepository>()
                .AddScoped<IExercicioRepository, ExercicioRepository>()
                .AddScoped<ITreinoRepository, TreinoRepository>()
                .AddScoped<IEstabelecimentoHandler, EstabelecimentoHandler>()
                .AddScoped<IUsuarioHandler, UsuarioHandler>()
                .AddScoped<IGrupoMuscularHandler, GrupoMuscularHandler>()
                .AddScoped<IExercicioHandler, ExercicioHandler>()
                .AddScoped<ITreinoHandler, TreinoHandler>()
                ;

            builder.Services
                .AddAutoMapper(
                    typeof(EstabelecimentoProfile).Assembly,
                    typeof(UsuarioProfile).Assembly,
                    typeof(GrupoMuscularProfile).Assembly,
                    typeof(ExercicioProfile).Assembly,
                    typeof(TreinoProfile).Assembly
                );
        }
    }
}
