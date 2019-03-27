using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// Main class, contains the entry point
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point to the program
        /// </summary>
        /// <returns>
        /// Error codes:
        /// 0 - OK
        /// 1 - error
        /// </returns>
        static int Main(string[] args)
        {
            try
            {
                //Entry data is not specified in the requirements. Code below is for testing purposes
                var math = new Discipline("School-level math");
                var biggerMath = math.Clone();
                var physics = new Discipline("");
                //Check req.2 (toString) and req.6 (cloning)
                Console.WriteLine(math + "\n" + physics + "\n" + biggerMath + "\n");
                math.Data.Description = "Really easy school-level math";
                Console.WriteLine(math + "\n" + biggerMath + "\n");
                //Check req 4 (Equals)
                Console.WriteLine("Math == Physics : " + math.Equals(physics));
                Console.WriteLine("Math == BiggerMath : " + math.Equals(biggerMath));

                //Check connection between entities
                var mathAnalysis = new Lecture("Difficult math lecture", new Presentation("uri.com"),
                    "incomprehensible ramblings of a madman");
                math.AddLecture(mathAnalysis);
                math.AddLecture(new Lecture("Text of nameless lecture", new Presentation("uri1.com"), "simple lecture"));
                var mathSeminar = new Seminar(new List<string> {"task1", "task2"}, new Dictionary<string, string>());
                var notMathSeminar = new Seminar(new List<string> {"task1", "task2"}, new Dictionary<string, string>(),
                    "some other seminar");
                math.AddSeminar(mathSeminar, mathAnalysis);
                math.AddSeminar(notMathSeminar);
                math.AddLabwork(new Labwork("lab for math"), mathAnalysis);
                //Additional check for req.6
                var mathCopy = (Discipline) math.Clone();
                math.ListOfSeminars.RemoveAt(1);

                Console.WriteLine("\nAll seminars in Math:");
                foreach (var seminar in math.ListOfSeminars)
                {
                    Console.WriteLine(seminar);
                }

                Console.WriteLine("\nAll seminars in mathCopy:");
                foreach (var seminar in mathCopy.ListOfSeminars)
                {
                    Console.WriteLine(seminar);
                }

                //Check req 5(Indexer)
                Console.WriteLine("\nMathAnalysis lecture and everything connected to it");
                foreach (var material in math[0])
                {
                    Console.WriteLine(material);
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}