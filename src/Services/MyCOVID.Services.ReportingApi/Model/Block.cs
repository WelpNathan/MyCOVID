using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCOVID.Services.ReportingApi.Model
{
    public enum CampusType
    {
        City, Collegiate 
    }
    
    public class Block
    {
        /// <summary>
        /// Reference's the block's unique name.
        /// </summary>
        /// <example>Adsetts</example>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        /// <summary>
        /// Reference's how many infections are in the block.
        /// </summary>
        /// <example>5</example>
        [Required]
        public int Numbers { get; set; }
    }
}