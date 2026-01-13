using System;
using System.Collections.Generic;
using System.Text;


public class EndScene : SceneBase
{
    private MenuList _GameOverMenu;


    public EndScene()
    {
        Init();
    }

    public void Init()
    {

        _GameOverMenu = new MenuList();
        _GameOverMenu.AddMenu("플레이 해주셔서 감사합니다.", QuitGame);
    }


    public override void Enter()
    {
        SoundManager.ChangeBGM(6);
        _GameOverMenu.Reset();

    }


    public override void Update()
    {
        if (InputManager.GetKey(ConsoleKey.Z) ||
        InputManager.GetKey(ConsoleKey.Spacebar) ||
        InputManager.GetKey(ConsoleKey.Enter))
        {
            _GameOverMenu.SelectMenu();
        }
    }

    public override void Render()
    {
        Console.SetCursorPosition(1, 1);
        Console.WriteLine("자유는 어디서 오는가.");
        Console.WriteLine();
        Console.SetCursorPosition(1, 4);
        Console.WriteLine("그것은 견고한 체제도, 광활한 공간도 아니었다.");
        Console.SetCursorPosition(1, 6);
        Console.WriteLine("주어진 신분이나, 손에 쥔 풍요도 아니었다.");
        Console.WriteLine();
        Console.SetCursorPosition(1, 9);
        Console.WriteLine("우리가 찾아 헤맨 자유의 실체는 오직 당신의 내면,");
        Console.SetCursorPosition(1, 11);
        Console.WriteLine("그 숭고한 상태에 존재했다.");
        Console.WriteLine();
        Console.SetCursorPosition(1, 14);
        Console.WriteLine("역사는 당신을 기억할 것이다.");
        Console.SetCursorPosition(5, 17);
        _GameOverMenu.RenderLeft(5, 20);
    }

    public override void Exit()
    {

    }

    public void QuitGame()
    {
        // Console.WriteLine("게임 입장 클릭");
        // SceneManager.ChangeScene("Main");
        GameManager.IsGameRunning = false;
    }

}
