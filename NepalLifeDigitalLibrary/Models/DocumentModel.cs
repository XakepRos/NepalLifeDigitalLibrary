using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalLibrarySystem.Models
{
    public class DocumentModel
    {
        [Key]
        public string DocURL { get; set; }

        [NotMapped]
        public ApplicationConfigurations GetApplicationConfigurations { get; set; }
    }
}
