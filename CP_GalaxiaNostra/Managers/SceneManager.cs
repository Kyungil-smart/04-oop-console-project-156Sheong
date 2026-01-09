using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

// 게임 씬을 관리해줄 매니저
public static class SceneManager
{
    // Action 은 void 메서드를 참조(캡슐화)할 수 있는 내장 델리게이트(delegate) 타입
    // 메서드 자체를 변수처럼 전달 or 이벤트 처리에 활용하여 코드의 유연성과 재사용성을 높이는 역할
    // 외부에서 씬 전환 시점에 호출할 메서드를 등록할 수 있도록 델리게이트를 만듦
    public static Action OnChangeScene;

    // 이전 씬과 현재 씬에 대한 변수
    public static SceneBase CurrentScene { get; private set; }
    private static SceneBase _prevScene;

    private static Dictionary<string, SceneBase> _scenes = new Dictionary<string, SceneBase>();

    // 씬을 추가하는 함수
    // 동사 + 명사의 형태인 이유는 유니티 LoadScene 같은 명명 규칙을 지키기 위함 (명사 + 동사형은 변수명처럼 보이기도 함)
    public static void AddScene(string keyWord, SceneBase scene)
    {
        // 이미 씬이 들어있으면 리턴
        if (_scenes.ContainsKey(keyWord)) return;

        _scenes.Add(keyWord, scene);
    }

    public static void ChangePrevScene()
    {
        ChangeScene(_prevScene);
    }

    // 씬을 바꾸는 함수 - 외부 접근용
    public static void ChangeScene(string keyWord)
    {
        if (!_scenes.ContainsKey(keyWord)) return;   // 키가 추가되어있지 않다면 리턴 필요

        ChangeScene(_scenes[keyWord]);
    }

    // 씬을 바꾸는 함수 - 내부 사용 용, 오버로딩 사용
    public static void ChangeScene(SceneBase scene)
    {
        SceneBase nextScene = scene;

        if (CurrentScene == nextScene) return;  // 이번 씬과 다음 씬이 동일하면 바꿀 필요가 없으니 리턴

        CurrentScene?.Exit();   // 씬을 바꾸기 위해, 현재 씬이 있다면 Exit 함수 호출
        nextScene.Enter();  // 다음 씬을 바로 Enter 함수 호출

        _prevScene = CurrentScene;
        CurrentScene = nextScene;

        OnChangeScene?.Invoke();    // 씬이 바뀌면 이 델리게이트도 호출됨
    }


    public static void UpdateScene()
    {
        CurrentScene?.Update(); // 현재 상태의 Update 호출
    }

    public static void RenderScene()
    {
        CurrentScene?.Render(); // 현재 상태의 Render 호출
    }
}

