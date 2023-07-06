using System;
namespace TelegramAndSQL.TimeTableCore
{
	internal class Lesson
	{
		public string info;
		public string dayOfWeek;
		public string pairNumber;
		public string modification;

		public Lesson(string Info, string DayOfWeek,string PairNumber,string Modification = null)
		{
			this.info = Info;
			this.dayOfWeek = DayOfWeek;
			this.pairNumber = PairNumber;
			this.modification = Modification;
		}

		public void AddMod(string mod)
		{
			this.modification = mod;
		}
	}
}

