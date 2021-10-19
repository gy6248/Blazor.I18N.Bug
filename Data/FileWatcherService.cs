using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Blazor.I18N.Bug.Data
{
    public class FileWatcherService
    {
        public const string WATCHED_PATH = @"C:\temp\WatchMe\";

        public FileWatcherService()
        {
            // Instantiated once, CurrentUICulture is "frozen" for this instance
            FileWatcher = new FileSystemWatcher(WATCHED_PATH);
        }
       
        public FileSystemWatcher FileWatcher { get; } 

        public FileSystemWatcher SecondWatcher { get; set; }

    }
}
