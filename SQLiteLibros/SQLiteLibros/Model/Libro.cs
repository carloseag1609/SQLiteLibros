using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteLibros.Model
{
    [Table("Libros")]
    public class Libro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo{ get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public string Editorial { get; set; }
        public string FechaPublicacion { get; set; }
    }
}
