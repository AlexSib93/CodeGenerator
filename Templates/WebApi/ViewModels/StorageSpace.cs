namespace TerminalApi.ViewModels
{
    public class StorageSpace
    {
        public int IdStorageSpace { get; set; }
        public string Row { get; set; }
        public string Cell { get; set; }
        public string Barcode { get; set; }
        public string StoreName { get; set; }
        public StorageSpace Parent { get; set; }
    }
}
