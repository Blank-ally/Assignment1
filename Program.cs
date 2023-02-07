namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String file = "tickets.csv";
            string input;

            do
            {// menu options for users 
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
               
                // stored user  input 
                input = Console.ReadLine();


                if (input == "1")
                {
                    if (File.Exists(file))
                    {

                        // stream reader to read file 
                        StreamReader sr = new StreamReader(file);
                        sr.ReadLine();
                        // a loop that checks for end of file 
                        while (!sr.EndOfStream)
                        {
                            //grabs the lines in the file
                            var line = sr.ReadLine();

                            //  adds each line from the file to an array 
                            string[] arr = line.Split(',');


                            // an attempt to replace the (|) pipes in the 6th line in the array with commas 
                            string[] watching = arr[arr.Length - 1].Split('|');


                            // test to see what the file outputs 
                            Console.WriteLine(
                                $"TicketId:{arr[0]}\nsummary:{arr[1]}\nStatus:{arr[2]}\nPriority:{arr[3]}\nSubmitter:{arr[4]}\nAssigned:{arr[5]}\nWatching:");

                            for (int i = 0; i < watching.Length; i++)
                            {
                                if (i == watching.Length - 1)
                                {
                                    Console.WriteLine(watching[i]);
                                }
                                else
                                {
                                    Console.Write(watching[i] + ", ");
                                }
                            }

                        }

                        sr.Close(); //always close

                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (input == "2")
                {

                    //stream writer to write to file
                    StreamWriter sw = new StreamWriter(file, true);

                    // gathering user input
                    Console.WriteLine("Ticket ID?");
                    string id = Console.ReadLine();


                    Console.WriteLine("summary");
                    string summary = Console.ReadLine();


                    Console.WriteLine("status");
                    String status = Console.ReadLine();


                    Console.WriteLine("Priority");
                    String priority = Console.ReadLine();


                    Console.WriteLine("submitter");
                    String submitter = Console.ReadLine();

                   
                    Console.WriteLine("Assigned");
                    String assigned = Console.ReadLine();

                    // getting the number of users for the watching data so i know how many times to loop 
                    Console.WriteLine("how many watchers");
                    int watchers = Convert.ToInt32(Console.ReadLine());


                  // a string array with the sise of watchers variable i can add to in my loop 
                    String [] watching = new String[watchers];
                    // for loop to store the names the user enters followed by a pipe so i don't have to edit the way the file reads 
                    for (int i = 0; i < watchers; i++)
                    {
                        Console.WriteLine("who's watching");
                        watching[i] = Console.ReadLine();
                    }
                    
                // what is written to the console 
                sw.WriteLine($"{id},{summary},{status},{priority},{submitter},{assigned},{string.Join('|', watching)}");

                    sw.Close(); // always close and don't loop your close statement
                }
            } while (input == "1" || input == "2");
        }
    }
}