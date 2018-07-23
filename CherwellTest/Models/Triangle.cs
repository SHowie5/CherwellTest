using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CherwellTest.Models
{
    public class Triangle
    {
        public int TriangleHeight { get; } = 10;
        public int TriangleWidth { get; } = 10;
        public String Row { get; set; }
        public int Column { get; set; }
        public int Vertex1x { get; set; }
        public int Vertex1y { get; set; }
        public int Vertex2x { get; set; }
        public int Vertex2y { get; set; }
        public int Vertex3x { get; set; }
        public int Vertex3y { get; set; }
    }
}