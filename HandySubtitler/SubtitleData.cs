using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandySubtitler
{
    [Serializable]
    public class SmiData
    {
        #region 필드 및 프로퍼티를 정의합니다.
        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, List<SubLineData>> _smiDict;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, List<SubLineData>> SmiDict
        {
            get { return _smiDict; }
        }


        #endregion










        #region 생성자를 정의합니다.



        #endregion










        #region 메서드를 정의합니다.



        #endregion
    }
}
