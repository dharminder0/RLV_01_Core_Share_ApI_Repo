using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "MediaFile")]
    public class MediaFile {
        public MediaFile() { }
        [Key(AutoNumber = true)]
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
}
