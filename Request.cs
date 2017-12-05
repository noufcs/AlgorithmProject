using System;
using System.IO;
namespace Dijkstra_AlgorithmProject
{
    public class Request
    {
        
        public Request()
        {
        }
		public static int[] InputRequest() 
        {
			// create StreamWriter to write output in text file.
			StreamWriter sw = File.AppendText("/Users/noufalrasheed/Desktop/Request1.txt");
			int Input;
			int search2 = 0;
			int type1 = 0;
			int type2 = 0;
			int type3 = 0;
			bool repeat = true;
			Console.Write("Please Enter Your Zip Code: "); // enter zipcode
			Input = Convert.ToInt32(Console.ReadLine()); // convert the input to int
			// user input request type

			while (repeat)
			{
				Console.Write("\n Enter 1 for Ambulance \n Enter 2 for Fire Truck \n Enter 3 for Police Car \n Enter 0 to quit\n Please Enter Request Type : ");
				search2 = Convert.ToInt32(Console.ReadLine());
				if (search2 == 1)
				{ // first type 

                    Console.Write("How many veihcle you need:\t ");
					type1 = Convert.ToInt32(Console.ReadLine());

				}
				else if (search2 == 2)
				{ // second type
                    Console.Write("How many veihcle you need:\t ");
					type2 = Convert.ToInt32(Console.ReadLine());
				}
				else if (search2 == 3)
				{ //Third type
                    Console.Write("How many veihcle you need:\t ");
					type3 = Convert.ToInt32(Console.ReadLine());
				}
				else if (search2 == 0)
				{
					Console.WriteLine("Plrase wait, Your Request will processed ");
                    Console.WriteLine("Your Request is \nAmbulance:" + type1 + "\nFire Truck: "+ type2 + "\nPolice Car:  " + type3 + "  ");
                    sw.WriteLine("Your Request is \nAmbulance:" + type1 + "\nFire Truck: " + type2 + "\nPolice Car:  " + type3 + "  ");
					repeat = false;
				}
				else
				{
					Console.WriteLine("Please Enter Correct request ");// this if user input not one of the 3 types

				}

			}

            sw.Close();
			return new int[] { Input, type1, type2, type3 };

		}



