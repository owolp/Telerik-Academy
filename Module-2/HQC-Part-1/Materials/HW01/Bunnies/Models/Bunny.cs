namespace CodeFormatting
{
    using System;
    using System.Text;
    using CodeFormatting.Contracts;

    /// <summary>
    /// Bunny class 
    /// </summary>
    [Serializable]
    public class Bunny
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public FurType FurType { get; set; }

        /// <summary>
        /// Introduce method show the main information for each Bunny
        /// </summary>
        /// <param name="writer">IWriter writer</param>
        public void Introduce(IWriter writer)
        {
            writer.WriteLine(this.Name + " - \"I am " + this.Age + " years old!");
            writer.WriteLine(this.Name + " - \"And I am " + this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter());
        }

        /// <summary>
        /// ToString method print the information on the Console
        /// </summary>
        /// <returns>builder.ToString()</returns>
        public override string ToString()
        {
            var builderSize = 200;

            var builder = new StringBuilder(builderSize);

            builder.AppendLine("Bunny name: " + this.Name);
            builder.AppendLine("Bunny age: " + this.Age);
            builder.AppendLine("Bunny fur: " + this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter());

            return builder.ToString();
        }
    }
}