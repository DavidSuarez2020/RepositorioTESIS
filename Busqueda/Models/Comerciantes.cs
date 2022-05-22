using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Busqueda.Models
{
    public class Comerciantes
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Cedula { get; set; }
        public int Capacitacion { get; set; }
        public string Institucion { get; set; }
    }

    public class ComerciantesDBContext : DbContext
    {
        public DbSet<Comerciantes> Comerciantes { get; set; }
    }
}
