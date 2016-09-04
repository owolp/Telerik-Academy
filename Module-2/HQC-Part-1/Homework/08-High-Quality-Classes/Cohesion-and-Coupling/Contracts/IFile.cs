namespace CohesionAndCoupling.Contracts
{
    public interface IFile
    {
        string FileName { get; set; }

        string GetExtension();

        string GetNameWithoutExtension();
    }
}
