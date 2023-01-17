using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Size : BaseData
    {
        public string Name { get; set; }
        public ICollection<ProductSize>? ProductSizes { get; set; }
    }
}
