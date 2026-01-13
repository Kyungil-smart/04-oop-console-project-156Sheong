using System;
using System.Collections.Generic;
using System.Text;


public class UIDatas
{
    // vs 이미지를 출력하는 함수
    public void PrintVSUI()
    {
        // Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("====================");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("   V  S   ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("====================");
        // Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine();
    }


}

