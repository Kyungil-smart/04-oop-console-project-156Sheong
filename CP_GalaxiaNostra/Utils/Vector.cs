using System;
using System.Collections.Generic;
using System.Text;

// 맵, 전투에서 좌표를 표현할 벡터
public struct Vector
{
    public int X {  get; set; }
    public int Y { get; set; }

    // 벡터 생성자
    public Vector(int x, int y)
    {
        X = x;
        Y = y; 
    }
}

