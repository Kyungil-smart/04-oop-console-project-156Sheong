using System;
using System.Collections.Generic;
using System.Text;
using WMPLib;
using static System.Runtime.InteropServices.JavaScript.JSType;

// 게임의 음악을 관리할 매니저
// 게임 전역에 사용되어 편하게 관리하기 위해 static 처리
// 현재는 배경음만 사용하는데, 효과음도 사용할 예정이라면 static 처리를 제거하고 BGM용 객체, SE용 객체를 따로 만들어야 할 수도 있음
public static class SoundManager
{
    private static int _volumeBGM = 30;
    public static WindowsMediaPlayer mBGM = new WindowsMediaPlayer();
    private static List<string> mp3FilePath = new List<string>();

    // 배경음을 재생하는 함수
    public static void RunningBGM(int numBGM)
    {
        // 추후에 각 음악을 객체화하고, 객체 속성으로 음악의 사용처를 넣은 다음, 특정 상황에서 특정 음악이 나오도록 변경할 예정
        mp3FilePath.Add("");    // 0번은 결번
        mp3FilePath.Add("./Resources/BGM01StarclusterHorizon.mp3");  // 'bin/Debug/net10.0' 내부에 있는 경로 속 재생할 음악
        mp3FilePath.Add("./Resources/BGM02MaidenVoyage.mp3");    // net10.0 폴더 앞의 경로로 가면 에러남
        
        // 필드 용 음악
        mp3FilePath.Add("./Resources/BGM03SmoothStart.mp3");
        mp3FilePath.Add("./Resources/BGM04ToDeepSpace.mp3");
        mp3FilePath.Add("./Resources/BGM05StarclusterVoyager.mp3"); // 30초 가량의 짦은 음악이라 사용 주의 필요
        mp3FilePath.Add("./Resources/BGM06VoyageIntoTheUnknown.mp3");

        // 전투 용 음악
        mp3FilePath.Add("./Resources/BGM07AmbushintheGlobularCluster.mp3");
        mp3FilePath.Add("./Resources/BGM08EnemyFleetEngagement.mp3.mp3");
        mp3FilePath.Add("./Resources/BGM09AcrobaticCombat.mp3.mp3");
        mp3FilePath.Add("./Resources/BGM10BattleFormation.mp3");
        mp3FilePath.Add("./Resources/BGM11DreadnoughtCommander.mp3");

        // 게임 오버 용 음악
        mp3FilePath.Add("./Resources/BGM12LastBeaconFades.mp3");






        // 재생 범위보다 큰 값 입력 받으면 콘솔 출력 후 리턴
        if (numBGM >= mp3FilePath.Count)
        {
            Console.WriteLine($"BGM 파일 범위를 벗어남, 가능 번호 : 0 ~ {mp3FilePath.Count - 1}");
            return;
        }

        // 파일 확인 여부 탐색
        // https://learn.microsoft.com/ko-kr/dotnet/api/system.io.file.exists?view=net-10.0
        if (!File.Exists(mp3FilePath[numBGM]))
        {
            // 파일이 없으면 콘솔 출력
            Console.WriteLine($"BGM 파일 없음 : {mp3FilePath[numBGM]}");
            return;
        }

        mBGM.URL = mp3FilePath[numBGM];

        // 초기 볼륨 값 설정
        mBGM.settings.volume = _volumeBGM;

        // 자동 반복 모드 설정
        // https://learn.microsoft.com/ko-kr/previous-versions/windows/desktop/wmp/wmplibiwmpsettings-iwmpsettings-setmode--vb-and-c
        mBGM.settings.setMode("loop", true);

        // 배경음 재생 시작
        // https://learn.microsoft.com/en-us/previous-versions/windows/desktop/wmp/controls-object
        mBGM.controls.play();
    }

    // 배경음 볼륨 값을 수정하는 함수
    public static void ChangeVolume(int volumeSize)
    {
        // 볼륨 값 수정
        _volumeBGM += volumeSize;

        // 볼륨 100 이상일 시 100으로
        if (_volumeBGM > 100)
        {
            _volumeBGM = 100;
        }
        // 볼륨 0 이하일 시 0으로
        else if (_volumeBGM < 0)
        {
            _volumeBGM = 0;
        }
        // 볼륨 값 적용
        mBGM.settings.volume = _volumeBGM;

    }

    // 배경음을 변경하는 함수
    public static void ChangeBGM(int numBGM)
    {
        // 재생 범위보다 큰 값 입력 받으면 콘솔 출력 후 리턴
        if (numBGM >= mp3FilePath.Count)
        {
            Console.WriteLine($"BGM 파일 범위를 벗어남, 가능 번호 : 0 ~ {mp3FilePath.Count - 1}");
            return;
        }

        // 이전 음악 재생 멈추고, 다음 음악 재생
        mBGM.controls.stop();   
        mBGM.URL = mp3FilePath[numBGM];
        mBGM.controls.play();
    }
}

