using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp.CommonType;

namespace WpfApp.Utility
{
    public class VideoApp
    {
        public string GetpicFromvideo(string videoName, string widthAndHeight, string cutTimeFrame, bool isNew)
        {
            string vidName = videoName.Substring(videoName.LastIndexOf("\\") + 1);
            string fileName = Path.GetFileNameWithoutExtension(vidName);
            string ffmpeg = ConstDefine.FFmpegExeContainPath;
            if (!File.Exists(ffmpeg))
            {
                HandyControl.Controls.MessageBox.Warning("ffmpeg 不存在!");
                return string.Empty;
            }

            string outputFileName = fileName + ".jpg";
            string dirPath = System.IO.Directory.GetCurrentDirectory() + "\\Covers";
            string curPath = dirPath + "\\" + outputFileName;
            if (File.Exists(curPath) && !isNew)
            {
                return curPath;
            }

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var startInfo = new ProcessStartInfo(ffmpeg);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = " -i " + videoName + " -y -f image2 -ss " + cutTimeFrame + " -t 0.001 -s " + widthAndHeight + " " + curPath;
            startInfo.UseShellExecute = true; // ffmpeg不停止
            startInfo.CreateNoWindow = false;
            try
            {
                Process.Start(startInfo); // 需要等待完成
                return curPath;
            }
            catch (Exception re)
            {
                throw new Exception("Exception:" + re.ToString());
            }
        }
    }
}
