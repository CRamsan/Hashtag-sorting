using System;

namespace Fun
{
	class MainClass
	{
		public const int LIST_SIZE = 3;

		public static void Main (string[] args)
		{
			int[] randomList = new int[LIST_SIZE];
			fillWithRandomNumbers(randomList);
			for (int i =0; i < randomList.Length; i++) 
			{
				Console.Out.WriteLine(randomList[i]);
			}
			Console.Out.WriteLine("Now sorted: ");
			//bubbleSort(randomList);
			//insertionSort(randomList);
			mergeSort(randomList);
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
				list[i] = rnd.Next(LIST_SIZE * 2);
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

		//Complexity O(n^2) but with a best-case-scenario of O(n),
		//better than bubble sort in all cases.
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

		public static void mergeSort(int[] list)
		{
			splitThenMerge(list);
		}

		private static void splitThenMerge(int[] list)
		{
			split(list, 0, list.Length);
		}

		private static void split(int[] list, int start, int length)
		{
			if(length > 1)
			{
				int isOdd = 0, newLength;
				if(length % 2 != 0)
				{
					isOdd = 1;
				}
				newLength = length/2 ;
				split(list, start, newLength + isOdd);
				split(list, start + newLength + isOdd , newLength);
				merge(list, start, newLength + isOdd, start + newLength + isOdd , newLength);
			}
		}

		private static void merge(int[] list, int startA, int lengthA, int startB, int lenghtB)
		{
			int i = 0, j = 0, k = startA, temp;

			do {
				if(list[startA + i] > list[startB + j])
				{
					temp = list[startA + i];
					list[k] = list[startB + j];
					list[startB + j] = temp;
					i++;
				}
				else
				{
					j++;
				}
			}while(i < lengthA && j < lenghtB );

		}
	}
}