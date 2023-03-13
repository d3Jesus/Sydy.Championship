using System.ComponentModel.DataAnnotations;

namespace Sydy.Championship.Application.ViewModels.Championship
{
    public class AddChampionshipViewModel
    {
        [Required(ErrorMessage = "Championship name is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
