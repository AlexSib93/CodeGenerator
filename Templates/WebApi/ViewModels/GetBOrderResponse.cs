using BuisinessLogicLayer.ViewModels;

namespace TerminalApi.ViewModels
{
    public class GetByOrderResponse
    {
        public List<RotoxHouse> Items { get; set; }
        public Order Order { get; set; }
    }
}
