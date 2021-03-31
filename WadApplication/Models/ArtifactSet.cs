using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WadApplication.Model
{
    public class ArtifactSet
    {
        [Key]
        [Column(TypeName = "varchar(45)")]
        public string SetName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string TwoPieceBonus { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string FourPieceBonus { get; set; }

        [Required]
        public int MinRarity { get; set; }
        [Required]
        public int MaxRarity { get; set; }
    }
}