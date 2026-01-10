using System;
using System.Collections.Generic;
using System.Text;

// 메뉴 생성 유틸
public class MenuList
{
    //( , ) 형태의 소괄호는 튜플, 클래스나 구조체 선언 없이 여러 데이터 타입을 하나의 단위로 묶음
    private List<(string text, Action action)> _menus;

    // 현재 인덱스 및 getter 함수
    private int _currentIndex;
    public int CurrentIndex { get => _currentIndex; }

    private Ractangle _outline; // 문자 테두리 밖의 사각형을 만들어주는 기능
    private int _maxLength; // 메뉴에 포함된 모든 텍스트 중 가장 큰 텍스트의 길이를 받아오는 변수


    // 메뉴 리스트 생성하는 함수
    // params 는 메서드 선언 시 가변 길이의 인수를 받을 수 있도록 만드는 역할
    public MenuList(params (string, Action)[] menuTexts)
    {
        // 기존에 메뉴 텍스트가 생성된 게 없다면 생성하기
        if (menuTexts.Length == 0)
        {
            _menus = new List<(string, Action)>();
        }
        // 원본을 복사하여 원본과 독립적인 새로운 List 인스턴스 생성
        else
        {
            _menus = menuTexts.ToList();
        }

        // 메뉴에 포함된 모든 텍스트 중 가장 큰 텍스트의 길이를 받아오는 기능
        for (int i = 0; i < _menus.Count; i++)
        {
            // int textWidth = _menus[i].text.GetTextWidth();   // 문자의 칸수를 일괄 2칸으로 생각하여 주석처리
            int textWidth = 2; // 문자의 칸수는 2칸으로 고정

            if (_maxLength < textWidth)
            {
                _maxLength = textWidth;
            }
        }

        _outline = new Ractangle(width: _maxLength + 4, height: _menus.Count + 2);
    }




    // 메뉴리스트를 생성한 인스턴스에 추가하는 기능
    // 메뉴에 포함된 모든 텍스트 중 가장 큰 텍스트의 길이를 받아오는 기능
    public void AddMenu(string text, Action action)
    {
        _menus.Add((text, action));

        // int textWidth = text.GetTextWidth();
        int textWidth = 2; // 문자의 칸수는 2칸으로 고정

        if (_maxLength < textWidth)
        {
            _maxLength = textWidth;
        }

        _outline.Width = _maxLength + 6;
        _outline.Height++;
    }

    public void RemoveMenu()
    {

    }

    // 메뉴에서 위, 아래, 선택 기능
    public void SelectUp()
    {
        _currentIndex--;
        // 0 보다 작으면 0으로 만들어 범위 밖으로 벗어나지 않게 만들기
        if(_currentIndex < 0) _currentIndex = 0;
    }

    public void SelectDown()
    {
        _currentIndex++;
        if (_currentIndex > _menus.Count) _currentIndex = _menus.Count - 1;
    }
    public void SelectMenu()
    {

    }


    public void Render(int x, int y)

    {
        _outline.X = x;
        _outline.Y = y;
        _outline.Draw();

    }
}

