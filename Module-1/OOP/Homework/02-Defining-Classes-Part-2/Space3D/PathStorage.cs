namespace Space3D
{
    using System;
    using IO = System.IO;

    public class PathStorage
    {
        public static void Save(Path path, string fileName = "path")
        {
            string filePath = IO.Path.Combine("../../../PathStorage", string.Format("{0}", fileName.Trim()));

            if (IO.File.Exists(fileName))
            {
                IO.File.Delete(fileName);
            }

            using (var file = new IO.StreamWriter(filePath))
            {
                foreach (var point in path)
                {
                    file.WriteLine(point.ToString());
                }
            }
        }

        public static void Load(Path path, string fileName = "path")
        {
            string filePath = IO.Path.Combine("../../../PathStorage", string.Format("{0}", fileName.Trim()));

            try
            {
                using (var file = new IO.StreamReader(filePath))
                {
                    string line = file.ReadLine();

                    while (line != null)
                    {
                        line = line.Replace(",", string.Empty);
                        line = line.Remove(0, 1);
                        line = line.Remove(line.Length - 1, 1);
                        var lines = line.Split(' ');
                        double coordinateX = double.Parse(lines[0]);
                        double coordinateY = double.Parse(lines[1]);
                        double coordinateZ = double.Parse(lines[2]);

                        Point3D point = new Point3D(coordinateX, coordinateY, coordinateZ);
                        path.AddPoint(point);

                        line = file.ReadLine();
                    }
                }
            }
            catch
            {
                throw new ArgumentException("File can not be found.");
            }
        }
    }
}
