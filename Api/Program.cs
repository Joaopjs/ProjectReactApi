using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Modificado para poder executar o migration 
            var host = CreateHostBuilder(args).Build();

            //cria um scopo para poder usar certos metodos da classe Services()
            using var scope = host.Services.CreateScope();

            //fornece todos os metodos de serviço que estarião também usado na classe StartUp()
            var services = scope.ServiceProvider;

            try
            {
                //Pega o DataContext Declarado na Classe StartUp()
                var context = services.GetRequiredService<DataContext>();
                //Executa o Migration 
                _ = context.Database.MigrateAsync();

                //Executar o Seed para preencher o banco de dados
                _ = Seed.SeedData(context);
            }
            catch (Exception ex)
            {
                //tratamento de erros
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An Error Occured during migration");
            }

            //Inicializa a execução da inteface 
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
