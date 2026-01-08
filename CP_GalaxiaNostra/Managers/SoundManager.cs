using System;
using System.Collections.Generic;
using System.Text;
using WMPLib;

// 게임의 음악을 관리할 매니저
// 게임 전역에 사용되어 편하게 관리하기 위해 static 처리
public static class SoundManager
{
    private static int _volumeBGM = 30;
    public static WindowsMediaPlayer mBGM = new WindowsMediaPlayer();


    // 배경음을 재생하는 함수
    public static void RunningBGM()
    {
        string mp3FilePath = "./Resources/BGM01StarclusterHorizon.mp3"; // (bin/Debug/net10.0) 속에 있는 폴더 속 재생할 음악

        // 파일 확인 여부 탐색
        // https://learn.microsoft.com/ko-kr/dotnet/api/system.io.file.exists?view=net-10.0
        if (!File.Exists(mp3FilePath))
        {
            // 파일이 없으면 콘솔 출력
            Console.WriteLine($"BGM 파일 없음 : {mp3FilePath}");
            return;
        }

        mBGM.URL = mp3FilePath;

        // 초기 볼륨 값 설정
        mBGM.settings.volume = _volumeBGM;

        // 자동 반복 모드 설정
        mBGM.settings.setMode("loop", true);
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
    public static void ChangeBGM()
    {

    }
}

