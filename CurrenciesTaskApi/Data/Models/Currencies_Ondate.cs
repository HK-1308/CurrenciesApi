using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrenciesTaskApi.Data.Models
{
    public class Currencies_Ondate
    {
        [Key]
        public string GUID { get; set; }

        public string CODE { get; set; }

        [Column("CURVAL")]
        public decimal Cur_OfficialRate { get; set; }

        [Column("CURDATE")]
        public DateTime Date { get; set; }
    }
}
