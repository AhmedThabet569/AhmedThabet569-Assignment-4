using BenchmarkDotNet.Running;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cSharpTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sessionNames =
                    {
                        "C# Basics",
                        "Arrays",
                        "Functions",
                        "Date and Time",
                        "Exception Handling"
                    };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 30, 18, 0, 0)
            };

            int[] sessionDurations =
                                    {
                                        180,
                                        240,
                                        180,
                                        240,
                                        180
                                    };

            //display All session 
            Console.WriteLine("===================================\n Academy Schedule Analyzer \n===================================\r\n");
            Console.WriteLine("Chosse an Option");
            Console.WriteLine("""
                        1. Display all sessions
                        2. Search for a session
                        3. Sort session names
                        4. Reverse session names
                        5. Find session index
                        6. Check if session exists
                        7. Show duration statistics
                        8. Show session date details
                        9. Show past and upcoming sessions
                        10. Find next session
                        11. Compare two session dates
                        12. Read and validate a custom date
                        13. Select session by index
                        14. Validate session duration
                        15. Generate report using string
                        16. Generate report using StringBuilder
                        0. Exit
                        """);
            while (true)
            {

                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        // Display all sessions
                        DisplaySessions(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 2:
                        SearchSession(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 3:
                        SortSessiosn(sessionNames);
                        break;
                    case 4:
                        ReverseSessionNames(sessionNames);
                        break;
                    case 5:
                        findSessionIndex(sessionNames);
                        break;
                    case 6:
                        findSessionName(sessionNames);
                        break;
                    case 7:
                        Console.WriteLine(CalculateTotalDuration(sessionDurations[0], sessionDurations[3]));
                        break;
                    case 8:
                        DisplaySessionDateDetails(sessionNames, sessionDates, sessionDurations);
                        break;
                    case 9:
                        compareWithCurrentDate(sessionDates, sessionNames);
                        break;
                    case 10:
                        findNextSession(sessionDates, sessionNames);
                        break;
                    case 11:
                        compareWithCurrentDate(sessionDates, sessionNames);
                        break;
                    case 12:
                        ReadAndValidateDate();
                        break;
                    case 13:
                        findSessionIndex(sessionNames);
                        break;
                    case 14:
                        durationException();
                        break;
                    case 15:
                        Console.WriteLine(buildScheduleReport(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 16:
                        Console.WriteLine(buildScheduleReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

 
             
            
            //////find session 
            //getSeessionName(sessionNames);
            //////copy Array
            //copyNames(sessionNames);
            ////operatiopn on duration 
            //addOperationToDuartion(sessionDurations);
            ////sorted duration 
            //sortArrayDuration(sessionDurations);

            //TimeOnly[] endTimes = GetSessionEndTime(sessionDates, sessionDurations);

            //foreach (TimeOnly endTime in endTimes)
            //{
            //    Console.WriteLine(endTime);
            //}
            //int number = 6;
            //Console.WriteLine($"return from ref {returnfromRef(ref number)}");
            //int duration;
            //RefTrain("Arrays", sessionNames, sessionDurations, out duration);
            //Console.WriteLine(CalculateTotalDuration(sessionDurations[0], sessionDurations[3]));
            //DisplaySessionDateDetails(sessionNames, sessionDates, sessionDurations);
            //DisplayDateDifference(sessionNames, sessionDates);
            //compareWithCurrentDate(sessionDates, sessionNames);
            //findNextSession(sessionDates, sessionNames);
            //DisplayFormattedDates(sessionDates[0]);
            //ReadAndValidateDate();
  
            //HandleMenuInput();
            //HandleArrayIndex(sessionNames);
            //durationException();
            //Console.WriteLine(buildScheduleReport(sessionNames, sessionDates, sessionDurations));
            //Console.WriteLine(buildScheduleReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));

            //BenchmarkRunner.Run<BenchmarkLoop>();
        }

        
        //task 1
        static void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
        {
            if (checkParamsLenght(names, dates, durations))
            {
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine($"{i} - {names[i]}");
                    Console.WriteLine($"Date: {dates[i].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"Date: {dates[i].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"Duration- {durations[i]} Minutes");
                }
            }
        }

        private static bool checkParamsLenght(string[] names, DateTime[] dates, int[] durations)
        {
            return names.Length != 0 && dates.Length != 0 && durations.Length != 0 && names.Length == dates.Length && names.Length == durations.Length;
        }

        //task2  : Part 3 — Search for a Session

        public static void SearchSession(string[] names, DateTime[] dates, int[] durations)
        {
            Console.WriteLine("please enter valid session name");
            string? userInput = Console.ReadLine();
            int searchIndex = 0;
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("No input entered.");
                return;
            }
            searchIndex = Array.FindIndex(names, n => n.Equals(userInput, StringComparison.OrdinalIgnoreCase));
            DisplaySessionDetails(names, dates, durations, searchIndex);
        }

        public static void DisplaySessionDetails(string[] names, DateTime[] dates, int[] durations, int index)
        {

            Console.WriteLine($"{index + 1}. {names[index]}");
            Console.WriteLine($"Date: {dates[index].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Start Time: {dates[index].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Duration: {durations[index]} minutes");
            Console.WriteLine();
        }

        //4.1 Sort Session Names 
        public static void SortSessiosn(string[] names)
        {
            string[] result = new string[names.Length];
            Array.Copy(names, result, names.Length);
            Array.Sort(result);
            Console.WriteLine("Array after Sort");
            foreach (string s in result)
            {
                Console.WriteLine($"{s}");
            }
        }
        //4.2 reverse sesssion  names 
        public static void ReverseSessionNames(string[] names)
        {
            string[] result = new string[names.Length];
            Array.Copy(names, result, names.Length);
            Array.Reverse(result);
            Console.WriteLine("Array after reverse");
            foreach (string s in result)
            {
                Console.WriteLine($"{s}");
            }
        }
        //4.3 Find Session Index
        public static void findSessionIndex(string[] names)
        {
            Console.WriteLine("enter session name ?");
            string userInput = Console.ReadLine();
            Console.WriteLine($"Index {Array.FindIndex(names, n => n.Equals(userInput, StringComparison.OrdinalIgnoreCase))}");
        }

        //4.4 Check if a Session Exists
        public static void findSessionName(string[] names)
        {

            Console.WriteLine("enter session name ?");
            string userInput = Console.ReadLine();
            if (Array.Exists(names, name => name.Equals(userInput, StringComparison.OrdinalIgnoreCase)))
                Console.WriteLine("Session exists");
            else
                Console.WriteLine("Session Not exists");

        }
        //4.5 Find a Session 
        public static void getSeessionName(string[] names)
        {
            Console.WriteLine("enter session name ?");
            string userInput = Console.ReadLine();
            Console.WriteLine($"Index {Array.Find(names, name => name.Equals(userInput, StringComparison.OrdinalIgnoreCase))}");
        }
        //4.6 Find a Session Index Using a Condition
        public static void getSessionIndex(string[] names)
        {
            Console.WriteLine("enter session name ?");
            string userInput = Console.ReadLine();
            Console.WriteLine($"Index {Array.FindIndex(names, name => name == userInput)}");
        }
        //4.7 Copy an Array

        public static void copyNames(string[] names)
        {
            string[] copyied = new string[names.Length];
            Array.Copy(names, copyied, names.Length);
            copyied[0] = "C# OOP";
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Original Array {names[i]}");
            }
            for (int i = 0; i < copyied.Length; i++)
            {
                Console.WriteLine($"copyied Array {copyied[i]}");
            }
        }

        //Part 5 — Duration Analysis
        public static void addOperationToDuartion(int[] duration)
        {
            int total = 0, avg = 0, max = 0, min = duration[0];

            for (int i = 0; i < duration.Length; i++)
            {
                total += duration[i];
                avg = total / duration.Length;
                if (duration[i] < min)
                    min = duration[i];
                if (duration[i] > max)
                    max = duration[i];
            }
            Console.WriteLine($"Total Duration: {total} minutes");
            Console.WriteLine($"avg Duration: {avg} minutes");
            Console.WriteLine($"Shortest Duration: {min} minutes");
            Console.WriteLine($"Longest Duration: {max} minutes");
        }
        //Part 5.1 — Duration Analysis
        public static void sortArrayDuration(int[] duration)
        {
            int[] copyArray = new int[duration.Length];
            Array.Copy(duration, copyArray, duration.Length);
            Array.Sort(copyArray);

            foreach (int item in copyArray)
            {
                Console.WriteLine($"i- {item}");
            }
        }
        //part 6 
        public static int GetTotalDuration(int[] durations)
        {
            int total = 0;

            foreach (int duration in durations)
            {
                total += duration;
            }

            return total;
        }

        public static double getAverageDuration(int[] durations)
        {
            int total = GetTotalDuration(durations);
            return (double)total / durations.Length;
        }

        public static int GetLongestDuration(int[] durations)
        {
            int longest = durations[0];
            foreach (int duration in durations)
            {
                if (duration > longest)
                {
                    longest = duration;
                }
            }
            return longest;
        }
        public static int GetShortestDuration(int[] durations)
        {
            int shortest = durations[0];
            foreach (int duration in durations)
            {
                if (duration < shortest)
                {
                    shortest = duration;
                }
            }
            return shortest;
        }
        //end session date 
        public static TimeOnly[] GetSessionEndTime(DateTime[] dates, int[] duration)
        {
            if (dates.Length == 0 || duration.Length == 0 || dates.Length != duration.Length)
                Console.WriteLine("invalid lenght");
            TimeOnly[] endSessionTime = new TimeOnly[dates.Length];
            for (int i = 0; i < dates.Length; i++)
            {
                //get time only 
                TimeOnly sessionTime = TimeOnly.FromDateTime(dates[i]);

                endSessionTime[i] = sessionTime.AddMinutes(duration[i]);
            }
            return endSessionTime;
        }

        //Part 7 — ref, out, and Reference-Type Parameters 

        public static int returnfromRef(ref int number)
        {
            Console.WriteLine($"number before ref {number}");
            number += 10;
            return number;
        }

        //part 7.1 — ref, out, and Reference-Type Parameters
        public static void RefTrain(string userInput, string[] names, int[] durations, out int duartion)
        {

            int index = Array.FindIndex(names, n => n.Equals(userInput, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"index - {index}");
            duartion = durations[index];
            Console.WriteLine($"Duartion is {duartion}");
        }
        //7.3 Reference Type Without ref
        public static void ReferenceTypeWithoutRef(string[] names)
        {
            string[] copyArray = new string[names.Length];
            Array.Copy(names, copyArray, names.Length);
            copyArray[0] = "C# OOP";
            Console.WriteLine($"Original Array {names[0]}");
            Console.WriteLine($"copyied Array {copyArray[0]}");
        }
        //part time prarms kayword 
        public static int CalculateTotalDuration(params int[] data)
        {
            int total = 0;
            foreach (var item in data)
            {
                total += item;
            }
            return total;
        }
        //Part 9 — Session Date Details
        public static void DisplaySessionDateDetails(string[] names, DateTime[] dates, int[] duration)
        {
            Console.WriteLine("enter session name ?");
            string userInput = Console.ReadLine();
            int index = Array.FindIndex(names, name => name.Equals(userInput, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"Date: {dates[index].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Day of Week: {dates[index].DayOfWeek}");
            Console.WriteLine($"Year: {dates[index].Year}");
            Console.WriteLine($"Month: {dates[index].Month}");
            Console.WriteLine($"Day: {dates[index].Day}");
            Console.WriteLine($"Start Time: {dates[index].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Duration : {duration[index]}");
            TimeOnly endTime = TimeOnly.FromDateTime(dates[index]).AddMinutes(duration[index]);
            Console.WriteLine($"End Time: {endTime}");
        }
        //Part 10 — Date Difference 
        public static void DisplayDateDifference(string[] names, DateTime[] dates)
        {
            Console.WriteLine("enter first session name ?");
            string firstSession = Console.ReadLine();
            Console.WriteLine("enter first session name ?");
            string secondSession = Console.ReadLine();
            Console.WriteLine($"First Session: {firstSession}");
            Console.WriteLine($"Second Session: {secondSession}");
            int firstIndex = Array.FindIndex(names, name => name.Equals(firstSession, StringComparison.OrdinalIgnoreCase));
            int secondIndex = Array.FindIndex(names, name => name.Equals(secondSession, StringComparison.OrdinalIgnoreCase));
            TimeSpan difference = dates[secondIndex] - dates[firstIndex];
            Console.WriteLine($"Difference:\n {difference.Days} Days \n {difference.Minutes} Minutes");
        }
        // compare with current date
        public static void compareWithCurrentDate(DateTime[] dates, string[] names)
        {
            DateTime currentDate = DateTime.Now;
            for (int i = 0; i < dates.Length; i++)
            {
                string status = dates[i] < currentDate ? "Past" : "upComing";
                Console.WriteLine($"{names[i]} {status}");
            }
        }
        //find next session 
        public static void findNextSession(DateTime[] dates, string[] names)
        {
            DateTime currentDate = DateTime.Now;

            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] > currentDate)
                {
                    Console.WriteLine($"Next Session:\n  {names[i]} on {dates[i].ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)} \n at {dates[i].ToString("hh:mm tt", CultureInfo.InvariantCulture)}");
                    TimeSpan dfifrence = dates[i] - currentDate;
                    Console.WriteLine($"diffrence is {dfifrence.Days} days \n and {dfifrence.Minutes} minutes");
                    break;
                }
            }
        }
        //Part 13 — Date Formatting
        public static void DisplayFormattedDates(DateTime date)
        {
            Console.WriteLine(date.ToString("yyyy-MM-dd"));
            Console.WriteLine(date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(date.ToString("d MMMM yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(date.ToString("dddd, d MMMM yyyy", CultureInfo.InvariantCulture));
            Console.WriteLine(date.ToString("hh:mm tt", CultureInfo.InvariantCulture));
        }
        //Part 14 — Read and Validate a Date 
        public static bool TryGetStrictDate(string input, out DateTime result)
        {
            // Define the only acceptable format rule
            string requiredFormat = "yyyy-MM-dd HH:mm";

            // DateTimeStyles.None ensures no extra spaces or lenient padding are allowed
            return DateTime.TryParseExact(
                input,
                requiredFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out result
            );
        }

        public static void ReadAndValidateDate()
        {
            DateTime userData;
            string userEntered;
            while (true)
            {
                Console.WriteLine("Enter a date (yyyy-MM-dd):");
                userEntered = Console.ReadLine();
                if (TryGetStrictDate(userEntered, out userData))
                {
                    Console.WriteLine($"this formate are accepted {userData}");
                }
                Console.WriteLine("Error: Invalid format. You must use exactly yyyy-MM-dd HH:mm (e.g., 2026-09-13 14:30)");
            }

        }
        //Part 15 — Exception Handling: Menu Input
        public static void HandleMenuInput()
        {
            while (true)
            {
                Console.WriteLine("Enter a menu option ?");
                string userInput = Console.ReadLine();
                try
                {
                    Console.WriteLine($"{int.Parse(userInput)}");
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Invalid menu option. Enter a number");
                }

            }
        }
        //Part 16 — Exception Handling: Invalid Array Index
        public static void HandleArrayIndex(string[] names)
        {
            while (true)
            {
                Console.WriteLine("Enter an index to access the session name:");
                string userInput = Console.ReadLine();
                try
                {
                    int index = int.Parse(userInput);
                    try
                    {
                        Console.WriteLine($"{Array.Find(names, n => n.Equals(names[index], StringComparison.OrdinalIgnoreCase))}");
                        break;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.WriteLine("Invalid index. Please enter a valid index.");
                    }

                }
                catch (FormatException ex)
                {

                    throw;
                }

            }
        }

        //Part 17 — Throw an Exception 
        public static void durationException()
        {

            while (true)
            {
                Console.WriteLine("Enter valid duration");
                string userInput = Console.ReadLine();
                try
                {


                    int index = int.Parse(userInput);
                    if (index < 0)
                    {
                        throw new ArgumentOutOfRangeException("Duration must be greater than zero.");
                    }
                    else
                    {
                        Console.WriteLine($"Valid duration: {index} acccepted");
                        break;
                    }
                }
                catch (FormatException ex)
                {

                    throw;
                }
            }



        }
        //Part 18 — finally 
        public static void getUserInput()
        {
            while (true)
            {
                Console.WriteLine("Enter a number to divide 100 by:");
                string userInput = Console.ReadLine();
                try
                {
                    Console.WriteLine($"you entered {userInput}");
                }
                catch (FormatException ex)
                {

                    throw ex;
                }
                finally
                {
                    Console.WriteLine("Input operation finished.");
                }

            }
        }

        //Part 19 — Build a Schedule Report Using string
        public static string buildScheduleReport(string[] names, DateTime[] dates, int[] durations)
        {
            string report = "";
            for (int i = 0; i < names.Length; i++)
            {
                report += $"{names[i]}-";
                report += $"{dates[i].ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)} - ";
                report += $"Duration: {durations[i]} minutes\n";
            }
            return report;
        }

        //Part 20 — Build the Same Report Using StringBuilder
        public static string buildScheduleReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
        {
            var reportBuilder = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                reportBuilder.Append($"{names[i]}-");
                reportBuilder.Append($"{dates[i].ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)} - ");
                reportBuilder.Append($"Duration: {durations[i]} minutes\n");
            }
            return reportBuilder.ToString();
        }
    }
}