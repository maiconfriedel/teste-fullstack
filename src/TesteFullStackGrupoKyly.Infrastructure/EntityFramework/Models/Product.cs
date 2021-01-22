using System;
using System.Collections.Generic;
using System.Text;

namespace TesteFullStackGrupoKyly.Infrastructure.EntityFramework.Models
{
    internal class Product
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador da referência do produto
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Cor
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Descrição da cor
        /// </summary>
        public string ColorDescription { get; set; }

        /// <summary>
        /// Tamanho (sequência)
        /// </summary>
        public int SizeSequence { get; set; }

        /// <summary>
        /// Descrição do tamanho
        /// </summary>
        public string SizeDescription { get; set; }
    }
}