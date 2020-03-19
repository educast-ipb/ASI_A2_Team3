using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educast.Models
{
    public class Video
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("videoId")]
        public Guid uuid { get; set; }

        public string Duration { get; set; }

        public string Subtitle { get; set; }

        public string Title { get; set; }
    }
}
