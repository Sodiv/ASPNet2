using WebStore.Domain.ViewModel.Cart;

namespace WebStore.Interfaces
{
    public interface ICartStore
    {
        Cart Cart { get; set; }
    }
}
