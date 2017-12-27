using System;
using System.Collections.Specialized;
using System.Collections;
using OY.TotalCommander.TcPluginInterface;
using OY.TotalCommander.TcPluginInterface.Lister;
using System.IO;

namespace MarkdownViewer
{
    public class MarkdownViewer : ListerPlugin
    {

        public const String AllowedExtensions = ".md,.markdown";

        public MarkdownViewer(StringDictionary pluginSettings) : base(pluginSettings)
        {

            if (String.IsNullOrEmpty(Title))
            {
                Title = "Markdown Viewer";
            }

            DetectString = "EXT=\"MD\"";

        }

        private ArrayList controls = new ArrayList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileToLoad"></param>
        /// <param name="showFlags"></param>
        /// <returns></returns>
        public override object Load(string fileToLoad, ShowFlags showFlags)
        {
            ViewerControl viewerControl = null;
            if (!String.IsNullOrEmpty(fileToLoad))
            {

                String ext = Path.GetExtension(fileToLoad);
                // 如果文件扩展名不在支持之列则直接返回
                if (AllowedExtensions.IndexOf(ext, StringComparison.InvariantCultureIgnoreCase) < 0)
                {
                    return null;
                }

                viewerControl = new ViewerControl();
                viewerControl.FileLoad(fileToLoad);

                controls.Add(viewerControl);
            }

            return viewerControl;
        }
        //Added 1.0.0.1
        public override void CloseWindow(object control)
        {
            controls.Remove(control);
        }
        
        //Added 1.0.0.1 as dummy
        public override int NotificationReceived(object control, int message, int wParam, int lParam)
        {
            // do nothing
            return 0;
        }
        
        //Added 1.0.0.1 as dummy
        public override ListerResult SendCommand(object control, ListerCommand command, ShowFlags parameter)
        {
           
            return ListerResult.OK;
        }
    }

}
