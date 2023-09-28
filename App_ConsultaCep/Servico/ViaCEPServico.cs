using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App_ConsultaCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App_ConsultaCep.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP (string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
