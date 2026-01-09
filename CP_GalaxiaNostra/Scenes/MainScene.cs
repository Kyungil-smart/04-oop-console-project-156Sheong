using System;
using System.Collections.Generic;
using System.Text;


public class MainScene : SceneBase
{
    private MenuList _MainMenu;

    // 생성자로 메뉴 생성, null 도 방지함
    public MainScene()
    {
        Init();
    }

    public void Init()
    {
        _MainMenu = new MenuList();
        _MainMenu.AddMenu("새 게임", StartNewGame);
        _MainMenu.AddMenu("불러오기", LoadGame);
        _MainMenu.AddMenu("옵션", ViewOption);
        _MainMenu.AddMenu("크레딧", ViewCredits);
        _MainMenu.AddMenu("게임 종료", QuitGame);
    }

    public override void Enter()
    {
        Console.WriteLine("메인 씬에 입장했습니다.");    // 기능 작동 확인용 콘솔 출력
    }

    public override void Update()
    {

    }

    public override void Render()
    {

    }

    public override void Exit()
    {

    }


    public void StartNewGame()
    {

    }
    public void LoadGame()
    {

    }
    public void ViewOption()
    {

    }

    public void ViewCredits()
    {

    }

    public void QuitGame()
    {
        GameManager.IsGameRunning = false;
    }
}
