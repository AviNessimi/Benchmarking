using BenchmarkDotNet.Running;
using Benchmarking;

// Run benchmarking on all types in the specified assembly
//var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

// Run benchmarking on the specified type
var summary = BenchmarkRunner.Run<Test1>();
