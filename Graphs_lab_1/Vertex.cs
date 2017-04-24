using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_lab_1
{
    /// <summary>
    /// Вершина будет белой до момента d, серой - между d и f, черной - после f
    /// </summary>
    public enum Colors
    {
        White, Grey, Black
    }

    /// <summary>
    /// Вершина графа
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// Имя вершины
        /// </summary>
        public string name;
        /// <summary>
        /// Список исходящих ребер
        /// </summary>
        public List<Vertex> edges;
        /// <summary>
        /// Время первого попадания в вершину
        /// </summary>
        public int d;
        /// <summary>
        /// Время окончания обработки всех исходящих ребер
        /// </summary>
        public int f;
        /// <summary>
        /// Минимальное время обнаружения среди всех вершин тех, которые могут быть достигнуты
        /// из поддерева с корнем в вершине u при прохождении ровно по одному обратному ребру
        /// </summary>
        public int up;
        /// <summary>
        /// Количество сыновей у корней деревъев поиска в глубину
        /// </summary>
        public int ch;
        /// <summary>
        /// Равен true, если вершина является точкой сочленения
        /// </summary>
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
