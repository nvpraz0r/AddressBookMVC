namespace AddressBookMVC.Services.Interfaces
{
    public interface IImageService
    {
        // return a byte array
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);

        //
        public string ConvertByteArrayToFile(byte[] fileData, string extension);
    }
}
