using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace Dijkstra_AlgorithmProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {

			
            Request r = new Request();


			string path = "/Users/noufalrasheed/Desktop/Data.csv";
			
			  int[] InputRequestOutput = new int[4];
			  InputRequestOutput = Request.InputRequest();

			  int[] readRecordOutput = new int[4];
			  readRecordOutput = Request.readRecord(InputRequestOutput[0].ToString(), path, InputRequestOutput[1], InputRequestOutput[2], InputRequestOutput[3]);
			  Console.WriteLine("\n\n result");
			  string ZipAddress = readRecordOutput[0].ToString();
			  int Acounter = readRecordOutput[1];
			  int Fcounter = readRecordOutput[2];
			  int Pcounter = readRecordOutput[3];

            // build the graph only when help is needed from nearest zipCodes
            if (Acounter != 0 || Fcounter != 0 || Pcounter != 0)
            {


                Graph g = new Graph();
                // read the Nodes(Vertices) from the file and add them to the graph
                using (StreamReader sr = new StreamReader("/Users/noufalrasheed/Desktop/Node.csv"))
                {
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] strCols = line.Split(',');
                        line = sr.ReadLine();
                        g.AddVertex(strCols[0]);


                    }
                }

                // read the Edges from the file and add them to the graph
                using (StreamReader sr = new StreamReader("/Users/noufalrasheed/Desktop/Edge.csv"))
                {

                    string line = sr.ReadLine();
                    //incase if you want to ignore the header
                    while (line != null)
                    {
                        string[] strCols = line.Split(',');
                        line = sr.ReadLine();
                        string cost = strCols[2].Trim();
                        int cost1 = Int32.Parse(cost);
                        g.AddEdge(strCols[0], strCols[1], cost1, true);
                        //(src,dst,cost,bi-direction)

                    }
                }
                // create object for Dijkstra Class
                var dijkstra = new Dijkstra();
                // method to apply Dijkstra Algorithm which takes (graph,src) as arguments.

                var x = dijkstra.ApplyDijkstra(g, ZipAddress);
                // order the output in ascending order based on the smallest cost from src
                var dict = x.OrderBy(i => i.Value).ToDictionary(i => i.Key, i => i.Value.ToString());
                //printing the results
                foreach (var a in dict)
                {
                    Console.WriteLine("ZipCode: {0}\t Cost: {1}", a.Key, a.Value);
                }
                ZipCode temp;
				//create object from InfoRepository class
				var InfoRep = new InfoRepository();
                // read each zipCode information(how many vehicle for each type) and store them under zipCode name
                using (StreamReader sr = new StreamReader("/Users/noufalrasheed/Desktop/Data.csv"))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] strCols = line.Split(',');
                        line = sr.ReadLine();
                        temp = new ZipCode(strCols[0]);
                        temp.Infos.Add(new VehiclesInfo("Ambulance", Convert.ToInt32(strCols[1])));
                        temp.Infos.Add(new VehiclesInfo("FireTruck", Convert.ToInt32(strCols[2])));
                        temp.Infos.Add(new VehiclesInfo("PoliceCar", Convert.ToInt32(strCols[3])));
                        InfoRep.Add(temp);

                    }
                }

              // convert the dictionary to 2D-array
                string[,] stringArray2d = new string[2, dict.Count];
                int ii = 0;
                foreach (KeyValuePair<string, string> item in dict)
                {
                    stringArray2d[0, ii] = item.Key;
                    stringArray2d[1, ii] = item.Value;
                    ii++;
                }
                // variable used to store the txt results
                string txt1;
				// help class used to process insufficient vehicles
				Help h = new Help();
                StreamWriter sw = File.AppendText("/Users/noufalrasheed/Desktop/Request1.txt");
                // call getHelp for each type in case the return value was greater than 0
                if (Acounter != 0)
                {
                    sw.WriteLine("Getting help from nearest ZipCodes\n");
                    txt1 = Help.getHelp(Acounter, stringArray2d, "Ambulance", InfoRep);
                    sw.WriteLine(txt1);

                }
                txt1 = "";

                if (Fcounter > 0)
                {
                    sw.WriteLine("Getting help from nearest ZipCodes\n");
                    txt1 = Help.getHelp(Fcounter, stringArray2d, "FireTruck", InfoRep);
                    sw.WriteLine(txt1);

                }
                txt1 = "";

                if (Pcounter != 0)
                {
                    sw.WriteLine("Getting help from nearest ZipCodes\n");
                    txt1 = Help.getHelp(Pcounter, stringArray2d, "PoliceCar", InfoRep);
                    sw.WriteLine(txt1);

                }
                sw.WriteLine("\n\nThank you for using our system!");
                sw.Close();
            }


		}
    }
}
