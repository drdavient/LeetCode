namespace LeetCode;

public class LengthOfLongestSubstring3
{
    
    public static int Substring(string s)
    {
        return new LengthOfLongestSubstring3().LengthOfLongestSubstring(s);
    }
    public int LengthOfLongestSubstring1(string s)
    {
        Dictionary <char,int>  substring = new Dictionary<char, int>();
        int max = 0;
        int count = 0;
        
            for (int k = 0; k < s.Length; k++)
            {
                if (substring.TryAdd(s[k],k))
                {
                    count++;
                }
                else
                {
                    max = count > max ? count : max;
                    if (k + 1 == s.Length) return max;
                    count = 0;
                    k = substring[s[k]];
                    substring.Clear();
                }
            
        }

        return count > max ? count : max;
    }
    
    public int LengthOfLongestSubstring(string s)
    {
        string  substring="";
        int max = 0;
        int count = 0;
        
        for (int k = 0; k < s.Length; k++)
        {
            
            if (!substring.Contains(s[k]))
            {
                substring += s[k];
            }
            else
            {
                max = substring.Length > max ? substring.Length : max;
                if (k + 1 == s.Length) return max;
                
                substring = substring.Substring(substring.IndexOf(s[k])+1) + s[k];
            }
            
        }

        return substring.Length > max ? substring.Length : max;
    }
}