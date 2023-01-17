using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Color : BaseData
    {
        public string Name { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set; }
    }
}
