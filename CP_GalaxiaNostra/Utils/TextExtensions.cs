using System;
using System.Collections.Generic;
using System.Text;


// 텍스트 확장 기능 유틸
public static class TextExtensions
{
    // 콘솔창에 문자열을 받아 텍스트를 프린트해주는 함수
    public static void Print(this string text, ConsoleColor color = ConsoleColor.Gray)
    {
        // 콘솔 컬러가 회색이 아니면, 입력받은 컬러로 색상을 정함
        if(color != ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
        }

        // 입력받은 텍스트를 출력
        Console.Write(text);

        // 기본 색상이 회색이기에, 회색이 아니라면 텍스트 출력 후 컬러 리셋
        if (color != ConsoleColor.Gray)
        {
            Console.ResetColor();
        }
    }

    // 위의 함수를 오버로딩 받아 char 형을 받아 텍스트를 프린트해주는 함수
    public static void Print(this char character, ConsoleColor color = ConsoleColor.Gray)
    {
        if (color != ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
        }

        Console.Write(character);

        if (color != ConsoleColor.Gray)
        {
            Console.ResetColor();
        }
    }

    // 문자의 칸수를 일괄 2칸으로 생각하여 주석처리
    /*
    // 문자열을 받아서 각 문자열의 문자를 GetCharacterWidth 에 넣었다 문자의 칸수를 리턴하는 함수
    public static int GetTextWidth(this string text)
    {
        int width = 0;
        foreach (char c in text)
        {
            width += c.GetCharacterWidth();
        }
        return width;
    }

    // 문자의 종류에 따라 문자에게 할당되는 칸수를 정하는 함수
    public static int GetCharacterWidth(this char character)
    {
        
        // 한글 음절(가-힣), CJK 호환문자, 전각 기호/문자 범위는 2칸으로 처리
        if ((character >= '\uAC00' && character <= '\uD7A3') || // 한글 완성형
            (character >= '\u1100' && character <= '\u11FF') || // 한글 자모
            (character >= '\u3130' && character <= '\u318F') || // 한글 호환 자모
            (character >= '\uFF01' && character <= '\uFF60') || // 전각 기호/영숫자
            (character >= '\uFFE0' && character <= '\uFFE6'))   // 전각 특수기호
        {
            return 2;
        }
        else
        {
            return 2;
        }
    }
    */
}

