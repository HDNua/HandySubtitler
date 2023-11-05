using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// <summary>
/// 
/// </summary>
namespace HandySubtitler
{
    [Serializable]
    public class SubLineData
    {
        /// <summary>
        /// 프레임 인덱스입니다.
        /// </summary>
        public int FrameIndex { get; set; }
        /// <summary>
        /// 자막 텍스트입니다. (HTML 형식)
        /// </summary>
        public string SubtitleText { get; set; }
    }
}
