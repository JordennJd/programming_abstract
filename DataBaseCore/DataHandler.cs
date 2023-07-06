using System;
using System.Data;
using TelegramBot;
using TelegramAndSQL.TimeTableCore;
namespace DataBaseCore

{

	class DataHandler
	{
		
        public static void AddULessonInDB(List<Lesson> lessons)
		{
			foreach (Lesson lesson in lessons)
			{
				if (!IsLessonInDB(lesson))
				{
					RequestGenerator.INSERT(GetFormedStringForINSERT(null,lesson:lesson),
					"TimeTable(Info, DayOfWeek, PairNumber, Modification)");

				}
			}
		}

		public static void AddUserInDB(User user)
		{
			if (!IsUserInDB(user))
            {
				RequestGenerator.INSERT(GetFormedStringForINSERT(user), "users(id, name, role, modification)");
			}
		}

		//Нужно реализовать изменение информации о пользователях в БД
		private static string GetFormedStringForINSERT(User user = null, Lesson lesson = null)
		{
			if (user != null)
				return $"{user.id},'{user.name}','{user.role}','{user.modification}'";

			if (lesson != null)
				return $"'{lesson.info}','{lesson.pairNumber}','{lesson.dayOfWeek}','{lesson.modification}'";

			return null;
		}

		private static bool IsUserInDB(User user)
		{
			return RequestGenerator.SELECT("id","users").Contains(user.id.ToString());
		}

        private static bool IsLessonInDB(Lesson lesson)
        {
            return RequestGenerator.SELECT("Info", "TimeTable",
				$"WHERE DayOfWeek = {lesson.dayOfWeek} AND PairNumber = {lesson.pairNumber}").Contains(lesson.info.ToString());
        }

		

	}

}
		//public static List<User> GetUsers()
		//{
		//	List<string> Id = RequestGenerator.SELECT("id", "users");
  //          List<string> name = RequestGenerator.SELECT("name", "users");
  //          List<string> role = RequestGenerator.SELECT("role", "users");
  //          List<string> mod = RequestGenerator.SELECT("modification", "users");
		//	List<User> allInfo = new List<User>();
		//	for(int i = 0;i < Id.Count(); i++)
		//	{
		//		allInfo.Add(new User(Id[i], name[i], role[i], mod[i]));
				
		//	}
		//	return allInfo;

  //      }