using System;
using System.Collections.Generic;
using System.Text;


public class TitleScene : SceneBase
{
    public override void Enter()
    {

        
    }

    public override void Update()
    {
        /*
        // 아무 키나 입력 받으면 메인 씬으로 넘어감
        // https://learn.microsoft.com/ko-kr/dotnet/api/system.console?view=net-8.0
        if (Console.KeyAvailable) SceneManager.ChangeScene("Main");
        */

        // 추후에 종류별 키 묶음을 하고, 아무 키나 입력받으면 넘어가도록 변경 예정
        if (InputManager.GetKey(ConsoleKey.Z) || 
            InputManager.GetKey(ConsoleKey.Spacebar) ||
            InputManager.GetKey(ConsoleKey.Enter))
        {
            SceneManager.ChangeScene("Main");
        }

    }

    public override void Render()
    {
        // 게임 세계관 출력 -> 추후 다른 방법으로 바꿀 예정
        Console.WriteLine("자유는 어디서 오는가?");
        Console.WriteLine();
        Console.WriteLine("체제인가? 공간인가?");
        Console.WriteLine("개인의 신분이나 물질적 풍요인가?");
        Console.WriteLine("아니면 내면의 상태인가?");
    }

    public override void Exit()
    {
        // Console.WriteLine("타이틀 씬에서 나갑니다.");    // 기능 작동 확인용 콘솔 출력
    }
}

