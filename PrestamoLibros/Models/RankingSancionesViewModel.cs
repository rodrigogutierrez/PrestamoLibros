using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    public class RankingSancionesViewModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int CantidadSanciones { get; set; }
    }
}