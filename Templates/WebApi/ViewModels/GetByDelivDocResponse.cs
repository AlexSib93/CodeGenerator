using BuisinessLogicLayer.ViewModels;

namespace TerminalApi.ViewModels
{
    public class GetByDelivDocResponse
    {
        public List<RotoxHouse> Items { get; set; }
        public DelivDoc DelivDoc { get; set; }
    }
}
