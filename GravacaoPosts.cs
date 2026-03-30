using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoGoogle
{
    public class GravacaoPosts
    {
        public string GravacaoArquivo(string file)
        {
            RegistrarLogs registrarLogs = new RegistrarLogs();
            try
            {
                StreamWriter _writer = new StreamWriter("Posts.json");
                _writer.WriteLine(file);
                _writer.Close();
            }
            catch (Exception e)
            {
                registrarLogs.RegistrosErrosLogs(e.Message);
            }
            return file;
        }
    }
}
