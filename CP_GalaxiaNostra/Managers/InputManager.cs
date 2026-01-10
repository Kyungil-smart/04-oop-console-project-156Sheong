using System;
using System.Collections.Generic;
using System.Text;


public static class InputManager
{
    private static ConsoleKey _currentKey;

    // 게임에서 입력받을 키를 정의
    private static readonly ConsoleKey[] _keys =
    {
        // 이동 키 (상단 키가 기준)
        ConsoleKey.UpArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.LeftArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.W,
        ConsoleKey.S,
        ConsoleKey.A,
        ConsoleKey.D,

        // 확인 키 (상단 키가 기준)
        ConsoleKey.Z,
        ConsoleKey.Spacebar,
        ConsoleKey.Enter,

        // 취소 키
        ConsoleKey.X,
        ConsoleKey.Escape
    };

    /*
    private static HashSet<ConsoleKey> moveKeys = new HashSet<ConsoleKey>
    {
        ConsoleKey.UpArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.LeftArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.W,
        ConsoleKey.S,
        ConsoleKey.A,
        ConsoleKey.D
    };

    private static HashSet<ConsoleKey> selectKey = new HashSet<ConsoleKey>
    {
        ConsoleKey.Z,
        ConsoleKey.Spacebar,
        ConsoleKey.Enter
    };

    private static HashSet<ConsoleKey> cancelKey = new HashSet<ConsoleKey>
    {
        ConsoleKey.X,
        ConsoleKey.Escape
    };

    
    public static void GetKey(HashSet<ConsoleKey> inputKeySet)
    {
        if (moveKeys == inputKeySet)
        {
            return;
        }
        else if (selectKey == inputKeySet)
        {
            return;
        }
        else if (cancelKey == inputKeySet)
        {
            return;
        }
    }
    */

    // 키 입력 받을 시 T / F 리턴 함수
    public static bool GetKey(ConsoleKey inputKey)
    {
        return _currentKey == inputKey;
    }

    public static void GetUserInput()
    {
        ConsoleKey inputKey = Console.ReadKey(true).Key;
        _currentKey = ConsoleKey.Clear; // Clear 으로 입력받은 키 초기화

        // 순회를 돌면서 입력된 키가 유효한지 검사
        foreach (ConsoleKey nowKey in _keys)
        {
            if (inputKey == nowKey)
            {
                _currentKey = inputKey;
                break;  // 찾았으면 더이상 순회돌 필요 없이 브레이크
            }
        }
    }

    public static void ResetKey()
    {
        _currentKey = ConsoleKey.Clear;

    }
}


