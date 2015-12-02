using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MongoDBApp.Extensions
{
    static class TaskExtension
    {
        public static async void FireAndLogErrors(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                MessageBox.Show("A task error occurred: " + e.Message, "DB - Task Exception", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
