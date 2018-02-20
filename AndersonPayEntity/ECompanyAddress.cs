using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AndersonPayEntity
{
    [Table("CompanyAddress")]
    public class ECompanyAddress : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyAddressId { get; set; }

        public string CompanyBranch { get; set; }
        public string Address { get; set; }
        public string SINo { get; set; }
        public string TIN { get; set; }


    }
}
