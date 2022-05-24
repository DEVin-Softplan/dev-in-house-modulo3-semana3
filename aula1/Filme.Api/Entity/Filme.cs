using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filme.Entity
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id{get; set;}
        public string Titulo{get; set;}
        public string Diretor{get; set;}
        public DateTime DataLancamento{get; set;}
        
    }
}