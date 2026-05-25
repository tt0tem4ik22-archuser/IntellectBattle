using System;
using System.IO;

class Program
{
	public static int GetScore(string[] questions, string[] answers, string[] correctAnswersFromFile) 
	{
		int scorePlayer = 0;
		for (int i = 0; i < questions.Length; i++) {
			if (answers[i] == correctAnswersFromFile[i]) {
				//Console.WriteLine($"{answers[i]} | {correctAnswersFromFile[i]} | Верно");
				scorePlayer++;
			} else {
				//Console.WriteLine($"{answers[i]} | {correctAnswersFromFile[i]} | Неверно");
				scorePlayer = scorePlayer; // pass
			}
		}	
		return scorePlayer;
	}


	public static string[] GetUserAnswers(string[] questions)
	{
		string[] answers = new string[questions.Length];
		for (int i = 0; i < questions.Length; i++) {
			Console.WriteLine(questions[i]);
			string answer = Console.ReadLine();
			answers[i] = answer;
		}
		return answers;
	}


	public static void Main()
	{
		

		int scoreFirstPlayer = 0;
		int scoreSecondPlayer = 0;

		string[] questionsFirst = {"Как вывести текст «Hello, world!» на экран", "Какой тип данных используется для хранения целых чисел", "Как объявить переменную a со значением 10", "Какой символ используется для комментария в Python", "Что выведет код: print(2 ** 3)", "Как получить длину списка my_list", "Как создать список из чисел от 1 до 5 включительно", "Как преобразовать строку '123' в число", "Как добавить элемент a в конец списка my_list", "Как обработать исключение в Python", "Как написать цикл for в одну строку, который 5 раз выводит строку «Привет!»", "Как проверить, есть ли элемент 3 в списке nums", "Что вернёт выражение type('123')", "Какой результат даст print('Python'[0])", "Какой тип данных возвращает функция input()",};
		string[] questionsSecond = {"Какой тип данных используется для хранения целых чисел", "Какой тип данных возвращает функция input()", "Как преобразовать строку '123' в число", "Какой символ используется для комментария в Python", "Как добавить элемент a в конец списка my_list", "Как создать функцию func, принимающую два аргумента: a и b", "Как вернуть значение c из функции", "Как получить длину списка my_list", "Как импортировать модуль math", "Как округлить число 3.14159 до 2 знаков после запятой", "Как создать список из чисел от 1 до 5 включительно", "Как обработать исключение в Python", "Как проверить, есть ли элемент 3 в списке nums", "Какой результат дает выражение set([1,2,2,3])", "Какой встроенный тип данных используется для хранения пар «ключ-значение»",};
		
		if (questionsFirst.Length == questionsSecond.Length) {

			string[] answersFirst = new string[questionsFirst.Length];
			string[] answersSecond = new string[questionsSecond.Length];

			Console.WriteLine("Викторина по Python3!\n\nСоветы:\nИспользуйте одинарные кавычки\nНе забывайте про двоеточие\nНе используйте отступы\n\nИгрок 1\n");
			answersFirst = GetUserAnswers(questionsFirst);
			Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nВикторина по Python3!\n\nСоветы:\nИспользуйте одинарные кавычки\nНе забывайте про двоеточие\nНе используйте отступы\n\nИгрок 2\n");
			answersSecond = GetUserAnswers(questionsSecond);

			foreach (string i in answersFirst) {
				File.AppendAllText("InputedFirstAnswers.txt", i+"\n");
			}
			foreach (string i in answersSecond) {
				File.AppendAllText("InputedSecondAnswers.txt", i+"\n");
			}
	
			string[] correctAnswersFirstFromFile = File.ReadAllLines("AnswersFirst.txt");
			string[] correctAnswersSecondFromFile = File.ReadAllLines("AnswersSecond.txt");

			scoreFirstPlayer = GetScore(questionsFirst, answersFirst, correctAnswersFirstFromFile);
			Console.WriteLine("Первый игрок: " + scoreFirstPlayer);
			scoreSecondPlayer = GetScore(questionsSecond, answersSecond, correctAnswersSecondFromFile);
			Console.WriteLine("\nВторой игрок: " + scoreSecondPlayer);

			if (scoreFirstPlayer > scoreSecondPlayer) {
				Console.WriteLine("\nПервый игрок победил!");
			}
			else if (scoreFirstPlayer < scoreSecondPlayer) {
				Console.WriteLine("\nВторой игрок победил!");
			}
			else if (scoreFirstPlayer == scoreSecondPlayer) {
				Console.WriteLine("\nНичья!");
			}
		} else 
		{
			Console.WriteLine("Неравное количество вопросов, программа не будет запущена.");
		}
		return;
	}
}
