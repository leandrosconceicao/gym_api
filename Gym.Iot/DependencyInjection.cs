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
            var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

            builder.Services.AddDbContext<ApiContext>(opts =>
                    opts.UseMySQL(connectionString, b => b.MigrationsAssembly("Gym.Repository")));

            builder.Services
                .AddTransient<IEstabelecimentoRepository, EstabelecimentoRepository>()
                .AddTransient<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IGrupoMuscularRepository, GrupoMuscularRepository>()
                .AddTransient<IExercicioRepository, ExercicioRepository>()
                .AddTransient<IEstabelecimentoHandler, EstabelecimentoHandler>()
                .AddTransient<IUsuarioHandler, UsuarioHandler>()
                .AddTransient<IGrupoMuscularHandler, GrupoMuscularHandler>()
                .AddTransient<IExercicioHandler, ExercicioHandler>()
                ;

            builder.Services
                .AddAutoMapper(
                    typeof(EstabelecimentoProfile).Assembly,
                    typeof(UsuarioProfile).Assembly,
                    typeof(GrupoMuscularProfile).Assembly,
                    typeof(ExercicioProfile).Assembly
                );
        }
    }
}
