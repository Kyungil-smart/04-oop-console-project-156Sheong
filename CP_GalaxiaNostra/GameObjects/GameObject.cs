using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

// 모든 게임 오브젝트를 상속할 부모용 추상 오브젝트

public abstract class GameObject
{
    public string Symbol {  get; set; }   // 맵에 나올 심볼
    public Vector MapPosition { get; set; } // 맵에서 가질 백터 좌표
}

