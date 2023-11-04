using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HandySubtitler
{
    [Serializable]
    public class SubLineData
    {
        public int FrameIndex { get; set; }
        public string SubtitleText { get; set; }
    }
}
