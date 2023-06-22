using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesseCookies
{
	internal class JesseCookies
	{
		private class MinHeap
		{
			private readonly List<int> heap;

			private void Swap(List<int> arr, int i, int j)
			{
				(arr[i], arr[j]) = (arr[j], arr[i]);
			}

			private void SiftDown(List<int> arr, int curIdx, int endIdx)
			{
				int childOneIdx = curIdx * 2 + 1;
				while (childOneIdx <= endIdx)
				{
					int swapIdx = childOneIdx;
					int childTwoIdx = curIdx * 2 + 2;
					if (childTwoIdx <= endIdx && arr[childTwoIdx] < arr[childOneIdx])
					{
						swapIdx = childTwoIdx;
					}
					if (arr[swapIdx] < arr[curIdx])
					{
						Swap(arr, swapIdx, curIdx);
						curIdx = swapIdx;
						childOneIdx = curIdx * 2 + 1;
					}
					else
					{
						return;
					}
				}
			}

			private void SiftUp(List<int> arr, int curIdx)
			{
				int parentIdx = (curIdx - 1) / 2;
				while (parentIdx >= 0 && arr[parentIdx] > arr[curIdx])
				{
					Swap(arr, parentIdx, curIdx);
					curIdx = parentIdx;
					parentIdx = (curIdx - 1) / 2;
				}
			}

			private List<int> BuildHeap(List<int> arr)
			{
				int parentIdx = (arr.Count - 2) / 2;
				for (int i = parentIdx; i >= 0; --i)
				{
					SiftDown(arr, parentIdx, arr.Count - 1);
				}
				return arr;
			}

			public MinHeap(List<int> arr)
			{
				heap = BuildHeap(arr);
			}

			public void Push(int val)
			{
				heap.Add(val);
				SiftUp(heap, heap.Count - 1);
			}

			public int Pop()
			{
				Swap(heap, 0, heap.Count - 1);
				int removed = heap[^1];
				heap.RemoveAt(heap.Count - 1);
				SiftDown(heap, 0, heap.Count - 1);
				return removed;
			}

			public int Peek()
			{
				return heap[0];
			}

			public bool IsEmpty()
			{
				return heap.Count == 0;
			}
		}

		public static int Cookies(int k, List<int> A)
		{
			MinHeap minHeap = new(A);
			int countCookies = 0;
			while (!minHeap.IsEmpty() && minHeap.Peek() < k)
			{
				int firstMin = minHeap.Pop();
				int secondMin = minHeap.Pop();
				int newCookie = firstMin + secondMin * 2;
				minHeap.Push(newCookie);
				++countCookies;
			}
			return countCookies;
		}

	}
}
