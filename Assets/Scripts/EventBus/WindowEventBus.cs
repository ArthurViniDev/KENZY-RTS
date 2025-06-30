using System;
using UnityEngine;

public static class WindowEventBus
{
    public static Action<GameObject> OnWindowOpened;
    public static Action<GameObject> OnWindowClosed;

    public static int WindowsOpenedCount = 0;

    public static void OpenWindow(GameObject window)
    {
        if (WindowsOpenedCount == 0)
        {
            WindowsOpenedCount++;
            OnWindowOpened?.Invoke(window);
        }
    }

    public static void CloseWindow(GameObject window)
    {
        if (WindowsOpenedCount > 0)
        {
            WindowsOpenedCount--;
            OnWindowClosed?.Invoke(window);
        }
    }
}
