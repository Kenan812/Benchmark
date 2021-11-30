using System;
using System.Collections.Generic;

#nullable disable

namespace Benchmark.Model
{
    public partial class Result
    {
        public int Id { get; set; }
        public string Resolver { get; set; }
        public long Timing { get; set; }
    }
}
