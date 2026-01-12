using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

// 게임의 전체 흐름을 관리할 매니저
public class GameManager
{
    public static bool IsGameRunning {  get; set; }    // 게임 실행 여부를 구분하는 전역 변수, 사용하기 쉽게 public 으로 열어둠

    private Player _player;

    // 게임을 실행하는 함수
    public void Run()
    {
        // 게임 시작 전 초기화
        Init();

        //게임 루틴 가동
        while(IsGameRunning)
        {
            // 랜더링
            Console.Clear();    // 이전 이미지 제거
            SceneManager.RenderScene();


            // 키 입력 받기
            InputManager.GetUserInput();
            // SoundManager.ChangeBGM(int.Parse(Console.ReadLine())); // 배경음 테스트 용

            if (InputManager.GetKey(ConsoleKey.Tab))
            {
                SceneManager.ChangeScene("Log");
            }


            // 데이터 처리


            SceneManager.UpdateScene(); // 씬 메니저에서 씬 업데이트 하기


            

        }
    }


    // 게임시작 시 초기화하는 함수
    private void Init()
    {
        IsGameRunning = true;

        // 특수문자 사용 가능하도록 UTF-16 되도록 선언
        Console.OutputEncoding = Encoding.Unicode;



        // 키 초기화 로직(씬 전환 시 입력치가 눌린 것을 초기화)
        SceneManager.OnChangeScene += InputManager.ResetKey;


        // 필드 맵에서 돌아다닐 플레이어 인스턴스 생성
        _player = new Player();

        // 배경음 불러오기
        SoundManager.RunningBGM(0);

        // 각종 씬 불러오기
        SceneManager.AddScene("Title", new TitleScene());   // 타이틀 용 씬
        SceneManager.AddScene("Main", new MainScene()); // 메인 메뉴 용 씬

        SceneManager.AddScene("Field001", new FieldScene001(_player)); // 필드 맵 용 씬 3종
        SceneManager.AddScene("Field002", new FieldScene002());
        SceneManager.AddScene("Field003", new FieldScene003());

        SceneManager.AddScene("Battle001", new BattleScene001()); // 전투 맵 용 씬 1종

        SceneManager.AddScene("Log", new LogScene());   // 로그 용 씬

        SceneManager.AddScene("GameOver", new GameOverScene());

        SceneManager.ChangeScene("Title");

        // 시작은 인트로 씬으로 하도록
        // 인트로 씬에서 Timer or Delay 등 함수 사용 

        // 인트로 씬 끝난 후 타이틀 씬으로 전환되도록 함

    }

}

