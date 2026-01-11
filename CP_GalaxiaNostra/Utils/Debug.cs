using System;
using System.Collections.Generic;
using System.Text;

// 게임 도중 디버그를 표시할 유틸
public static class Debug
{
    public enum LogType
    {
        Normal,
        Warning
    }

    private static List<(LogType type, string text)> LogList
        = new List<(LogType type, string text)>();

    public static void Log(string text)
    {
        LogList.Add((LogType.Normal, text));
    }

    public static void LogWarning(string text)
    {
        LogList.Add((LogType.Warning, text));
    }

    public static void Render()
    {
        foreach ((LogType type, string text) in LogList)
        {
            if (type == LogType.Normal) text.Print();
            else if (type == LogType.Warning) text.Print(ConsoleColor.DarkYellow);
            Console.WriteLine();
        }
    }



}
