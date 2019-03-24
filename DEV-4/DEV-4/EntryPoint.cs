using System;

namespace DEV_4
{
    class EntryPoint
    {
        //TODO Connect Seminars/Labs to Lectures and to discipline
        static int Main(string[] args)
        {
            try
            {
                var A =new Discipline("TESt");
                A.ListOfLectures.Add(new Lecture("text", "1", "PDF","testlect"));
                A.ListOfMaterials.Add(A.ListOfLectures[0],new Seminar("yo"));
                foreach (var VARIABLE in A[0])
                {
                    Console.WriteLine(VARIABLE.ToString());
                }

                ;
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