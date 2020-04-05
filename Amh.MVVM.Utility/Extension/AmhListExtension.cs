using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.Utility.Extension
{
    public static class AmhListExtension
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}
