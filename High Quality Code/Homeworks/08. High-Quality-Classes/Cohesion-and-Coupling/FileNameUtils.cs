namespace CohesionAndCoupling
{
    static class FileNameUtils
    {
        public static string GetFileExtension(string fileName)
        {
            string extension = "Unknown";

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot != -1)
            {
                extension = fileName.Substring(indexOfLastDot + 1);
            }

            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
