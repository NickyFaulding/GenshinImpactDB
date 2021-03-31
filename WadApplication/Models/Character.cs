using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WadApplication.Model
{
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Vision { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string WeaponType { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Nation { get; set; }

        public int Rarity { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}