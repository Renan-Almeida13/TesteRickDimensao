using System;
using System.Net;

namespace Core
{
    public class LocalizacaoRickResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Result { get; set; }

        public LocalizacaoRickResult(HttpStatusCode statusCode, bool sucesso)
        {
            StatusCode = statusCode;
            Sucesso = sucesso;
        }

        public LocalizacaoRickResult(HttpStatusCode statusCode, bool sucesso, string mensagem)
        {
            StatusCode = statusCode;
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public LocalizacaoRickResult(HttpStatusCode statusCode, bool sucesso, object result)
        {
            StatusCode = statusCode;
            Sucesso = sucesso;
            Result = result;
        }

        public LocalizacaoRickResult(HttpStatusCode statusCode, bool sucesso, string mensagem, object result)
        {
            StatusCode = statusCode;
            Sucesso = sucesso;
            Mensagem = mensagem;
            Result = result;
        }
    }
}

