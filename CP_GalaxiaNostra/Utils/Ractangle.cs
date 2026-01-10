using System;
using System.Collections.Generic;
using System.Text;


// 메뉴의 사각형을 만들어줄 구조체
public struct Ractangle
{
    public int X;
    public int Y;
    public int Width;
    public int Height;

    public Ractangle(int x = 0, int y = 0, int width = 2, int height = 2)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public void Draw()
    {
        if(Width < 2 || Height < 2) return;

        int buffWidth = Console.BufferWidth;
        int buffHeight = Console.BufferHeight;

        // 0 ~ 크기에 해당되지 않으면 안 그리는 기능
        if (X < 0 || Y < 0) return;
        if (X >= buffWidth || Y >= buffHeight) return;
        if (X + Width - 1 >= buffWidth) return;
        if (Y + Height - 1 >= buffHeight) return;

        // 사각형의 맨 윗 테두리 출력
        Console.SetCursorPosition(X, Y);
        for(int i = 0; i < Width; i += 1)
        {
            if (i == 0 || i == Width - 1) "🔸".Print();
            else "🔹".Print();
        }

        // 사각형의 중간 테두리 출력
        for (int i = 1; i < Height - 1; i += 1)
        {
            Console.SetCursorPosition(X, Y + i);    // 세로 왼쪽 테두리
            "🔹".Print();

            for (int j = 1; j < Width - 1; j += 1)  // 가로
            {
                Console.SetCursorPosition(X + (j * 2), Y + i);  // 2칸 문자라 j 좌표 * 2 해줘야 정상 출력됨
                "  ".Print();
            }

            Console.SetCursorPosition(X + ((Width - 1) * 2), Y + i);    // 세로 오른쪽 테두리
            "🔹".Print();
        }

        // 사각형의 맨 아래 테두리 출력
        Console.SetCursorPosition(X, Y + Height - 1);
        for (int i = 0; i < Width; i += 1)
        {
            if (i == 0 || i == Width - 1) "🔸".Print();
            else "🔹".Print();
        }
    }
}

