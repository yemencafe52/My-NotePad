namespace MyNotePad
{
    internal enum EncodingType : byte
    {
        ASCII = 1,
        UNICODE,
        UTF8,
        UTF_16,
        UTF_32
    }
     class EncodingDetecter : IEncodingDetecter
    {
        private readonly string filePath;

        /// <summary>
        /// class constrator
        /// </summary>
        /// <param name="filePath"></param>
        internal EncodingDetecter(string filePath)
        {
            this.filePath = filePath;
        }


        /// <summary>
        /// Get File Encoding 
        /// </summary>
        /// <returns>encoding type</returns>
        EncodingType IEncodingDetecter.GetEncoding()
        {
            EncodingType res = EncodingType.ASCII;
            return res;
        }
    }
}
