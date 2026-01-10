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
        // 메뉴에서 방향키 누르면 위 메뉴 이동 / 아래 메뉴 이동 / 메뉴 선택 이 가능하도록
        if(InputManager.GetKey(ConsoleKey.UpArrow))
        {
            _MainMenu.SelectUp();
        }
        if (InputManager.GetKey(ConsoleKey.DownArrow))
        {
            _MainMenu.SelectDown();
        }
        if (InputManager.GetKey(ConsoleKey.Enter))
        {
            _MainMenu.SelectMenu();
        }
    }

    public override void Render()
    {
        Console.SetCursorPosition(5, 1);
        _MainMenu.Render(5, 5);
    }

    public override void Exit()
    {

    }

    // 메인 씬 메뉴의 5개 버튼을 클릭 시 각각 발동하는 
    public void StartNewGame()
    {
        SceneManager.ChangeScene("Field001");
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
