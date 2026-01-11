using System;
using System.Collections.Generic;
using System.Text;


public struct Tile
{
    // 타일 위에 올라와 있는 오브젝트
    public GameObject OnTileObject { get; set; }

    // 타일 위에 올라서면 발생하야하는 이벤트
    public event Action OnsetpPlayer;

    // 자신의 좌표
    public Vector Position { get; set; }

    public bool HasGameObject => OnTileObject != null;  // => : 오른쪽의 코드가 왼쪽의 매개변수를 받아 실행

    public Tile(Vector position)
    {
        Position = position;
    }


    public void Print()
    {
        // 오브젝트가 있으면 심볼 프린트
        if (HasGameObject)
        {
            OnTileObject.Symbol.Print();
        }
        // 오브젝트 없을 시 프린트
        else
        {
            "🔳".Print();
        }

    }
}

