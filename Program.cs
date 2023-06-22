namespace JesseCookies
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

			int n = Convert.ToInt32(firstMultipleInput[0]);

			int k = Convert.ToInt32(firstMultipleInput[1]);

			List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

			int result = JesseCookies.Cookies(k, A);

			Console.WriteLine(result);
		}
	}
}