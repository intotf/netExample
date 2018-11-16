using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt.NetWorking
{
    /// <summary>
    /// 提供utf8编码检测
    /// </summary>
    public static class Utf8Encode
    {
        /// <summary>
        /// 检测字节组是否uft8编码
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        unsafe public static bool IsUtf8(byte[] bytes)
        {
            fixed (byte* pByte = &bytes[0])
            {
                int i = 0;
                var size = bytes.Length;

                while (i < size)
                {
                    int step = 0;
                    if ((pByte[i] & 0x80) == 0x00)
                    {
                        step = 1;
                    }
                    else if ((pByte[i] & 0xe0) == 0xc0)
                    {
                        if (i + 1 >= size)
                        {
                            return false;
                        }
                        if ((pByte[i + 1] & 0xc0) != 0x80)
                        {
                            return false;
                        }
                        step = 2;
                    }
                    else if ((pByte[i] & 0xf0) == 0xe0)
                    {
                        if (i + 2 >= size)
                        {
                            return false;
                        }
                        if ((pByte[i + 1] & 0xc0) != 0x80)
                        {
                            return false;
                        }
                        if ((pByte[i + 2] & 0xc0) != 0x80)
                        {
                            return false;
                        }
                        step = 3;
                    }
                    else
                    {
                        return false;
                    }
                    i += step;
                }

                if (i == size)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
