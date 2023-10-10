using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projeto_final_bloco_02.Model
{
    public class Produto : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string bula { get; set; } = string.Empty;


        [Column(TypeName = "decimal(5,2)")]
        public decimal preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string foto { get; set; } = string.Empty;

        public virtual Categoria? Categoria { get; set; }
    }
}
