namespace QVCalculator
{
    internal class Calculate
    {
        private static double informaticSkills;
        private static double advancedSkills;
        private static double IPA;
        private static double generalEducation;
        private static bool isDoingBM;

        public static void StartText()
        {
            Console.WriteLine("Willkommen zum QV Rechner");
            Console.WriteLine("Halte dein Zeugnis bereit um deine Noten zu erfassen. Diese werden nicht im System gespeichert.");
            Console.WriteLine("Machst du nebenbei Berufsmatur? Wenn Ja, schreibe BM sonst wird das QV normal berechnet:");

            isDoingBM = Console.ReadLine() switch
            {
                "BM" => true,
                _ => false,
            };

            GetInformaticSkillsGrade();
        }

        public static void GetInformaticSkillsGrade()
        {
            Console.WriteLine("Welche Note hast du bei den Informatikkompetenzen?");
            informaticSkills = ParseUserInput(Console.ReadLine());

            if (isDoingBM)
                GetIPAGrade();
            else
                GetAdvancedSkillsGrade();
        }

        public static void GetAdvancedSkillsGrade()
        {
            Console.WriteLine("Welche Note hast du bei den Erweiterten Grundkompetenzen?");
            advancedSkills = ParseUserInput(Console.ReadLine());

            GetIPAGrade();
        }

        public static void GetIPAGrade()
        {
            Console.WriteLine("Welche Note wirst du wahrscheinlich bei der IPA haben?");
            IPA = ParseUserInput(Console.ReadLine());

            if (isDoingBM)
                CalculateEverything();
            else
                GetGeneralEducationGrade();
        }

        public static void GetGeneralEducationGrade()
        {
            Console.WriteLine("Welche Allgemeinbildung Note hast du durchschnittlich im Zeugnis? (Summe aller Noten / Anzahl der Noten, sorry musst selber was rechnen)");
            
            double gEGrade = ParseUserInput(Console.ReadLine());

            Console.WriteLine("Welche Note hast für die VA bekommen?");
            
            double VA = ParseUserInput(Console.ReadLine());
            
            Console.WriteLine("Welche Note wirst du wahrscheinlich bei der ABU Prüfung haben?");
            
            double gEExam = ParseUserInput(Console.ReadLine());

            generalEducation = (gEGrade + VA + gEExam) / 3;

            CalculateEverything();
        }

        public static void CalculateEverything()
        {
            double QV;

            if (isDoingBM)
                QV = (50 * informaticSkills + 50 * IPA) / 100;
            else
                QV = (30 * informaticSkills + 30 * IPA + 20 * advancedSkills + 20 * generalEducation) / 100;

            Console.WriteLine($"Deine QV Note ist: {QV}");
        }

        private static double ParseUserInput(string? input)
        {
            if (double.TryParse(input, out double parsedValue))
                return parsedValue;
            else
                Console.WriteLine($"Falsche Eingabe! : {input}");

            return default;
        }
    }
}
