using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA
{
    public abstract class AService
    {
        protected AModule _module;

        protected AService(AModule module)
        {
            _module = module;
        }
    }
}