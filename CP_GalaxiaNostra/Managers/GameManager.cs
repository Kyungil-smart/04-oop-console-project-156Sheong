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
            Console.ReadLine(); // 테스트용으로 게임 안 꺼지도록 입력 받기
        }
    }


    // 게임시작 시 초기화하는 함수
    private void Init()
    {
        IsGameRunning = true;

        // 특수문자 사용 가능하도록 UTF-16 되도록 선언
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine($"{IsGameRunning} ✳️");   // 게임이 잘 실행되는지 확인하기 위한 임시 콘솔

        // 키 초기화 로직(씬 전환 시 입력치가 눌린 것을 초기화)

        // 플레이어 생성
        _player = new Player();

        // 배경음 불러오기
        SoundManager.RunningBGM();

        // 각종 씬 불러오기

        // 시작은 인트로 씬으로 하도록
        // 인트로 씬에서 Timer or Delay 등 함수 사용 

        // 인트로 씬 끝난 후 타이틀 씬으로 전환되도록 함

    }

}

