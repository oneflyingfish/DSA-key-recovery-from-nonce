using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace test43
{
    public static class GCD
    {

        /// <summary>
        /// 欧几里得算法求解最大公约数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static BigInteger gcdBigInteger(BigInteger x, BigInteger y)
        {
            if (x % y == 0)
            {
                return y;
            }
            return gcdBigInteger(y, x % y);
        }

        /// <summary>
        /// 扩展欧几里得算法求解乘法逆元
        /// a*x+b*y=1 --> (x mod b)*a = 1 mod b  && (y mod a)*b = 1 mod a
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        public static BigInteger exgcdBigInteger(BigInteger value, BigInteger mod)
        {
            return (mod+(exgcdBigInteger_(value, mod) % mod))%mod;
        }

        /// <summary>
        /// 扩展欧几里得算法求解乘法逆元具体实现，不允许被外部调用
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mod"></param>
        /// <returns></returns>
        private static BigInteger exgcdBigInteger_(BigInteger value, BigInteger mod)
        {
            if(gcdBigInteger(value,mod)==0)
            {
                return 0;
            }

            List<BigInteger> coefficientOfValue = new List<BigInteger>();
            for (int i=0;true;i++)
            {
                if(i==0)
                {
                    coefficientOfValue.Add(1);
                }
                else if(i==1)
                {
                    coefficientOfValue.Add(-value / mod * coefficientOfValue[i - 1]);
                }
                else if(i>=2)
                {
                    coefficientOfValue.Add(-value / mod * coefficientOfValue[i - 1]+ coefficientOfValue[i - 2]);
                }

                if(value%mod==1)
                {
                    return coefficientOfValue[i];
                }
                else
                {
                    BigInteger t = value;
                    value = mod;
                    mod = t % mod;
                }
            }
        }
    }
}
