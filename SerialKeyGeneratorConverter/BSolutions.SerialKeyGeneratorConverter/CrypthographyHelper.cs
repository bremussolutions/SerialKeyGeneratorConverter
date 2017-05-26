namespace BSolutions.SerialKeyGeneratorConverter
{
    using System.IO;
    using System.Security.Cryptography;

    internal static class CrypthographyHelper
    {
        internal static string SHA256File(string input)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] bytes = null;
            string output = "";

            if (File.Exists(input))
            {
                using (var reader = new FileStream(input, FileMode.Open, FileAccess.Read))
                {
                    bytes = sha.ComputeHash(reader);
                    foreach (byte b in bytes)
                        output += b.ToString("x2");

                    reader.Close();
                }
            }

            return output;
        }
    }
}
