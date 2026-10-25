using System.Runtime.InteropServices;

namespace VQ.Net;

public static class VQ
{
    [DllImport("vq", CallingConvention = CallingConvention.Cdecl, EntryPoint = "vq_parse")]
    private static unsafe extern byte* VQ_Parse(string filePath, out int width, out int height);

    public static byte[] Parse(string filePath, out int width, out int height)
    {
        byte[] byteArray;

        unsafe
        {
            byte* ptr = VQ_Parse(filePath, out width, out height);
            byteArray = new Span<byte>(ptr, width * height * 4).ToArray();
        }

        return byteArray;
    }
}
