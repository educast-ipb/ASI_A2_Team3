using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educast.Models
{
    public class Branding
    {
        public Guid id { get; set; }

        public string Path { get; set; }

        public string CreatorBranding { get; set; }

        public float Duration { get; set; }
        public string etc { get; set; }
    }
}
