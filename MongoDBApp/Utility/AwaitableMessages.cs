using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Utility
{
    public class AwaitableMessages
    {
        public static Task<T> NextMessageAsync<T>()
        {
            var tcs = new TaskCompletionSource<T>();
            Messenger.Default.Register<T>(null, item => tcs.TrySetResult(item));
            return tcs.Task;
        }
    }
}
