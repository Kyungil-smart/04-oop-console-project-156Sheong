using System;
using System.Collections.Generic;
using System.Text;

// 게임 씬을 관리해줄 매니저
public static class SceneManager
{
    // 이전 씬과 현재 씬에 대한 변수
    public static SceneBase Current { get; private set; }
    private static SceneBase _prev;

    private static Dictionary<string, SceneBase> _scenes = new Dictionary<string, SceneBase>();

    // 씬을 추가하는 함수
    public static void AddScene(string key, SceneBase scene)
    {
        // 이미 씬이 들어있으면 리턴
        if (_scenes.ContainsKey(key)) return;

        _scenes.Add(key, scene);
    }

}
