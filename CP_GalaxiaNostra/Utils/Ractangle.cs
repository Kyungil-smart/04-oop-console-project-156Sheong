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

    }
}

