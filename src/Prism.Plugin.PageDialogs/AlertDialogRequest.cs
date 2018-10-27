namespace Prism.Services
{
    public struct AlertDialogRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string AcceptButton { get; set; }
        public string CancelButton { get; set; }
        public string Style { get; set; }
        public bool? Animated { get; set; }
    }
}
