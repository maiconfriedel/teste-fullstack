using System;
using System.Collections.Generic;
using System.Text;

namespace TesteFullStackGrupoKyly.Infrastructure.EntityFramework.Models
{
    public class RelevantReference
    {
        public int Id { get; set; }

        public string Reference { get; set; }

        public int Priority { get; set; }
    }
}