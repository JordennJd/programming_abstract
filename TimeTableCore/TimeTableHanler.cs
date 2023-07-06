using static MainNode.Programm;

namespace TelegramAndSQL.TimeTableCore
{
	sealed class TimeTableHanler
	{
		private static List<Lesson> Lessons = new List<Lesson>();

		public static void AddNewLesson(string Info, string DayOfWeek, string PairNumber, string Modification)
		{
            if (!IsLessonExist(PairNumber, DayOfWeek))
            { 
			    Lessons.Add(new Lesson(Info, PairNumber, DayOfWeek, Modification));
                TbUpdater(Lessons);
            }

        }

        private static bool IsLessonExist(string pairNumber,string dayOfWeek)
        {
            if (FindLesson(pairNumber, dayOfWeek) != null)
            {
                return true;
            }
            return false;
        }

        private static Lesson FindLesson(string Pair,string Day)
        {
            List<string> info = new List<string>();
            foreach (Lesson lesson in Lessons)
            {
                if(Day == lesson.dayOfWeek && Pair == lesson.pairNumber)
                {
                    return lesson;

                }
            }
            return null;
        }

    }
}

