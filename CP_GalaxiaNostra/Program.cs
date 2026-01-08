/*
게임 프로젝트 개발 시 생각해야할 것
    1. 무슨 게임을 만드는가?
    2. 유저가 보게 될 결과물(화면)은 무엇인가?
    3. 최소 기능들이 무엇이 있는데?
    4. 우선 순위가 무엇인가?


성능 신경 쓰지 말기
    성능 신경 안쓰고 일단 돌아가게 만들면 오히려 다양한 창의적인 아이디어가 나옴


커밋 메세지 예시
	create Project
	~~~ 버그 수정
	~~~ 기능 추가
 */


internal class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.Run();
    }
}



