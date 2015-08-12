using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abjuration.Models
{
    public class BeerRecipeViewModel : BaseViewModel
    {
        public BeerVersion BeerVersion { get; set; }
        public List<decimal> BeerVersions { get; set; }
        public string FormattedVersion { get; set; }
    }
}