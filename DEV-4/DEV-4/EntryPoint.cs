using System;
using System.Collections.Generic;

namespace DEV_4
{
    /// <summary>
    /// DEV-4: The program for a curriculum (disciplines + materials). Extension methods, method overrides, indexers are made according to the requirements
    /// </summary>
    public class EntryPoint
    {
        /// <summary>
        /// The entry point to the program
        /// </summary>
        /// <returns>
        /// Error codes:
        /// 0 - OK
        /// 1 - error
        /// </returns>
        private static int Main()
        {
            try
            {
                //// Entry data is not specified in the requirements. Code below is for testing purposes
                //// Check req.2 (toString) and req.6 (cloning)
                var math = new Discipline("School-level math");
                var biggerMath = math.Clone();
                var physics = new Discipline();
                Console.WriteLine(math + "\n" + physics + "\n" + biggerMath + "\n");
                //// Change description of the original, copy's decrip. mustn't change
                math.Data.Description = "Really easy school-level math";
                Console.WriteLine(math + "\n" + biggerMath + "\n");
                //// Check req 4 (Equals)
                Console.WriteLine("Math == Physics : " + math.Equals(physics));
                Console.WriteLine("Math == BiggerMath : " + math.Equals(biggerMath));

                //// Check connection between entities
                var mathAnalysis = new Lecture(
                    "Difficult math lecture",
                    new Presentation("uri.com"),
                    "incomprehensible ramblings of a madman");
                //// Add lectures to a discipline
                math.AddLecture(mathAnalysis);
                math.AddLecture(
                    new Lecture("Text of nameless lecture", new Presentation("uri1.com"), "simple lecture"));
                //// Create seminars
                var mathSeminar = new Seminar(
                    new List<string> {"task1", "task2"},
                    new Dictionary<string, string>(),
                    "first seminar");
                var notMathSeminar = new Seminar(
                    new List<string> {"task1", "task2"},
                    new Dictionary<string, string>(),
                    "some other seminar");
                //// Add seminar to math disp. and connect it to math.analysis lecture
                math.AddSeminar(mathSeminar, mathAnalysis);
                //// Add seminar to math disp. without a lecture connection
                math.AddSeminar(notMathSeminar);
                math.AddLabwork(new Labwork("lab for math"), mathAnalysis);
                //// Additional check for req.6: create a copy (2 seminars in math), delete a seminar in the original, copy must still have 2 seminars
                var mathCopy = (Discipline) math.Clone();
                math.ListOfSeminars.RemoveAt(1);
                //// Should return only mathSeminar's description
                Console.WriteLine("\nAll seminars in Math:");
                foreach (var seminar in math.ListOfSeminars)
                {
                    Console.WriteLine(seminar);
                }

                //// Should return both seminars
                Console.WriteLine("\nAll seminars in mathCopy:");
                foreach (var seminar in mathCopy.ListOfSeminars)
                {
                    Console.WriteLine(seminar);
                }

                //// Check req 5(Indexer)
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