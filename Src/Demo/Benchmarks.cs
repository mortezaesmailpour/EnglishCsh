using BenchmarkDotNet.Attributes;
using English;

namespace Demo;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Benchmark]
    public void ToStringA()
    {
    }
    [Benchmark]
    public void ToStringB()
    {
    }
}
