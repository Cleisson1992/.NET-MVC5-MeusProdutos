﻿using DevIO.Business.Core.Models;
using DevIO.Business.Models.Fornecedores.Validations;
using DevIO.Business.Models.Produtos;
using System.Collections.Generic;

namespace DevIO.Business.Models.Fornecedores
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }


        /* EF Relations */
        public ICollection<Produto> Produtos{ get; set; }

        public bool Validacao()
        {
            var validacao = new FornecedorValidation();
            var resultado = validacao.Validate(this);

            return resultado.IsValid;
        }
    }
}

