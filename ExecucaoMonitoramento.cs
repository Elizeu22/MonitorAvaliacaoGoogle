using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;
using Aspose.Cells.Cloud.SDK.Model;
using System.Net.WebSockets;
using static AvaliacaoGoogle.GravacaoTemporaria;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Serilog;


namespace AvaliacaoGoogle
{
    public class ExecucaoMonitoramento
    {
        public async Task Executar()
        {
            RegistrarLogs registrarLogs = new RegistrarLogs();
          
            try
            {
                ComunicacaoApi comunicacaoApi = new ComunicacaoApi();
                GravacaoPosts posts = new GravacaoPosts();
                GravacaoPostsTemporario gravacaoTemporaria = new GravacaoPostsTemporario();
                ComparadorArquivos comparadorArquivos = new ComparadorArquivos();
                DisparoEmail disparoEmail = new DisparoEmail();

                var retornoApi = await comunicacaoApi.Comunicacao();
                var arquivoAtual = gravacaoTemporaria.GravacaoArquivoTemporario(retornoApi);
                var recebe = comparadorArquivos.CompararArquivos();

                if (recebe == true)

                {
                    posts.GravacaoArquivo(retornoApi);
                    disparoEmail.EmvioEmail();

                    registrarLogs.Registros();
                }
                else
                {
                    registrarLogs.Registros();

                }
            }
            catch (Exception ex) 
            {
                registrarLogs.RegistrosErrosLogs(ex.Message);
            }
        }
    }
}
