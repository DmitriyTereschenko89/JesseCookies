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
			private readonly List<long> heap;

			private void Swap(int i, int j)
			{
				(heap[i], heap[j]) = (heap[j], heap[i]);
			}

			private void SiftDown(int curIdx, int endIdx)
			{
				int childOneIdx = curIdx * 2 + 1;
				while (childOneIdx <= endIdx)
				{
					int swapIdx = childOneIdx;
					int childTwoIdx = curIdx * 2 + 2;
					if (childTwoIdx <= endIdx && heap[childTwoIdx] < heap[childOneIdx])
					{
						swapIdx = childTwoIdx;
					}
					if (heap[swapIdx] < heap[curIdx])
					{
						Swap(swapIdx, curIdx);
						curIdx = swapIdx;
						childOneIdx = curIdx * 2 + 1;
					}
					else
					{
						return;
					}
				}
			}

			private void SiftUp(int curIdx)
			{
				int parentIdx = (curIdx - 1) / 2;
				while (parentIdx >= 0 && heap[parentIdx] > heap[curIdx])
				{
					Swap(parentIdx, curIdx);
					curIdx = parentIdx;
					parentIdx = (curIdx - 1) / 2;
				}
			}

			public MinHeap(List<int> arr)
			{
				heap = new List<long>();
				foreach (int num in arr)
				{
					Push((long)num);
				}
			}

			public void Push(long val)
			{
				heap.Add(val);
				SiftUp(heap.Count - 1);
			}

			public long Pop()
			{
				Swap(0, heap.Count - 1);
				long removed = heap[^1];
				heap.RemoveAt(heap.Count - 1);
				SiftDown(0, heap.Count - 1);
				return removed;
			}

			public long Peek()
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
				long firstMin = minHeap.Pop();
				long secondMin = minHeap.IsEmpty() ? -1 : minHeap.Pop();
				if (secondMin == -1)
				{
					return -1;
				}
				long newCookie = firstMin + secondMin * 2;
				minHeap.Push(newCookie);
				++countCookies;
			}
			return minHeap.IsEmpty() ? -1 : countCookies;
		}

	}
}
