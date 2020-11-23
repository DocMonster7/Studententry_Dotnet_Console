using System;
using System.Collections.Generic;


namespace Student_Serialized_DataEntry
{
    class Program
    {
        static void Main(string[] args)
        {

            StudentEntry newEntry = new StudentEntry();
            StudentDetails search = new StudentDetails();

            while (true)
            {

                Console.WriteLine("\nEnter a Choice\n 1. Enter One Student Into the System\n 2. Enter specified Students Into the System \n 3. Access One Student Details \n 4. List All Students in the System\n 5. Generate TXT File Of the Student Details");
                int entry = int.Parse(Console.ReadLine());
                switch (entry)
                {
                    case 1:
                        newEntry.FreshMakeEntry(1);
                        break;
                    case 2:
                        Console.WriteLine("\nEnter the total number of students that needs to be entered\n");
                        int studentEntry = int.Parse(Console.ReadLine());
                        newEntry.FreshMakeEntry(studentEntry);
                        break;
                    case 3:
                        Console.WriteLine(" \n Enter the register Number To be searched \n");
                        double registerNumber = double.Parse(Console.ReadLine());
                        search.StudentDataAccess(registerNumber);
                        break;
                    case 4:
                        search.DataDump();
                        break;
                    case 5:
                        Console.WriteLine("\nEnter a filename to be given:\n");
                        string filename = Console.ReadLine();
                        search.CreateFile(filename);
                        break;
                    default:
                        Console.WriteLine("\nChoose a valid option OR press CTRL+C to Quit\n");
                        break;
                }

            }

        }
    }

    class StudentEntry
    {
        int entryCount = 0;
        static double lastRegisterNumber = 20100000;
        public void FreshMakeEntry(int list)
        {

            while (entryCount < list)
            {
                // enter student 1 name
                Console.WriteLine("Enter Student Number " + (entryCount + 1) + " Name:\n");
                string studentName = Console.ReadLine();
                Console.WriteLine("Enter Student Number " + (entryCount + 1) + " DOB (in DD-MM-YYYY format):\n");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                entryCount++;
                double registerNumber = lastRegisterNumber + 1;
                lastRegisterNumber = registerNumber;


                StudentDetails sendDetails = new StudentDetails(registerNumber, studentName, dateOfBirth);


            }


        }
    }

    class StudentDetails
    {
        static Dictionary<double, Tuple<string, string>> studentDataDump = new Dictionary<double, Tuple<string, string>>();
        public StudentDetails()
        {
            // gives error if this isnt present... No other purpose 
        }
        public StudentDetails(double registerNumber, string name, DateTime dateOfBirth)
        {
            studentDataDump.Add(registerNumber, Tuple.Create(name, dateOfBirth.ToString("d")));
            Console.WriteLine("\n Entered student Entry : \n");
            StudentDataAccess(registerNumber);
        }
        public void StudentDataAccess(double registerNumber)
        {
            Console.WriteLine("\nStudent detail of register Number: " + registerNumber + " are Following \n" + studentDataDump[registerNumber]);
        }
        public void DataDump()
        {
            foreach (var kvp in studentDataDump)
            {
                Console.WriteLine("\nRegister Number: " + kvp.Key + "\n Details :" + kvp.Value);
            }
        }
        public void CreateFile(string fileName)
        {
            
        }

    }

}
