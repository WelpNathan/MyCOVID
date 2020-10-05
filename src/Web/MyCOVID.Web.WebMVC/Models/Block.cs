using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyCOVID.Web.WebMVC.Models
{
    public class Block
    {
        /// <summary>
        /// Reference's the block's unique name.
        /// </summary>
        /// <example>Adsetts</example>
        [Required]
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Reference's how many infections are in the block.
        /// </summary>
        /// <example>5</example>
        [Required]
        [JsonPropertyName("numbers")]
        public int Numbers { get; set; }
    }
}