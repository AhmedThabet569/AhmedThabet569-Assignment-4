# LeetCode Profile:
https://leetcode.com/u/thabeta532/

# Valid Anagram

• Problem name
• Problem URL : https://leetcode.com/problems/valid-anagram/post-solution/?submissionId=2154195387
. problme screenshot: Valid_Anagram_submit.jpg



# Valid Anagram — LeetCode: https://leetcode.com/problems/valid-anagram

1- first i valid used Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.

i create function to validte string lenght and used letter case 

2- second i used count as pointer so loop through string and return index of every string in first string and if i found i increse its count 
ex a: 2 b:1 etc 
and second string i loop through as same but decresse count 

after this i check count lenght and return bool 

time complexity : o(n)

loop : o(n)
loop : o(n)
int[26]: o(26)

resutl = o(n) + o(n) + o(26) = o(2n + 26) = o(n)

space complexity of the solution : o(n)


https://leetcode.com/problems/greatest-common-divisor-of-strings/ 



# Greatest Common Divisor of Strings
problem name : Greatest Common Divisor of Strings
problem  url : https://leetcode.com/problems/greatest-common-divisor-of-strings/submissions/2154273666/
problem image : Greatest_of_String_submit.jpg

expline:
first we must insure that concat of two string is givne same if not return false 
and while through elemenet to get  substring lenght  
check it by while loop 

