using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WadApplication.Model
{
    public class Artifact
    {
        [Key]
        public int ArtifactID { get; set; } 

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string SetName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }

    }
}