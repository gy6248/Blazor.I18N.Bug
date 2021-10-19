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
            FileWatcher = new FileSystemWatcher(WATCHED_PATH);
            Thread = Environment.CurrentManagedThreadId;
            Culture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        }

        public FileSystemWatcher FileWatcher { get; } 

        public FileSystemWatcher SecondWatcher { get; set; }

        public int Thread { get; }

        public string Culture { get; }

        public string CurrentUICulture { get { return CultureInfo.CurrentUICulture.IetfLanguageTag; } }

    }
}
