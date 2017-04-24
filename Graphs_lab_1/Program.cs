using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_lab_1
{
    class Program
    {

        List<Vertex> graph;
        static int time = 0;
        void Inizialiser()
        {
            Console.WriteLine("Введите количество вершин графа: ");
            int countOfVertixes = Int32.Parse(Console.ReadLine());
            graph = new List<Vertex>(countOfVertixes);

            while(graph.Count < countOfVertixes)
            {
                Console.Write("Введите первую вершину ребра : ");
                string vertexName_1 = Console.ReadLine().ToUpper().Trim();
                

                while(vertexName_1 == "")
                {
                    Console.WriteLine("Не было введено имя вершины. Попробуйте еще раз");
                    Console.Write("Введите первую вершину ребра : ");
                    vertexName_1 = Console.ReadLine().ToUpper().Trim();
                }
                

                Console.Write("Введите вторую вершину ребра : ");
                string vertexName_2 = Console.ReadLine().ToUpper().Trim();

                while (vertexName_1 == "")
                {
                    Console.WriteLine("Не было введено имя вершины. Попробуйте еще раз");
                    Console.Write("Введите вторую вершину ребра : ");
                    vertexName_2 = Console.ReadLine().ToUpper().Trim();
                }

                


                if (graph.FirstOrDefault(v => v.name == vertexName_1) != null)
                {
                    Vertex vertex1 = graph.FirstOrDefault(v => v.name == vertexName_1);

                    if (graph.FirstOrDefault(v => v.name == vertexName_2) != null)
                    {
                        Vertex vertex2 = graph.FirstOrDefault(v => v.name == vertexName_2);
                        vertex1.edges.Add(vertex2);
                    } else
                    {
                        Vertex vertex2 = new Vertex(vertexName_2);
                        vertex1.edges.Add(vertex2);
                        graph.Add(vertex2);
                    }
                } else
                {
                    Vertex vertex1 = new Vertex(vertexName_1);
                    if (graph.FirstOrDefault(v => v.name == vertexName_2) != null)
                    {
                        Vertex vertex2 = graph.FirstOrDefault(v => v.name == vertexName_2);
                        vertex1.edges.Add(vertex2);
                        graph.Add(vertex1);
                    } else
                    {
                        Vertex vertex2 = new Vertex(vertexName_2);
                        vertex1.edges.Add(vertex2);
                        graph.Add(vertex1);
                        graph.Add(vertex2);
                    }
                }
            }
        }

        void DFS(Vertex v)
        {
            v.color = Colors.Grey;
            ++time;
            v.d = time;
            v.up = graph.Count + 1;
            foreach (Vertex u in v.edges)
            {
                if (u.color == Colors.White)
                {
                    ++v.ch;
                    DFS(u);
                    v.up = Math.Min(v.up, u.up);
                    if (u.up >= v.d)
                    {
                        v.r = true;
                    }
                        
                }
                else
                {
                    v.up = Math.Min(v.up, u.d);
                }
            }

        }

        static void Main()
        {
            Program p = new Program();
            p.Inizialiser();

            Console.WriteLine("ГРАФ : ");
            foreach(Vertex v in p.graph)
            {
                Console.WriteLine(v);
            }

            foreach(Vertex v in p.graph)
            {
                if (v.color == Colors.White)
                {
                    p.DFS(v);
                    if (v.ch > 1)
                    {
                        v.r = true;
                    } else
                    {
                        v.r = false;
                    }
                }
            }

            Console.WriteLine("Точки сочленения : ");
            foreach (Vertex v in p.graph)
            {
                if (v.r)
                    Console.WriteLine(v.name);
            }

            Console.ReadLine();
        }


    }
}
