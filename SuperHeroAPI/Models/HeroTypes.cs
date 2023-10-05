using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Models
{
    public class HeroTypes
    {
        [Key]
        public int Id { get; set; }
        public string  TypeName { get; set; }
    }
}
