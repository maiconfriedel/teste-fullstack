namespace TesteFullStackGrupoKyly.Core.Domain
{
    public class Product
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Identificador da referência do produto
        /// </summary>
        public string Reference { get; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Descrição da cor
        /// </summary>
        public string ColorDescription { get; }

        /// <summary>
        /// Tamanho (sequência)
        /// </summary>
        public int SizeSequence { get; }

        /// <summary>
        /// Descrição do tamanho
        /// </summary>
        public string SizeDescription { get; }

        /// <summary>
        /// Construtor para instância existente
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <param name="reference">Identificador da referência do produto</param>
        /// <param name="description">Descrição do produto</param>
        /// <param name="colorDescription">Descrição da cor</param>
        /// <param name="sizeSequence">Tamanho (sequência)</param>
        /// <param name="sizeDescription">Descrição do tamanho</param>
        public Product(string id, string reference, string description, string colorDescription, int sizeSequence, string sizeDescription)
        {
            Id = id;
            Reference = reference;
            Description = description;
            ColorDescription = colorDescription;
            SizeSequence = sizeSequence;
            SizeDescription = sizeDescription;
        }

        /// <summary>
        /// Construtor para nova instância
        /// </summary>
        /// <param name="reference">Identificador da referência do produto</param>
        /// <param name="description">Descrição do produto</param>
        /// <param name="colorDescription">Descrição da cor</param>
        /// <param name="sizeSequence">Tamanho (sequência)</param>
        /// <param name="sizeDescription">Descrição do tamanho</param>
        public Product(string reference, string description, string colorDescription, int sizeSequence, string sizeDescription)
        {
            Reference = reference;
            Description = description;
            ColorDescription = colorDescription;
            SizeSequence = sizeSequence;
            SizeDescription = sizeDescription;
        }
    }
}