using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RickDimensao.Domain.Entities
{
    public class Rick : BaseEntitie
    {
        public string NomeRick { get; set; }
        public string NomeMorty { get; set; }
        public string Origem { get; set; }
        public int? IdUniverso { get; set; }
    }
}
