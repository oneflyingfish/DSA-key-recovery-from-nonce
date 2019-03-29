using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;

namespace test43
{
    class Program
    {
        /// <summary>
        /// DSA之求解私钥x--43
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SHA1 hash = new SHA1CryptoServiceProvider();  //hash函数
            for (int k = 0;k<=Math.Pow(2,16);k++)
            {
                //r==((g^k mod p) mod q)
                if(r==(BigInteger.ModPow(g,k,p)%q))
                {
                    BigInteger x = (((s *k) - HSH_m) *GCD.exgcdBigInteger(r,q)) % q;
                    //求私钥十六进制串
                    string xToHexString = x.ToString("X").ToLower();
                    //求hash值
                    Byte[] myHSH_x = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(xToHexString.ToString()));
                    //转化成十六进制字符串
                    string myHSH_xToHexString = BitConverter.ToString(myHSH_x).Replace("-", string.Empty).ToLower();
                    //验证是否正确
                    if (myHSH_xToHexString == HSH_x.ToString("X").ToLower().Substring(HSH_x.ToString("X").Count() - myHSH_xToHexString.Length, myHSH_xToHexString.Length))
                    {
                        Console.WriteLine("破译成功：");
                        Console.WriteLine("随机数因子k={0}\n私钥x为:\n(十进制){1}\n(十六进制）0x{2}",k,x.ToString(), myHSH_xToHexString);
                        break;
                    }
                    if(k==Math.Pow(2,16))
                    {
                        Console.WriteLine("破译失败\n");
                        break;
                    }
                }
               
            }

            Console.WriteLine("\n按任意键继续...");
            Console.ReadKey();
        }

        //定义参数, BigInteger用于表示任意大小的有符号整数，为.net扩展数据
        static BigInteger p = BigInteger.Parse("0800000000000000089e1855218a0e7dac38136ffafa72eda7859f2171e25e65eac698c1702578b07dc2a1076da241c76c62d374d8389ea5aeffd3226a0530cc565f3bf6b50929139ebeac04f48c3c84afb796d61e5a4f9a8fda812ab59494232c7d2b4deb50aa18ee9e132bfa85ac4374d7f9091abc3d015efc871a584471bb1",System.Globalization.NumberStyles.HexNumber);
        static BigInteger q = BigInteger.Parse("0f4f47f05794b256174bba6e9b396a7707e563c5b", System.Globalization.NumberStyles.HexNumber);
        static BigInteger g = BigInteger.Parse("05958c9d3898b224b12672c0b98e06c60df923cb8bc999d119458fef538b8fa4046c8db53039db620c094c9fa077ef389b5322a559946a71903f990f1f7e0e025e2d7f7cf494aff1a0470f5b64c36b625a097f1651fe775323556fe00b3608c887892878480e99041be601a62166ca6894bdd41a7054ec89f756ba9fc95302291", System.Globalization.NumberStyles.HexNumber);
        static BigInteger y = BigInteger.Parse("084ad4719d044495496a3201c8ff484feb45b962e7302e56a392aee4abab3e4bdebf2955b4736012f21a08084056b19bcd7fee56048e004e44984e2f411788efdc837a0d2e5abb7b555039fd243ac01f0fb2ed1dec568280ce678e931868d23eb095fde9d3779191b8c0299d6e07bbb283e6633451e535c45513b2d33c99ea17", System.Globalization.NumberStyles.HexNumber);
        static BigInteger r = BigInteger.Parse("0548099063082341131477253921760299949438196259240", System.Globalization.NumberStyles.Number);
        static BigInteger s = BigInteger.Parse("0857042759984254168557880549501802188789837994940", System.Globalization.NumberStyles.Number);
        static BigInteger HSH_m = BigInteger.Parse("0d2d0714f014a9784047eaeccf956520045c45265", System.Globalization.NumberStyles.HexNumber);
        static BigInteger HSH_x = BigInteger.Parse("0954edd5e0afe5542a4adf012611a91912a3ec16", System.Globalization.NumberStyles.HexNumber);

    }
}
