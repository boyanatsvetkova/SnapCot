namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICartItemService
    {
        void Add(IEnumerable<ProductCartItem> items);
    }
}
