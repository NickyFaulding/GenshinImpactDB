using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WadApplication.Model
{
    public class ArtifactSetImage
    {
        public string Image { get; set; }

        public string SetType { get; set; }

        public int ArtifactID { get; set; }
    }
}