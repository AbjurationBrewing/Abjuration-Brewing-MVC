using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abjuration.Models
{
    public class HomeViewModel : BaseViewModel
    {
        public bool UpdateUntappd { get; set; }

        public string UntappdHtml { get; set; }

        public List<BeerVersion> MainSliderBeers { get; set; }
    }
}