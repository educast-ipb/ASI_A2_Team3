using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Educast.Models
{
    public class Canal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("canalId")]
        public Guid id { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string Name { get; set; }
    }
}
