using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WadApplication.Model
{
    public class Weapon
    {
        [Key]
        public int WeaponID { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Type { get; set; }

        public int Rarity { get; set; }

        public int Attack { get; set; }

        [Column(TypeName = "varchar(35)")]
        public string SubStat { get; set; }

        public decimal SubStatValue { get; set; }

        [Column(TypeName = "text")]
        public string Passive { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}