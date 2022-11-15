namespace Core.Business.Entites.ResponseModels {
    public class RequestMediaFile {
        public int Id { get; set; }
        public int MediaTypeId { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public string FileName { get; set; }
        public string MediaDetails { get; set; }
        public string BlobLink { get; set; }
        public string LocalPath { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }


    public class MediaFileRequest {
        public string FileName { get; set; }
        public int EntityId { get; set; }
        public int EntityTypeId { get; set; }
        public string Bloblink { get; set; }
        public string LocalPath { get; set; }

    }
}
