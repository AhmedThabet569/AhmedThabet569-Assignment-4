#BenchmarkDotNet result 
1• Which approach was faster with 100 iterations?   
StringBuilderConcatenation was faster with 100 iterations.

StringBuilderConcatenation: 909.1 ns (~0.91 microseconds)

StringConcatenation: 4,711.8 ns (~4.71 microseconds)

StringBuilder was approximately 5.2 times faster even at just 100 iterations. 


2-• Which approach was faster with 100,000 iterations?
StringBuilderConcatenation was the faster approach at 100,000 iterations:

StringBuilderConcatenation: 2.77 ms (2,767,011.2 ns).

StringConcatenation: 19.50 s (19,504,928,165.0 ns).

The StringBuilder approach was over 7,000 times faster than normal string concatenation at 100,000 iterations.



3-• Which approach allocated more memory?

At 100 iterations:

StringConcatenation: 20.37 KB

StringBuilderConcatenation: 1.25 KB

At 100,000 iterations:

StringConcatenation: 46,793,818.77 KB (~44.62 GB)

StringBuilderConcatenation: 1,931.49 KB (~1.89 MB)

StringConcatenation allocated over 23,000 times more memory at 100,000 iterations due to creating a new string instance in memory on every concatenation step.


4-• What happened to string concatenation performance as the loop size increased?

As the loop size increased, the performance of normal string concatenation (StringConcatenation) degraded exponentially (quadratically, $O(N^2)$) in terms of both execution time and memory usage:Execution
 Time:At 100 iterations, 

 5-Why does repeated string concatenation create additional allocations? 

Repeated string concatenation creates additional allocations because strings in C# (.NET) are immutable (unchangeable in memory).

6-Why does StringBuilder usually perform better when text is repeatedly appended?

StringBuilder performs significantly better when text is repeatedly appended because it is mutable and uses an internal expandable buffer (char[]), avoiding constant object reallocations on the heap.

7-Is StringBuilder always better than normal string operations? Explain.
no at always 
string used for small string to create or update and for small operation 
stringbuilder for larage opertion to save memory using
