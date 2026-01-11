using System;
using System.Collections.Generic;
using System.Text;

public class LogScene : SceneBase
{


    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            SceneManager.ChangePrevScene();
        }
    }

    public override void Render()
    {
        Debug.Render();
    }

    // 아래는 로그 씬에서 사용 안하는 매서드들
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }
}