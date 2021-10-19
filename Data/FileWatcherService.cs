using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Blazor.I18N.Bug.Data
{
    public class FileWatcherService
    {
        public const string WATCHED_PATH = @"C:\temp\WatchMe\";

        public FileWatcherService()
        {
            FileWatcher = new FileSystemWatcher(WATCHED_PATH);
        }

        public FileSystemWatcher FileWatcher { get; } 

        public FileSystemWatcher SecondWatcher { get; set; }

    }
}
