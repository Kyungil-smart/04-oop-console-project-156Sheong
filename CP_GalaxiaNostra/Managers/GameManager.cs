using System;
using System.Collections.Generic;
using System.Text;

// 게임의 전체 흐름을 관리할 매니저
public class GameManager
{
    public static bool IsGameRunning {  get; set; }    // 게임 실행 여부를 구분하는 전역 변수, 사용하기 쉽게 public 으로 열어둠

    // 게임을 실행하는 함수
    public void Run()
    {
        // 게임 시작 전 초기화
        Init();

        //게임 루틴 가동
        while(IsGameRunning)
        {

        }
    }


    // 게임시작 시 초기화하는 함수
    private void Init()
    {
        IsGameRunning = true;


        Console.WriteLine(IsGameRunning);   // 게임이 잘 실행되는지 확인하기 위한 임시 콘솔 
    }

}

