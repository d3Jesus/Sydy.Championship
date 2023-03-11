using System.ComponentModel.DataAnnotations;

namespace Sydy.Championship.Application.ViewModels.Teams
{
    public class AddTeamViewModel
    {
        [Required(ErrorMessage = "Teams name is required")]
        [StringLength(50, ErrorMessage = "Teams name should be greater than {1} and lower than {0}", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
