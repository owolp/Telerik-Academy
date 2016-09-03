namespace Refactor
{
    using System;
    using Kitchen;
    using Kitchen.Contracts;

    public class IfStatement
    {
        private const int MinX = -100;
        private const int MaxX = 100;
        private const int MinY = -50;
        private const int MaxY = 50;

        public void CookPotato(IPotato potato)
        {
            var chef = new Chef();

            bool isPeeled = potato.IsPeeled();
            bool isRotten = potato.IsRotten();

            if (potato != null && isPeeled && !isRotten)
            {
                chef.VegetablesToCook.Add(potato);
            }
        }

        public void CheckPointCoordinates(int x, int y)
        {
            var xIsWithinBoundaries = MinX <= x && x <= MaxX;
            var yIsWithinBoundaries = MinY <= y && y <= MaxY;

            if (xIsWithinBoundaries && yIsWithinBoundaries)
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }
    }
}
