using BuisinessLogicLayer.ViewModels;

namespace TerminalApi.ViewModels
{
    public class ScanCellViewModel
    {
        public string Barcode { get; set; }
        public List<RotoxHouse> Items { get; set; }
    }
}
