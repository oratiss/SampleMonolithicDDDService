using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class BaseViewModel<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public BaseViewModel(TKey id)
        {
            Id = id;
        }
    }
}
