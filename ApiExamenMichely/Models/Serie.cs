using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiExamenMichely.Models
{
    [Table("SERIES")]

    public class Serie
    {
        [Key]
        [Column("IDSERIE")]
        public int IdSerie { set; get; }
        [Column("SERIE")]
        public string Nombre { set; get; }

        [Column("IMAGEN")]
        public string Imagen { set; get; }

        [Column("PUNTUACION")]
        public double Puntuacion { set; get; }
        [Column("AÑO")]
        public int Anyo { set; get; }

    }
}
