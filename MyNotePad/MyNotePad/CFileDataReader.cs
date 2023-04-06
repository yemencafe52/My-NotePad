namespace MyNotePad
{
    using System.IO;
    using System.Text;
    /// <summary>
    /// read text file data
    /// </summary>
    internal class CFileDataReader
    {
        private readonly IEncodingDetecter _ied;
        private readonly string filePath;
        internal CFileDataReader(string filePath, IEncodingDetecter ied)
        {
            this.filePath = filePath;
            this._ied = ied;
        }

        internal string ReadText()
        {
            string res = Encoding.ASCII.GetString(File.ReadAllBytes(this.filePath));
            return res;
        }
    }
}
