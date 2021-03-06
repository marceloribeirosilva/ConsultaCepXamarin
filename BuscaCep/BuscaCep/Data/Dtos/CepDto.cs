﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuscaCep.Data.Dtos
{
    [Table("Cep")]
    class CepDto
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Unidade { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }
    }
}
