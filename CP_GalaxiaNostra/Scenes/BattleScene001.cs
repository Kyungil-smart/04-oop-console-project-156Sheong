using System;
using System.Collections.Generic;
using System.Text;


public class BattleScene001 : SceneBase
{
    public Tile[,] _battleField = new Tile[6, 12];  // 전투 필드 크기
    Player[] enemyPlayer = new Player[1];

    UIDatas uidData = new UIDatas();
    CombatManager combatManager = new CombatManager();


    public BattleScene001()
    {
        
    }

    public void Init()
    {

        

        for (int y = 0; y < _battleField.GetLength(0); y++)
        {
            for (int x = 0; x < _battleField.GetLength(1); x++)
            {
                Vector pos = new Vector(x, y);
                _battleField[y, x] = new Tile(pos);
            }
        }
    }



    public override void Enter()
    {


        GameManager._player.IsActiveControl = false;

        // 적이 먼저 스폰되어야 오류 안 생김
        if(GameManager._player.battleCount < 4)
        {
            enemyPlayer[0] = new PlayerEnemy001(301, "무명 우주 해적");
        }
        else if(GameManager._player.battleCount < 8)
        {
            enemyPlayer[0] = new PlayerEnemy002(302, "이름난 우주 해적");
        }
        else
        {
            enemyPlayer[0] = new PlayerEnemy003(303, "악명 높은 우주 해적");
        }

        combatManager.EnterInit(GameManager._player, enemyPlayer, _battleField);

        // 사운드 변경
        SoundManager.ChangeBGM(7);

        

    }

    public override void Update()
    {
        combatManager.UpdateTurn();

    }

    public override void Render()
    {
        PrintField();

        GameManager._player.ShowFleetStatus();
        uidData.PrintVSUI();

        // 나중에 복수의 적 함대가 등장할 수도 있음
        foreach (Player p in enemyPlayer)
        {
            if (p is PlayerEnemy001 || p is PlayerEnemy002 || p is PlayerEnemy003)
            {
                p.ShowFleetStatus();
            }
        }
        Console.WriteLine("자동 전투 중 (아무 키나 누르세요.)");
    }

    public override void Exit()
    {

    }

    private void PrintField()
    {
        for (int y = 0; y < _battleField.GetLength(0); y++)
        {
            for (int x = 0; x < _battleField.GetLength(1); x++)
            {
                _battleField[y, x].Print();
            }
            Console.WriteLine();
        }
    }
}
