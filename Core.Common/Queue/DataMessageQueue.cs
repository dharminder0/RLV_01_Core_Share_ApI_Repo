namespace Core.Common.Queue {
    public class DataMessageQueue {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public object Data { get; set; }
    }
}
