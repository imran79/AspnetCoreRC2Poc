using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreRC2Poc.Models.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
