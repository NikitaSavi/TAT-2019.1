﻿using System.Collections.Generic;
using System.Linq;

namespace DEV_4
{

    class Lecture : Material
    {
        public string Text { get; set; }
        private const int TextMaxLength = 100000;

        public string Uri { get; set; } //TODO Uri set - similar way to Guid or...?
        public string PresentationType { get; set; }

        public List<Seminar> ListOfSeminarsToThisLecture { get; set; }
        public List<Labwork> ListOfLabworksToThisLecture { get; set; }
        private static readonly string[] PresentationsAllTypes = {"PPT", "PDF"};

        public Lecture(string text, string uri, string presentationType = "Unknown",
            string description = null) : base(description)
        {
            //TODO constructor is a tad bit cumbersome, a better way to implement might exist
            Text = text.WithMaxLength(TextMaxLength);
            Uri = uri;
            if (PresentationsAllTypes.Contains(presentationType))
            {
                PresentationType = presentationType;
            }
        }
    }
}