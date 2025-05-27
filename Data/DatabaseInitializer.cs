using System.Linq;
using Microsoft.Extensions.Logging;

public class DatabaseInitializer
{
    public static void Initialize(AppDbContext context, ILogger<DatabaseInitializer> logger)
    {
        context.Database.EnsureCreated();
        
        if (!context.TimesEsportivos.Any())
        {
            context.TimesEsportivos.AddRange(
                new TimeEsportivo { Nome = "Flamengo", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1895 },
                new TimeEsportivo { Nome = "Palmeiras", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1914 },
                new TimeEsportivo { Nome = "Corinthians", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1910 },
                new TimeEsportivo { Nome = "São Paulo", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1930 },
                new TimeEsportivo { Nome = "Internacional", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1909 },
                new TimeEsportivo { Nome = "Grêmio", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1903 },
                new TimeEsportivo { Nome = "Santos", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1912 },
                new TimeEsportivo { Nome = "Vasco", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1923 },
                new TimeEsportivo { Nome = "Cruzeiro", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1921 },
                new TimeEsportivo { Nome = "Atlético Mineiro", Modalidade = "Futebol", NumeroJogadores = 11, AnoFundacao = 1908 }
            );

            context.SaveChanges();
            logger.LogInformation("Banco de dados populado com sucesso!");
        }
        else
        {
            logger.LogInformation("Banco de dados já possui registros iniciais.");
        }
    }
}