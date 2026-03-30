using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoGoogle
{
    public class RegistrarLogs
    {
            public void Registros()
            {
                Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File(
                    "logs/logs.txt",
                     rollingInterval: RollingInterval.Day,
                     outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                  .CreateLogger();

                Log.Information($"processado com sucesso: " + DateTime.Now);

                Log.CloseAndFlush();
            }

            public void RegistrosErrosLogs(string erroLog)
            {
                Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File(
                    "logs/logsErros.txt",
                     rollingInterval: RollingInterval.Day,
                     outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
                  .CreateLogger();

                Log.Fatal(erroLog,$"processado com erro: " + DateTime.Now);

                Log.CloseAndFlush();
            }
        }
}
