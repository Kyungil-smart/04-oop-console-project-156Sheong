using System;
using System.Collections.Generic;
using System.Text;


public class TitleScene : SceneBase
{
    public override void Enter()
    {
        Console.WriteLine("자유는 어디서 오는가?");
        Console.WriteLine();
        Console.WriteLine("체제인가? 공간인가?");
        Console.WriteLine("개인의 신분이나 물질적 풍요인가?");
        Console.WriteLine("아니면 내면의 상태인가?");
        Console.ReadLine();

        SceneManager.ChangeScene("Main");
    }

    public override void Update()
    {

    }

    public override void Render()
    {

    }

    public override void Exit()
    {
        Console.WriteLine("타이틀 씬에서 나갑니다.");    // 기능 작동 확인용 콘솔 출력, 그런데 작동하지 않음
    }
}

