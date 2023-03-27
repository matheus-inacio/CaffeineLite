using System.Runtime.InteropServices;

public static class Program
{
    public static void Main()
    {
        _ = new Mutex(true, "CaffeineLite", out bool createdNew);
        if (!createdNew) { return; }
        KeystrokeSender.SendKeystrokes();
    }
}

public static class KeystrokeSender
{
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    private const byte F15_VK = 0x7E;
    private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
    private const uint KEYEVENTF_KEYUP = 0x0002;

    public static void SendKeystrokes()
    {
        while (true)
        {
            keybd_event(F15_VK, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
            Thread.Sleep(100);
            keybd_event(F15_VK, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            Thread.Sleep(60000);
        }
    }
}