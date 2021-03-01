using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class UniversoViewModel
    {
        public int Id { get; set; }
        public string NomeUniverso { get; set; }
        public string Descricao { get; set; }
        public int IdRick { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
