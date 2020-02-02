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
|               Method |       Runtime |     Mean |    Error |   StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |---------:|---------:|---------:|--------:|------:|------:|----------:|
|       Get_WebRequest |    .NET 4.7.2 | 153.1 us |  1.93 us |  1.80 us |  5.8594 |     - |     - |   9.58 KB |
|  Get_HttpClientAsync |    .NET 4.7.2 | 197.7 us |  0.97 us |  0.91 us | 11.2305 |     - |     - |  18.54 KB |
|   Get_WebClientAsync |    .NET 4.7.2 | 177.2 us |  3.50 us |  4.56 us |  7.5684 |     - |     - |  12.46 KB |
|   Get_RestSharpAsync |    .NET 4.7.2 | 212.6 us |  0.62 us |  0.58 us | 25.6348 |     - |     - |  42.02 KB |
|      Post_WebRequest |    .NET 4.7.2 | 157.6 us |  0.86 us |  0.80 us |  9.2773 |     - |     - |   15.3 KB |
| Post_HttpClientAsync |    .NET 4.7.2 | 201.2 us |  3.92 us |  4.36 us | 11.4746 |     - |     - |  18.83 KB |
|  Post_WebClientAsync |    .NET 4.7.2 | 200.7 us |  0.34 us |  0.30 us |  9.0332 |     - |     - |  14.86 KB |
|  Post_RestSharpAsync |    .NET 4.7.2 | 214.2 us |  0.71 us |  0.67 us | 26.1230 |     - |     - |  42.49 KB |
|       Get_WebRequest | .NET Core 3.1 | 531.4 us |  4.54 us |  3.55 us |  2.9297 |     - |     - |  26.95 KB |
|  Get_HttpClientAsync | .NET Core 3.1 | 147.4 us |  0.77 us |  0.72 us |  0.2441 |     - |     - |   3.75 KB |
|   Get_WebClientAsync | .NET Core 3.1 | 539.2 us |  3.51 us |  3.28 us |  3.9063 |     - |     - |  27.83 KB |
|   Get_RestSharpAsync | .NET Core 3.1 | 614.1 us | 11.67 us | 11.47 us |  6.8359 |     - |     - |  57.68 KB |
|      Post_WebRequest | .NET Core 3.1 | 535.6 us |  2.44 us |  2.17 us |  3.9063 |     - |     - |  32.46 KB |
| Post_HttpClientAsync | .NET Core 3.1 | 147.1 us |  0.95 us |  0.89 us |  0.2441 |     - |     - |   3.75 KB |
|  Post_WebClientAsync | .NET Core 3.1 | 575.4 us |  2.58 us |  2.29 us |  3.9063 |     - |     - |  31.41 KB |
|  Post_RestSharpAsync | .NET Core 3.1 | 622.7 us | 12.22 us | 15.88 us |  6.8359 |     - |     - |  58.63 KB |