using System;
using System.Collections.Generic;
using System.Text;

namespace RickDimensao.Domain.Entities
{
    public abstract class BaseEntitie
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
