using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell : ICell
    {
        public Point cellPosition;

        private bool state;

        public Cell(Point origin, bool initialState)
        {
            cellPosition = origin;
            state = initialState;
        }

        public bool GetState() { return state; }

        public void UpdateState(Cell[] neighbours)
        {
            state = CheckForState(neighbours);
        }

        public bool CheckForState(Cell[] neighbours)
        {
            int amountOfNeighbours = IsDead(neighbours);

            if (amountOfNeighbours < 2)
                return false;

            else if (amountOfNeighbours == 1)
            {
                if (state)
                    return true;
                else return false;
            }

            else if (amountOfNeighbours == 3)
                return true;

            else if (amountOfNeighbours > 3)
                return false;

            else
                return false;
        }

        private int IsDead(Cell[] neighbours)
        {
            int sum = 0;

            foreach (Cell cell in neighbours)
            {
                if (cell is not null)
                {
                    if (cell.state != null)
                        if (cell.state)
                            sum++;
                }
            }

            return sum;
        }
    }
}
