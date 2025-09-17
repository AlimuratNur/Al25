using System.Collections.Generic;
using System.Windows;

namespace Al25.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public IEnumerable<ConfirmedCounts> Counts { get; set; }
    }
}
