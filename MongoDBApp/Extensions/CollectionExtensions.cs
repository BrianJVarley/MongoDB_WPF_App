using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Extensions
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerableResult)
        {
            return new ObservableCollection<T>(enumerableResult);
        }

        public static string ToString<T>(this IList<T> list)
        {
            return string.Join(", ", list);
        }

    }
}
