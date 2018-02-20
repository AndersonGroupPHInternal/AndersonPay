using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AndersonPayEntity
{
    [Table("TaxType")]
    public class ETaxType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxTypeId { get; set; }

        public string TaxTypes { get; set; }
    }
}
