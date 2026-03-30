using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Serilog;
using DotNetEnv;

namespace AvaliacaoGoogle
{
    public class ComparadorArquivos
    {
      
        public bool CompararArquivos()
        {
            RegistrarLogs registrarLogs = new RegistrarLogs();


            try
            {
                Env.Load(Path.Combine("../../../.env.development"));

                var arquivoBase = DotNetEnv.Env.GetString("ARQUIVO-BASE");
                var arquivoTemporario = DotNetEnv.Env.GetString("ARQUIVO-TEMPORARIO");

                string file1 = arquivoBase;
                string file2 = arquivoTemporario;
                int cont = 0;
                var json1 = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(File.ReadAllText(file1)));

                var json2 = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(File.ReadAllText(file2)));


                foreach (var comentario in json2)
                {
                    if (!json1.Contains(comentario))
                    {
                        cont += 1;
                        Console.WriteLine(comentario);
                    }
                }

                if (cont > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                registrarLogs.RegistrosErrosLogs(ex.Message);
                return false;

            }
        }



        }
    }

