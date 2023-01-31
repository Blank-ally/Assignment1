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


                        // an attempt to replace the (|) pipes in the 6 line in the array with commas 
                        arr[6].Replace('|', ',');

                        // test to see what the file outputs 
                        Console.WriteLine($"TicketId{arr[0]}, summary: {arr[1]},Status: {arr[2]},Priority:{arr[3]},Submitter:{arr[4]},Assigned:{arr[5]},Watching{arr[6]}");
                    }

                    sr.Close(); //always close
                }
                else if (input == "2")
                {
                    StreamWriter sw = new StreamWriter(file, true);


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


                    Console.WriteLine("how many watchers");
                    int watchers = Convert.ToInt32(Console.ReadLine());


                  
                    String watching = "";
                    for (int i = 0; i < watchers; i++)
                    {
                        Console.WriteLine("who's watching");
                        watching += Console.ReadLine() + " ";
                    }
                    
                
                sw.WriteLine($"{id},{summary},{status},{priority},{submitter},{assigned},{watching}");

                    sw.Close(); // always close and don't loop your close statement
                }
            } while (input == "1" || input == "2");
        }
    }
}