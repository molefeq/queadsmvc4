using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.Utility
{
    public class DataSourceResult<T> where T : class
    {
        public int Total { get; set; }
        public List<T> Data { get; set; }
    }
}
