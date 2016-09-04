namespace CohesionAndCoupling.Models
{
    using Common;
    using Contracts;

    public class File : IFile
    {
        private string fileName;

        public File(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    0,
                    Constants.MaxFileNameLength,
                    string.Format(Constants.StringMustBeWithMaximalLength, "Filename Extension", Constants.MaxFileNameLength));

                this.fileName = value;
            }
        }

        public string GetExtension()
        {
            int indexOfLastDot = this.GetIndexOfLastDot();
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = this.fileName.Substring(indexOfLastDot + 1);

            return extension;
        }

        public string GetNameWithoutExtension()
        {
            int indexOfLastDot = this.GetIndexOfLastDot();
            if (indexOfLastDot == -1)
            {
                return this.FileName;
            }

            string extension = this.FileName.Substring(0, indexOfLastDot);

            return extension;
        }

        private int GetIndexOfLastDot()
        {
            int indexOfLastDot = this.FileName.LastIndexOf(".");

            return indexOfLastDot;
        }
    }
}
