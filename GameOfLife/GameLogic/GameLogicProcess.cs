using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class GameLogicProcess : IProcess
    {
        private int axisXLimit;
        private int axisYLimit;
        public Cell[,] cells;

        public GameLogicProcess(int AxisXLimit, int AxisYLimit)
        {
            axisXLimit = AxisXLimit;
            axisYLimit = AxisYLimit;
            cells = new Cell[axisYLimit, axisXLimit];
        }

        public void Start()
        {
            CreateCells();
        }

        public void Update()
        {
            foreach (var cell in cells)
            {
                var neighbours = new Cell[8];

                for (int i = -1; i < 2;)
                {
                    CellCheck(cell, 1, i, ref neighbours, 1);
                    i++;
                }
                for (int i = -1; i < 1;)
                {
                    CellCheck(cell, 0, i, ref neighbours, 4);
                    i++;
                }
                for (int i = -1; i < 2;)
                {
                    CellCheck(cell, -1, i, ref neighbours, 6);
                    i++;
                }

                cell.UpdateState(neighbours);
            }
        }

        public void Draw()
        {
            for (int row = 0; row < axisYLimit;)
            {
                string rowDisplay = "";
                for (int col = 0; col < axisXLimit;)
                {
                    if (cells[row, col].GetState())
                    {
                        rowDisplay += "*";
                    }
                    else
                        rowDisplay += " ";

                    col++;
                }
                row++;
                System.Console.WriteLine(rowDisplay);
            }
        }

        private void CreateCells()
        {
            for (int row = 0; row < axisYLimit;)
            {
                for (int col = 0; col < axisXLimit;)
                {
                    cells[row, col] = new Cell(new Point(row, col), new Random().Next(100) < 50);
                    col++;
                }
                row++;
            }
        }

        private bool Check2DArrayLength(int y, int x)
        {
            if (cells.GetLength(0) <= y || cells.GetLength(1) <= x || 0 > x || 0 > y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CellCheck(Cell cell, int yAdder, int xAdder, ref Cell[] neighbours, int id)
        {
            int y = cell.cellPosition.Y + yAdder;
            int x = cell.cellPosition.X + xAdder;
            if (Check2DArrayLength(y, x))
                neighbours[xAdder + id] = (Cell)cells.GetValue(y, x);
        }
    }
}
