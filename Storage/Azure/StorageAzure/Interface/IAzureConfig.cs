namespace StorageAzure.Interface
{
    public interface IAzureConfig
    {
        string StorageConnectionString { get; set; }
        string Reference { get; set; }
    }
}
