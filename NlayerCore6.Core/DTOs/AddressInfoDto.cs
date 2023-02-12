using System.ComponentModel.DataAnnotations;

namespace NLayerCore6.Core.DTOs
{
    public class AddressInfoDto : BaseDto
    {
        [Required]
        [MaxLength(64, ErrorMessage = "This field must be a maximum of 64 characters.")]
        public string CityName { get; set; }
        [Required]
        [MaxLength(2, ErrorMessage = "This field must be a maximum of 2 characters.")]
        public string CityCode { get; set; }
        [Required]
        [MaxLength(64, ErrorMessage = "This field must be a maximum of 64 characters.")]
        public string DistrictName { get; set; }
        [Required]
        [MaxLength(5, ErrorMessage = "This field must be a maximum of 5 characters.")]
        public string ZipCode { get; set; }
    }
}
