using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.Utility
{
    public class GroupResults<T> where T : class
    {
        public string Key { get; set; }
        public List<T> Models { get; set; }
    }
}
