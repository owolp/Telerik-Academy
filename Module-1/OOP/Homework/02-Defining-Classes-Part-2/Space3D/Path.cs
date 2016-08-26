namespace Space3D
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Path
    {
        // fields
        private List<Point3D> path = new List<Point3D>();

        // constructor
        public Path()
        {
            this.path = new List<Point3D>();
        }

        // properties
        public Point3D this[int index]
        {
            get
            {
                return this.path[index];
            }
        }

        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }

        public void RemovePoint(int index)
        {
            if (index < 0 || index > this.path.Count)
            {
                throw new ArgumentException("Index is out of range!");
            }

            this.path.RemoveAt(index);
        }

        public void ClearPath()
        {
            this.path.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return this.path.GetEnumerator();
        }
    }
}
