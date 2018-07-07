using System;
using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.Utility
{
    public class ModelStateException : Exception
    {
        public List<ModelStateError> ModelErrors { get; set; }

        public ModelStateException()
            : base()
        {
            ModelErrors = new List<ModelStateError>();
        }

        public ModelStateException(string strBindError)
            : base(strBindError)
        {
            ModelErrors = new List<ModelStateError>();
        }
    }
}