		public static int[] readRecord(String address, String path, int vehicleType1, int vehicleType2, int vehicleType3)
		{
			StreamWriter sw = File.AppendText("/Users/noufalrasheed/Desktop/Request1.txt");
			bool found = false;
			String ZipCode = "";
			String Ambulance = "";
			String FireTruck = "";
			String Policecar = "";
			String VehicalID = "";
			int count1 = 0;
			int count2 = 0;
			int count3 = 0;
			String vehicleType2String = "" + vehicleType2;
            Random r = new Random(); 

			using (StreamReader sr = new StreamReader(path))
			{
				string line = sr.ReadLine();
				//incase if you want to ignore the header
				while (line != null && !found)
				{
					string[] strCols = line.Split(',');
					line = sr.ReadLine();
					ZipCode = strCols[0];
					Ambulance = strCols[1];
					FireTruck = strCols[2];
					Policecar = strCols[3];
					VehicalID = strCols[4];
					if (ZipCode == address)
					{

						found = true;
					}
				}
			}


			if (found)
			{

				Console.WriteLine("ZipCode :  " + ZipCode + "  Ambulance :  " + Ambulance + "   FireTruck :  " + FireTruck + "  Policecar :  " + Policecar);
                sw.WriteLine("Your current ZipCode Information:");
                sw.WriteLine("ZipCode :  " + ZipCode + "  Ambulance :  " + Ambulance + "   FireTruck :  " + FireTruck + "  Policecar :  " + Policecar);


				if (vehicleType1 >= 1)
				{

					int Type1 = Convert.ToInt32(Ambulance);

					if (Type1 >= vehicleType1)
					{

                        int vID = r.Next(11, 99);
                        Console.WriteLine("\nYou Requested: " + vehicleType1 + "  Ambulance(s)");
                        sw.WriteLine("\nYou Requested: " + vehicleType1 + "  Ambulance(s)");
						while (vehicleType1 > 0)
						{
							Console.WriteLine("Ambulance #" + vehicleType1 + "\t Your VehicalID  is:  " + vID);
							sw.WriteLine("Ambulance #" + vehicleType1 + "\t Your VehicalID  is:  " + vID);
							vehicleType1--;
							vID--;

						}
						

					}

					else

					{
                        int typee1 = Type1;

                        int vID = r.Next(11, 99);
                        while (typee1 > 0)
                        {
                            Console.WriteLine("Ambulance #" + typee1 + "\t Your VehicalID  is:  " + vID);
                            sw.WriteLine("Ambulance #" + typee1 + "\t Your VehicalID  is:  " + vID);
                            typee1--;
                            vID--;

                        }
                  

					

						count1 = vehicleType1 - Type1;
                        Console.WriteLine("Unfortunately, your current ZipCode does not has sufficient Ambulance vehicle(s).\n we'll ask help from the nearest ZipCodes");
                        sw.WriteLine("Unfortunately, your current ZipCode does not has sufficient Ambulance vehicle(s).\n we'll ask help from the nearest ZipCodes\n");
					


					}


				} //end of type 1


				if (vehicleType2 >= 1)
				{

					int Type2 = Convert.ToInt32(FireTruck);

					if (Type2 >= vehicleType2)
					{
                        int vID = r.Next(11, 99);
                        Console.WriteLine("\nYou Requested: " + vehicleType2 + "  FireTruck(s)");
                        sw.WriteLine("\nYou Requested: " + vehicleType2 + "  FireTruck(s)");
                        while (vehicleType2>0)
                        {
							Console.WriteLine("FireTruck #" + vehicleType2 + "\t Your VehicalID  is:  " + vID);
							sw.WriteLine("FireTruck #" + vehicleType2 + "\t Your VehicalID  is:  " + vID);
							vehicleType2--;
							vID--;
                            
                        }
						

					}

					else

					{
						int typee2 = Type2;

                        int vID = r.Next(11, 99);
						while (typee2 > 0)
						{
							Console.WriteLine("FireTruck #" + typee2 + "\t Your VehicalID  is:  " + vID);
							sw.WriteLine("FireTruck #" + typee2 + "\t Your VehicalID  is:  " + vID);
							typee2--;
							vID--;

						}

                        count2 = vehicleType2 - Type2;
                        Console.WriteLine("Unfortunately, your current ZipCode does not has sufficient FireTruck(s) vehicles.\n we'll ask help from the nearest ZipCodes ");
                        sw.WriteLine("Unfortunately, your current ZipCode does not has sufficient FireTruck(s) vehicles.\n we'll ask help from the nearest ZipCodes\n");
					

					}

				} //end of type 2


				if (vehicleType3 >= 1)
				{


					int Type3 = Convert.ToInt32(Policecar);

					if (Type3 >= vehicleType3)
					{
                        int vID = r.Next(11, 99);
                        Console.WriteLine("\nYou Requested: " +vehicleType3 + "  PoliceCar(s)" );
                        sw.WriteLine("\nYou Requested: " +vehicleType3 + "  PoliceCar(s)" );
						while (vehicleType3 > 0)
                        {
                            
                            Console.WriteLine("PoliceCar #" +vehicleType3 + "\t Your VehicalID  is:  " + vID);
                            sw.WriteLine("PoliceCar #" + vehicleType3 + "\t Your VehicalID  is:  " + vID);
                            vehicleType3--;
                            vID--;
                        }


					}

					else

					{
						int typee3 = Type3;

                        int vID = r.Next(11, 99);
						while (typee3 > 0)
						{
							Console.WriteLine("FireTruck #" + typee3 + "\t Your VehicalID  is:  " + vID);
							sw.WriteLine("FireTruck #" + typee3 + "\t Your VehicalID  is:  " + vID);
							typee3--;
							vID--;

						}
						count3 = vehicleType3 - Type3;
						Console.WriteLine("Unfortunately, your current ZipCode does not has sufficient PoliceCar(s) vehicles.\n we'll ask help from the nearest ZipCodes ");
                        sw.WriteLine("Unfortunately, your current ZipCode does not has sufficient PoliceCar(s) vehicles.\n we'll ask help from the nearest ZipCodes\n");

					}
                    //sw.Close();

				} //end of type 3

			}///if(found)


			else
			{

				Console.WriteLine("ZipCode is not found ");
			}
            sw.Close();
            return new int[] {Convert.ToInt32(address),count1, count2, count3 };


		}








	}
}
