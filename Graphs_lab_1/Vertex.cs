using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_lab_1
{
    public enum Colors
    {
        White, Grey, Black
    }
    public class Vertex
    {
        public string name;
        public List<Vertex> edges;
        public int d;
        public int f;
        public int up;
        public int ch;
        public bool r;
        public Colors color;

        public Vertex(string name)
        {
            this.name = name;
            edges = new List<Vertex>();
            d = f = up = ch = 0;
            r = false;
            color = Colors.White;
        }

        public override string ToString()
        {
            string resultString = "";
            foreach(Vertex e in edges)
            {
                resultString += name + " - " + e.name;
                resultString += "\n";
            }
            return resultString;
        }
    }
}
