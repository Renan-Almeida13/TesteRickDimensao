using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class RickViewModel
    {
        public int Id { get; set; }
        public string NomeRick { get; set; }
        public string NomeMorty { get; set; }
        public string Origem { get; set; }
        public string Descricao { get; set; }
        public int? IdUniverso { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
