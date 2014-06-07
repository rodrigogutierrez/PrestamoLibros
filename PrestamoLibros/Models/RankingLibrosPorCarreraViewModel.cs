using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    public class RankingLibrosPorCarreraViewModel
    {
        public int Id { get; set; }
        public string Carrera { get; set; }
        public int CantidadLibros { get; set; }
    }
}