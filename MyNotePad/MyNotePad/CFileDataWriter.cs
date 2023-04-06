namespace MyNotePad
{
    using System.Text;
    using System.IO;
    /// <summary>
    /// file writer class ; just text types
    /// </summary>
    internal class CFileDataWriter
    { 
        private readonly string filePath;
        internal CFileDataWriter(string filePath, EncodingType type)
        {
            this.filePath = filePath;
        }

        internal bool WriteText(byte[] data)
        {
            bool res = false;
            try
            {
                File.WriteAllBytes(this.filePath, data);
                res = true;
            }
            catch { }
            return res;
        }
    }
}
