using System;
using System.Collections.Generic;
using System.Text;
using static Warship;

// 게임의 캐릭터가 가질 능력치를 관리하는 데이터

public class YouPlayer : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.Player;   // ShowTrainerStatus() 오버라이드 하기 위해 필요
    public override Warship[] shipOwned { get; set; } = new Warship[6];   // ShowTrainerStatus() 오버라이드 하기 위해 필요

    public YouPlayer(int id, string name) : base(id, name)
    {
        // 생성 시 포켓몬 6마리 자동 생성
        shipOwned[0] = new Acrux(1006, 10, TeamType.Player);
        shipOwned[1] = new Rajasthan(1002, 10, TeamType.Player);
        shipOwned[2] = new SaoPaulo(1004, 10, TeamType.Player);
        shipOwned[3] = new Tianjin(1003, 10, TeamType.Player);
        shipOwned[4] = new Kinshasa(1005, 10, TeamType.Player);
        shipOwned[5] = new Corsair(1001, 10, TeamType.Player);
    }

}

public class PlayerEnemy001 : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.EnemyTeam01;
    public override Warship[] shipOwned { get; set; } = new Warship[3];

    public PlayerEnemy001(int id, string name) : base(id, name)
    {
        // 생성 시 포켓몬 3마리 자동 생성
        shipOwned[0] = new Orca(3001, 10, TeamType.EnemyTeam01);
        shipOwned[1] = new Azawakh(3002, 10, TeamType.EnemyTeam01);
        shipOwned[2] = new Daring(3003, 10, TeamType.EnemyTeam01);
    }
}

public class PlayerEnemy002 : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.EnemyTeam01;
    public override Warship[] shipOwned { get; set; } = new Warship[3];

    public PlayerEnemy002(int id, string name) : base(id, name)
    {
        TeamType = TeamType.EnemyTeam01;
        // 생성 시 포켓몬 3마리 자동 생성
        shipOwned[0] = new Daring(3001, 10, TeamType.EnemyTeam01);
        shipOwned[1] = new Dragon(3002, 10, TeamType.EnemyTeam01);
        shipOwned[2] = new Tianjin(3003, 10, TeamType.EnemyTeam01);
    }
}

public class PlayerEnemy003 : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.EnemyTeam01;
    public override Warship[] shipOwned { get; set; } = new Warship[3];

    public PlayerEnemy003(int id, string name) : base(id, name)
    {
        TeamType = TeamType.EnemyTeam01;
        // 생성 시 포켓몬 6마리 자동 생성
        shipOwned[0] = new Corsair(3001, 10, TeamType.EnemyTeam01);
        shipOwned[1] = new Tokyo(3002, 10, TeamType.EnemyTeam01);
        shipOwned[2] = new Benelux(3003, 10, TeamType.EnemyTeam01);
    }
}


public class PlayerDatas
{

}

