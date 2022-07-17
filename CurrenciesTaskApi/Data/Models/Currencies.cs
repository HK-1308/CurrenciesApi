using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrenciesTaskApi.Data.Models
{
    public class Currencies
    {
        [Key]
        [Column("ID")]
        public int Cur_ID { get; set; }

        [Required]
        [Column("Code")]
        public string Cur_Code { get; set; }

        [Required]
        [Column("Abbreviation")]
        public string Cur_Abbreviation { get; set; }

        [Required]
        [Column("Name")]
        public string Cur_Name { get; set; }

        [Required]
        [Column("QuotName")]
        public string Cur_QuotName { get; set; }

    }
}
