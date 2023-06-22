# Jesse and Cookies

Jesse loves cookies and wants the sweetness of some cookies to be greater than value k. To do this, two cookies with the least sweetness are repeatedly mixed. This creates a special combined cookie with:

sweetness = (1 * Least sweet cookie + 2 * 2nd least sweet cookie).

This occurs until all the cookies have a sweetness >= k.

Given the sweetness of a number of cookies, determine the minimum number of operations required. If it is not possible, return -1.

Example
k = 9
A = [2,7,3,6,4,6]

The smallest values are 2,3.
Remove them then return 2 + 2 * 3 = 8 to the array. Now A = [8,7,6,4,6].
Remove 4,6 and return 4 + 6 * 2 = 16 to the array. Now A = [16,8,7,6].
Remove 6,7, return 6 + 2 * 7 = 20 and A = [20,16,8,7].
Finally, remove 8,7 and return 7 + 2 * 8 = 23 to A. Now A = [23,20,16].
All values are >= k = 9 so the process stops after 4 iterations. Return A.

Function Description
Complete the cookies function in the editor below.

cookies has the following parameters:

int k: the threshold value
int A[n]: an array of sweetness values
Returns

int: the number of iterations required or -1
Input Format

The first line has two space-separated integers, n and k, the size of A[] and the minimum required sweetness respectively.

The next line contains n space-separated integers, A[i].

Constraints
1 <= n <= 10^6
0 <= k <= 10^9
0 <= A[i] <= 10^6


Sample Input

STDIN               Function
-----               --------
6 7                 A[] size n = 6, k = 7
1 2 3 9 10 12       A = [1, 2, 3, 9, 10, 12]  
Sample Output

2
Explanation

Combine the first two cookies to create a cookie with sweetness = 1 * 1 + 2 * 2 = 5
After this operation, the cookies are 3,5,9,10,12.
Then, combine the cookies with sweetness 3 and sweetness 5, to create a cookie with resulting sweetness  = 1 * 3 + 2 * 5 = 13
Now, the cookies are 9,10,12,13.
All the cookies have a sweetness >= 7.

Thus, 2 operations are required to increase the sweetness.