using System;

namespace Fun
{
	class MainClass
	{
		public const int LIST_SIZE = 10;

		public static void Main (string[] args)
		{
			int[] randomList = new int[LIST_SIZE];
			//fillWithUniqueRandomNumbers(randomList);
			fillWithRandomNumbers(randomList);
			for (int i =0; i < randomList.Length; i++) 
			{
				Console.Out.WriteLine(randomList[i]);
			}
			Console.Out.WriteLine("Now sorted: ");
			//bubbleSort(randomList);
			//insertionSort(randomList);
			//mergeSort(randomList);
			//quicksort(randomList);
			//quicksortinplace(randomList, 0, randomList.Length);
			selectionsort(randomList);
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

		public static void fillWithUniqueRandomNumbers (int[] list)
		{
			Random rnd = new Random();
			int index;
			for (int i = 1; i <= list.Length; i++) 
			{
				index = rnd.Next(LIST_SIZE);
				if(list[index] == 0)
				{
					list[index] = i;
				}
				else
				{
					i--;
				}
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

		//Complexity O(n log(n))
		public static void mergeSort(int[] list)
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
				newLength = (length/2);
				split(list, start, newLength + isOdd);
				split(list, start + newLength + isOdd , newLength);
				merge(list, start, newLength + isOdd, start + newLength + isOdd , newLength);
			}
		}

		private static void merge(int[] list, int startA, int lengthA, int startB, int lenghtB)
		{
			int i = 0, j = 0, k = 0;

			int[] outlist = new int[lenghtB + lengthA];

			for(int p = 0; p < outlist.Length; p++)
			{
				if(j >= lengthA)
				{
					outlist[k] = list[startB + i];
					i++;
				}
				else if (i >= lenghtB)
				{
					outlist[k] = list[startA + j];
					j++;
				} 
				else if(list[startA + j] > list[startB + i])
				{
					outlist[k] = list[startB + i];
					i++;
				}
				else
				{
					outlist[k] = list[startA + j];
					j++;
				}
				k++;
			}

			for(int p = 0; p < outlist.Length; p++)
			{
				list[startA + p] = outlist[p];
			}

		}

		public static void quicksort (int[] list)
		{
			partition(list, 0, list.Length);
		}

		private static void partition (int[] list, int start, int length)
		{
			if (length < 2) {
				return;
			}

			Random rnd = new Random ();
			int pivotIndex = start + rnd.Next (length);
			int pivot = list [pivotIndex];
			int left = start, right = start + length - 1;

			while (left < right) {
				while(list [left] < pivot) 
				{
					left++;
				}
				while(list[right] > pivot )
				{
					right--;
				}
				swap(list, right, left);
			}
			pivotIndex = left;

			partition(list, start, pivotIndex - start );
			partition(list, pivotIndex + 1, start + length - pivotIndex - 1);
		}

		//Not working yet
		public static void quicksortinplace (int[] list, int start, int length)
		{
			if(length < 2)
			{
				return;
			}
			int pivotIndex = partitioninplace(list, start, length);
			quicksortinplace(list, start, pivotIndex - start);
			quicksortinplace(list, pivotIndex + 1,  length - pivotIndex - 1);
		}
		
		private static int partitioninplace (int[] list, int start, int length)
		{
			Random rnd = new Random ();
			int pivotIndex = start + rnd.Next (length);
			pivotIndex = 2;
			int pivot = list [pivotIndex];
			swap(list, pivotIndex, length - 1);
			int left = start, right = start + length - 1;
			int storeIndex = left;
			while (left < right) {
				if(list[left] <= pivot)
				{
					swap(list, left, storeIndex);
					storeIndex++;
				}
				left++;
			}
			swap(list, storeIndex, right);
			return storeIndex;
		}

		public static int binarySearch(int[] list, int term)
		{
			int max = list.Length, min = 0;
			int middle = -1;
			while (max - min > 1 ) {
				middle = (min + max) / 2;
				if (term < list[middle]) {
					max = middle;
				} else {
					min = middle;
				}
			}
			if (list[min] == term) {
				return min;
			} else {
				return -1;
			}

		}
	
		public static void selectionsort (int[] list)
		{
			int index;
			int min;
			for (int i = 0; i < list.Length - 1; i++) {
				index = i;
				min = Int16.MaxValue;
				for (int j = i; j < list.Length; j++) {
					if(list[j] < min)
					{
						min = list[j];
						index = j;
					}
				}
				swap(list, index, i);
			}
		}

		private static void swap(int[] list, int a, int b)
		{
//			for (int i =0; i < list.Length; i++) 
//			{
//				Console.Out.Write(list[i] + "-");
//			}
//			Console.Out.WriteLine();
			int temp = list[a];
			list[a] = list[b];
			list[b] = temp;
//			for (int i =0; i < list.Length; i++) 
//			{
//				Console.Out.Write(list[i] + "-");
//			}
//			Console.Out.WriteLine();
//			Console.Out.WriteLine();
		}
	}
}