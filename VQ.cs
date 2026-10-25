using System.Runtime.InteropServices;

namespace VizQuick;

public static class VQ
{
    [DllImport("vq", CallingConvention = CallingConvention.Cdecl, EntryPoint = "vq_parse")]
    private static unsafe extern byte* VQ_Parse(string filePath, out int width, out int height);

    [DllImport("vq", CallingConvention = CallingConvention.Cdecl, EntryPoint = "vq_get_error")]
    private static unsafe extern string VQ_GetError();

    public static byte[] Parse(string filePath, out int width, out int height)
    {
        byte[] byteArray;

        unsafe
        {
            byte* ptr = VQ_Parse(filePath, out width, out height);

            if (ptr == null)
            {
                throw new Exception($"VQ Failed: {VQ_GetError()}");
            }
            else 
            {
                byteArray = new Span<byte>(ptr, width * height * 4).ToArray();
            }
        }

        return byteArray;
    }
}
