using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class BaseViewModel<Tkey> where Tkey : struct
    {
        public Tkey Id { get; set; }
        public BaseViewModel(Tkey id)
        {
            Id = id;
        }
    }
}
