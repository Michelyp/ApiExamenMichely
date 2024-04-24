using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiExamenMichely.Models
{
    [Table("PERSONAJESSERIES")]
    public class PersonajeSerie
    {
        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersonaje { set; get; }
        [Column("NOMBRE")]
        public string Nombre { set; get; }

        [Column("IMAGEN")]
        public string Imagen { set; get; }

        [Column("SERIE")]
        public string Serie{ set; get; }

    }
}
