using System;

namespace Fun
{
	class MainClass
	{
		public const int LIST_SIZE = 100;

		public static void Main (string[] args)
		{
			int[] randomList = new int[LIST_SIZE];
			fillWithRandomNumbers(randomList);
			//bubbleSort(randomList);
			insertionSort(randomList);
			for (int i =0; i < randomList.Length; i++) 
			{
				Console.Out.WriteLine(randomList[i]);
			}
		}


		public static void fillWithRandomNumbers (int[] list)
		{
			Random rnd = new Random();
			for (int i =0; i < list.Length; i++) 
			{
				list[i] = rnd.Next(LIST_SIZE);
			}
		}

		//Complexity O(n^2)
		public static void bubbleSort (int [] list)
		{
			int temp;
			for (int i = 0; i < list.Length - 1; i++) 
			{
				for (int j = i + 1; j < list.Length; j++) 
				{
					if(list[i] > list[j])
					{
						temp = list[j];
						list[j] = list[i];
						list[i] = temp;
					}
				}
			}
		}

		//Complexity O(n^2)
		public static void insertionSort (int[] list)
		{
			if (list.Length == 0 || list.Length == 1) 
			{
				return;
			}

			int temp;
			for (int i = 1; i < list.Length; i++) 
			{
				for (int j = i - 1; j >= 0; j--) 
				{
					if(list[j+1] < list[j])
					{
						temp = list[j];
						list[j] = list[j+1];
						list[j+1] = temp;
					}
				}
			}
		}

	}
}