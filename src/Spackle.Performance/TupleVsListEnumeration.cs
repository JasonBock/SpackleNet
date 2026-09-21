using BenchmarkDotNet.Attributes;
using Spackle.Extensions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Spackle.Performance;

[MemoryDiagnoser]
#pragma warning disable CA1515 // Consider making public types internal
public class TupleVsListEnumeration
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	private List<object> listItems;
	private ITuple tupleItems;

	[GlobalSetup]
	public void GlobalSetup()
	{
		this.listItems = 
			[
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
			];
		this.tupleItems = 
			(
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble(),
				Guid.NewGuid(), Guid.NewGuid().ToString(), RandomNumberGenerator.Next(), RandomNumberGenerator.NextDouble()
			);
	}

	[Benchmark(Baseline = true)]
	public int EnumerateList()
	{
		var count = 0;

		foreach (var item in this.listItems)
		{
			count++;
		}

		return count;
	}

	[Benchmark]
	public int EnumerateTuple()
	{
		var count = 0;

		foreach (var item in this.tupleItems)
		{
			count++;
		}

		return count;
	}
}