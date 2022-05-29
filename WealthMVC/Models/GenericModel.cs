using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WealthMVC.Models
{
    public class GenericModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id")]
        [Display(Name = "Id")]
        public string Id { get; set; } = "";
    }
}
