using CherwellTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CherwellTest.Controllers
{
    public class ImageGridController : ApiController
    {
        Image_Grid imageGrid = new Image_Grid { Image_height = 60, Image_width = 60 };
        Triangle[,] grid;
  
        public Triangle GetTriangleCoordinates(char rowLetter, int column)
        {
            CreateGrid();
            int rowNumberConvertedFromLetter = char.ToUpper(rowLetter) - 64;
            Triangle triangle = grid[column, rowNumberConvertedFromLetter];
            return triangle;
        }

        public Triangle GetTriangleRowColumn(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            CreateGrid();    
 
            for (int column = 1; column < imageGrid.CalculateNumberOfColumns; column++)
            {
                for(int row = 1; row < imageGrid.CalculateNumberOfRows; row++)
                {
                    if (grid[column, row].Vertex1x.Equals(v1x) &&
                        grid[column, row].Vertex1y.Equals(v1y) &&
                        grid[column, row].Vertex2x.Equals(v2x) &&
                        grid[column, row].Vertex2y.Equals(v2y) &&
                        grid[column, row].Vertex3x.Equals(v3x) &&
                        grid[column, row].Vertex3y.Equals(v3y)
                        )
                        return grid[column, row];
                }
            }
            return null;
        }

        public Triangle[,] CreateGrid()
        {
            imageGrid.CreateTriangleGrid();
            grid = imageGrid.TriangleGrid;
            return grid;
        }
    }
}
