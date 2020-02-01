### What is this
Just a simple performance benchmark that I created <em>for fun</em> to compare the performance of several .Net API client library using BenchmarkDotNet.

#### Methodology
1. Created simple Api application using .Net Core and host it in local IIS.
2. Created Benchmark and point it to said API.
3. Magic.

#### Library Tested
- WebRequest
- HttpClient 
- WebClient
- RestSharp

#### Result
``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.101
  [Host]     : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  Job-ZGFRFT : .NET Framework 4.8 (4.8.3801.0), X64 RyuJIT
  Job-CMAXFX : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT


```
|          Method |       Runtime |     Mean |    Error |   StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |-------------- |---------:|---------:|---------:|--------:|------:|------:|----------:|
|  Get_WebRequest |    .NET 4.7.2 | 160.0 us |  0.99 us |  0.88 us |  5.8594 |     - |     - |   9.61 KB |
|  Get_HttpClient |    .NET 4.7.2 | 378.9 us |  3.80 us |  3.56 us | 14.6484 |     - |     - |  23.84 KB |
|   Get_WebClient |    .NET 4.7.2 | 163.2 us |  4.19 us |  4.65 us |  5.8594 |     - |     - |   9.72 KB |
|   Get_RestSharp |    .NET 4.7.2 | 198.5 us |  2.03 us |  1.90 us | 23.4375 |     - |     - |  38.26 KB |
| Post_WebRequest |    .NET 4.7.2 | 163.5 us |  1.07 us |  1.00 us |  9.2773 |     - |     - |  15.32 KB |
| Post_HttpClient |    .NET 4.7.2 | 387.5 us |  7.96 us |  8.17 us | 14.6484 |     - |     - |  23.82 KB |
|  Post_WebClient |    .NET 4.7.2 | 169.9 us |  2.21 us |  2.07 us |  7.5684 |     - |     - |  12.37 KB |
|  Post_RestSharp |    .NET 4.7.2 | 199.6 us |  1.34 us |  1.26 us | 23.6816 |     - |     - |  38.85 KB |
|  Get_WebRequest | .NET Core 3.1 | 538.3 us |  4.01 us |  3.75 us |  2.9297 |     - |     - |  26.96 KB |
|  Get_HttpClient | .NET Core 3.1 | 539.8 us | 10.56 us |  9.36 us |  1.9531 |     - |     - |  20.16 KB |
|   Get_WebClient | .NET Core 3.1 | 533.3 us | 14.73 us | 16.96 us |  2.9297 |     - |     - |  26.22 KB |
|   Get_RestSharp | .NET Core 3.1 | 596.2 us |  5.67 us |  4.74 us |  6.8359 |     - |     - |  56.65 KB |
| Post_WebRequest | .NET Core 3.1 | 545.2 us | 10.66 us | 13.48 us |  3.9063 |     - |     - |  32.47 KB |
| Post_HttpClient | .NET Core 3.1 | 522.2 us |  2.00 us |  1.78 us |  1.9531 |     - |     - |  20.18 KB |
|  Post_WebClient | .NET Core 3.1 | 534.7 us |  0.99 us |  0.83 us |  3.9063 |     - |     - |  29.91 KB |
|  Post_RestSharp | .NET Core 3.1 | 591.0 us |  3.48 us |  2.71 us |  6.8359 |     - |     - |  57.79 KB |
