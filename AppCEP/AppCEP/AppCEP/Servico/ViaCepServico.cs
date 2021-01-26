using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace AppCEP.Servico
{
    public class ViaCepServico
    {
        private static string endercoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEndercoViaCep(string cep)
        {
            //torna a url do jeito certa pra se pesquisar com o cep
            string NovoEndercoURL = string.Format(endercoURL, cep);

            //faz a pesquisa na internet
            WebClient wc = new WebClient();
            string contudo =  wc.DownloadString(NovoEndercoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(contudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
