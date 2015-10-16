using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace H.Core.Utility
{
    /// <summary>
    /// 文件监控
    /// </summary>
    public class FileSystemWatcherManager
    {
        private System.IO.FileSystemWatcher _watcher;
        private readonly object _lockObj = new object();
        private string folder;

        /// <summary>
        /// 监控问价夹名称
        /// </summary>
        /// <param name="_folder"></param>
        public FileSystemWatcherManager(string _folder)
        {
            folder = _folder;
        }
        /// <summary>
        /// 设置Config监控
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="path"></param>
        public void SetupWacher()
        {
            if (_watcher == null)
            {
                lock (_lockObj)
                {
                    if (_watcher == null)
                    {
                        _watcher = new System.IO.FileSystemWatcher(System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, folder));
                        _watcher.Filter = "*.*";
                        _watcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;

                        _watcher.EnableRaisingEvents = true;
                        _watcher.Changed += new System.IO.FileSystemEventHandler(_watcher_Changed);
                    }
                }
            }
        }

        void _watcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                HttpRuntime.UnloadAppDomain();
            }
            catch
            {

            }
        }
    }
}
