using EscolaAPI.Application.Services;
using EscolaAPI.Domain.Interfaces;
using EscolaAPI.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EscolaAPI.Configurations
{
    public static class RepositoryConfig
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<IProfessorRepository, ProfessorRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IDisciplinaRepository, DisciplinaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<AlunoService>();
            services.AddTransient<ProfessorService>();
            services.AddTransient<TurmaService>();
            services.AddTransient<DisciplinaService>();
            services.AddTransient<UsuarioService>();

        }
    }
}
