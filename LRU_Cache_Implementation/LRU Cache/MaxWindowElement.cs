namespace ConsoleApp1;

public class MaxWindowElement
{
    /*
    You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. 
    You can only see the k numbers in the window. Each time the sliding window moves right by one position.
    Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
    .
    3
    
    Todo: There is one condition that I have to check which is 
    if(list.First.Value > right) ...... something something is there
    */
    
    IList<int> MaxWindowElements(int[] arr, int k)
    {
    
        try
        {
            IList<int> res = new List<int>();
            LinkedList<int> list = new LinkedList<int>();
    
            int left = 0, right = 0;
            while (right < arr.Length)
            {
                if (list.Count == 0) list.AddLast(arr[right]);
                else
                {
                    while (list.Count > 0 && list.Last.Value < arr[right])
                    {
                        list.RemoveLast();
                    }
    
                    list.AddLast(arr[right]);
                }
    
                int elementsLen = right - left + 1;
                if (elementsLen == k)
                {
                    res.Add(list.First.Value);
                    left++;
                }
    
                right++;
    
            }
    
            return res;
        }
        catch (IndexOutOfRangeException indexOutOfRangeException)
        {
            Console.WriteLine("Index Out of given range");
            throw;
        }
        catch (NullReferenceException referenceException)
    
        {
            Console.WriteLine("Null Reference Exception has occured");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception has occured");
            throw;
        }
    
    }
    
    /*
    var arr = new[] { 1, 3, -1, -3, 5, 3, 6, 7 };
    int k = 4;
    
    var ans = MaxWindowElements(arr,k);
    
    foreach (int a in ans)
    {
        Console.Write(a + " ");
    }
    */
}