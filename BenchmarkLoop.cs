using BenchmarkDotNet.Attributes;
using System.Text;

// 1. Pass the CLASS to the runner
namespace cSharpTask4
{
    [MemoryDiagnoser]
    public class BenchmarkLoop
    {
        [Params(100, 1000, 10000, 100000)]
        public int Iterations;
        [Benchmark]
        public  string StringConcatenation()
        {
            string result = "";
            for (int i = 0; i < Iterations; i++)
            {
                result += i;
            }
            return result;
        }
        [Benchmark]
        public  string StringBuilderConcatenation()
        {
            var result = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                result.Append(i);
            }
            return result.ToString();
        }
    }
}
