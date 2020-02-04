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
  Job-PUPVZI : .NET Framework 4.8 (4.8.3801.0), X64 RyuJIT
  Job-ZOULJB : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT


```
|               Method |       Runtime |     Mean |    Error |   StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |---------:|---------:|---------:|--------:|------:|------:|----------:|
|       Get_WebRequest |    .NET 4.7.2 | 154.9 us |  1.03 us |  0.96 us |  5.8594 |     - |     - |   9.58 KB |
|  Get_HttpClientAsync |    .NET 4.7.2 | 205.5 us |  4.03 us |  3.96 us | 11.2305 |     - |     - |  18.51 KB |
|   Get_WebClientAsync |    .NET 4.7.2 | 181.1 us |  0.67 us |  0.60 us |  7.5684 |     - |     - |  12.46 KB |
|   Get_RestSharpAsync |    .NET 4.7.2 | 218.9 us |  0.51 us |  0.47 us | 25.6348 |     - |     - |  42.03 KB |
|       Get_FlurlAsync |    .NET 4.7.2 | 219.1 us |  4.58 us |  5.09 us | 14.1602 |     - |     - |  23.17 KB |
|      Post_WebRequest |    .NET 4.7.2 | 157.7 us |  1.33 us |  1.24 us |  9.2773 |     - |     - |   15.3 KB |
| Post_HttpClientAsync |    .NET 4.7.2 | 203.2 us |  0.35 us |  0.31 us | 11.4746 |     - |     - |  18.82 KB |
|  Post_WebClientAsync |    .NET 4.7.2 | 209.3 us |  3.93 us |  3.68 us |  9.0332 |     - |     - |  14.85 KB |
|  Post_RestSharpAsync |    .NET 4.7.2 | 220.4 us |  0.37 us |  0.31 us | 26.1230 |     - |     - |  42.48 KB |
|      Post_FlurlAsync |    .NET 4.7.2 | 224.4 us |  0.54 us |  0.51 us | 15.8691 |     - |     - |  25.88 KB |
|       Get_WebRequest | .NET Core 3.1 | 537.6 us | 10.28 us |  9.61 us |  2.9297 |     - |     - |  26.96 KB |
|  Get_HttpClientAsync | .NET Core 3.1 | 152.5 us |  1.16 us |  1.08 us |  0.2441 |     - |     - |   3.74 KB |
|   Get_WebClientAsync | .NET Core 3.1 | 553.6 us |  2.59 us |  2.29 us |  3.9063 |     - |     - |  27.83 KB |
|   Get_RestSharpAsync | .NET Core 3.1 | 615.2 us |  2.69 us |  2.52 us |  6.8359 |     - |     - |  57.68 KB |
|       Get_FlurlAsync | .NET Core 3.1 | 165.7 us |  0.43 us |  0.38 us |  0.7324 |     - |     - |   7.86 KB |
|      Post_WebRequest | .NET Core 3.1 | 536.5 us |  5.26 us |  4.92 us |  3.9063 |     - |     - |  32.33 KB |
| Post_HttpClientAsync | .NET Core 3.1 | 151.4 us |  0.92 us |  0.86 us |  0.2441 |     - |     - |   3.75 KB |
|  Post_WebClientAsync | .NET Core 3.1 | 589.0 us | 11.30 us | 14.29 us |  3.9063 |     - |     - |  31.53 KB |
|  Post_RestSharpAsync | .NET Core 3.1 | 630.2 us |  4.19 us |  3.92 us |  6.8359 |     - |     - |  58.63 KB |
|      Post_FlurlAsync | .NET Core 3.1 | 169.9 us |  0.68 us |  0.63 us |  0.9766 |     - |     - |   8.96 KB |
