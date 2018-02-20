using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AndersonPayEntity
{
    [Table("CurrencyCode")]
    public class ECurrencyCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyId { get; set; }

        public string CurrencyCodes { get; set; }


    }
}
