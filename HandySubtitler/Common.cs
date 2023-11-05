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
    /// <summary>
    /// 
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 인덱스가 지정된 범위 내[v1, v2]에 있는지 확인합니다.
        /// </summary>
        /// <param name="index">범위를 확인할 인덱스입니다.</param>
        /// <param name="v1">범위의 최솟값입니다.</param>
        /// <param name="v2">범위의 최댓값입니다.</param>
        /// <returns>인덱스가 지정된 범위 내[v1, v2]에 있다면 참입니다.</returns>
        public static bool IsIndexInRange(int index, int v1, int v2)
        {
            return (v1 <= index && index <= v2);
        }
        /// <summary>
        /// 범위 내에서 값을 반환합니다.
        /// </summary>
        /// <typeparam name="T">비교 가능한(IComparable) 형식입니다.</typeparam>
        /// <param name="value">사용할 값입니다.</param>
        /// <param name="minValue">최솟값입니다.</param>
        /// <param name="maxValue">최댓값입니다.</param>
        /// <returns>최솟값보다 작으면 최솟값, 최댓값보다 크면 최댓값, 그 외의 경우 원래 값을 반환합니다.</returns>
        public static T Clamp<T>(T value, T minValue, T maxValue) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) < 0) return minValue;
            if (value.CompareTo(maxValue) > 0) return maxValue;
            return value;
        }
    }
}
