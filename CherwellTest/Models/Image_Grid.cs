using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CherwellTest.Models
{
    public class Image_Grid : Triangle
    {
        public int Image_width { get; set; }
        public int Image_height { get; set; }
        public int CalculateNumberOfRows => (Image_height / TriangleHeight) +1;
        public int CalculateNumberOfColumns => ((Image_width / TriangleWidth) * 2) +1;
        public Triangle[,] TriangleGrid { get; set; }

        public Triangle[,] CreateTriangleGrid()
        {
            TriangleGrid = new Triangle[CalculateNumberOfColumns , CalculateNumberOfRows];

            for(int i = 1; i < CalculateNumberOfColumns; i++)
            {
                for (int j = 1; j < CalculateNumberOfRows; j++)
                {
                    String RowLetter = IntToRowLetter(j);
                    Tuple<int, int, int, int, int,int> Coordinates = CalculateTriangleCoordinates(i, j);
                    Triangle triangle = new Triangle
                    {               
                        Row = RowLetter,
                        Column = i,
                        Vertex1x = Coordinates.Item1,
                        Vertex1y = Coordinates.Item2,
                        Vertex2x = Coordinates.Item3,
                        Vertex2y = Coordinates.Item4,
                        Vertex3x = Coordinates.Item5,
                        Vertex3y = Coordinates.Item6      
                    };

                    TriangleGrid[i, j] = triangle;
                }
            }          
            return TriangleGrid;
        }

        public Boolean isTriangleColumnOddNumber(int column)
        {
            if (column % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public String IntToRowLetter(int row)
        {
            String RowLetter = string.Empty;
            while(--row >= 0)
            {
                RowLetter = (char)('A' + row % 26) + RowLetter;
                row /= 26;
            }
            return RowLetter;
        }

        public Tuple<int, int, int, int, int, int> CalculateTriangleCoordinates(int column, int row)
        {
            int V1x;
            int V1y;
            int V2x;
            int V2y;
            int V3x;
            int V3y;

            if(isTriangleColumnOddNumber(column))
            {
                V1x = ((column - 1) * TriangleWidth) / 2;
                V1y = row  * TriangleHeight;

                V2x = V1x;
                V2y = V1y - TriangleHeight;

                V3x = V1x + TriangleWidth;
                V3y = V1y;
            }
            else
            {
                V1x = (column / 2) * TriangleWidth;
                V1y = (row - 1) * TriangleHeight;

                V2x = V1x - TriangleWidth;
                V2y = V1y;

                V3x = V1x;
                V3y = V1y + TriangleHeight;
            }

            return Tuple.Create(V1x, V1y, V2x, V2y, V3x, V3y);
        }

    }
}