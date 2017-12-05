using System;
using System.IO;
namespace Dijkstra_AlgorithmProject
{
    public class Help
    {
       
        public static string getHelp(int theCounter, string[,] stringArray2d, string type, InfoRepository InfoRep)
        {
            string txt = "";
			int c = 1;
            bool flag = true;
			Random rr = new Random();
			//int Fcounter = 20; // send by user to ask for help from the nearest zipCodes and it is the main counter to specify how many zipcode needed
			//theCounter = 3;
			int tempCounter = 0; // counter used to calculate how many vehicle has been used from adjecent zipcodes
			int constant = theCounter; // constant needed to manage the loop
			int Pcounter1 = theCounter;
			int temp2 = 0; // counter to hold how many vehicle to use from the last zipcode in case if last zipcode has more vehicles than needed
			while (flag && theCounter > 0)
			{
				string zip_code = stringArray2d[0, c];
				string cost = stringArray2d[1, c];
				var tempF = InfoRep.getQuantity(zip_code, type);
                Console.WriteLine(zip_code + " has total:" + tempF + type);
                txt+=(zip_code + " has total:" + tempF + type +"\n");
				theCounter = theCounter - tempF;
				tempCounter = tempCounter + tempF;
				if (Pcounter1 < tempF)
				{
                    while (Pcounter1 > 0)
                    {
                        txt += (type + "#"+Pcounter1+ "\t Your VehicalID  is:  " + zip_code + "." + rr.Next(1, 100)+"\n");
                        Console.WriteLine(type + "#" + Pcounter1 + "\t Your VehicalID  is:  " + zip_code + "." + rr.Next(1, 100) + "\n");
						//Console.WriteLine(Pcounter1);
						Pcounter1--;
					}

				}
				//Console.WriteLine("temp cnt" + tempCounter);
				if (tempCounter > constant)
				{
					temp2 = tempCounter - tempF;
					int temp3 = tempCounter - constant;
					int temp4 = temp2 - temp3 - 1;
					while (temp4 >= 1 && Pcounter1 > 0)
					{
						txt += (type+"#"+Pcounter1+ " \t Your VehicalID  is:  " + zip_code + "." + rr.Next(1, 100)+"\n");
                        Console.WriteLine(type + "#" + Pcounter1 + " \t Your VehicalID  is:  " + zip_code + "." + rr.Next(1, 100) + "\n");
						//Console.WriteLine(Pcounter1);//output
						Pcounter1--;
						temp4--;


					}
				}
				while (tempCounter <= constant && tempF > 0)
				{
                    txt += (type+ "#"+Pcounter1+ " \t Your VehicalID  is:  " + zip_code + "." + rr.Next(1, 100)+"\n");
                    Console.WriteLine(type + "#" + Pcounter1 + " \t Your VehicalID  is:  " + zip_code + "." + rr.Next(1, 100) + "\n");
					//Console.WriteLine(Pcounter1);//output
					Pcounter1--;
					tempF--;
				}

				if (theCounter > 0)
					c++;
				if (theCounter == 0)
				{
					//sw.Close();
					flag = false;
				}
			}
            return txt;
            
        }
    }
}
