using System;
using System.Collections.Generic;
using System.Text;
using static Warship;

// 게임의 캐릭터가 가질 능력치를 관리하는 데이터

public class YouPlayer : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.Player;   // ShowTrainerStatus() 오버라이드 하기 위해 필요
    protected override Warship[] pokemonOwned { get; set; } = new Warship[6];   // ShowTrainerStatus() 오버라이드 하기 위해 필요

    public YouPlayer(int id, string name) : base(id, name)
    {
        // 생성 시 포켓몬 6마리 자동 생성
        pokemonOwned[0] = new Corsair(1001, 1, TeamType.Player);
        pokemonOwned[1] = new Kinshasa(1005, 1, TeamType.Player);
        pokemonOwned[2] = new Tianjin(1003, 1, TeamType.Player);
        pokemonOwned[3] = new SaoPaulo(1004, 1, TeamType.Player);
        pokemonOwned[4] = new Rajasthan(1002, 1, TeamType.Player);
        pokemonOwned[5] = new Acrux(1006, 1, TeamType.Player);
    }

}

public class PlayerEnemy001 : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.EnemyTeam01;
    protected override Warship[] pokemonOwned { get; set; } = new Warship[3];

    public PlayerEnemy001(int id, string name) : base(id, name)
    {
        // 생성 시 포켓몬 3마리 자동 생성
        pokemonOwned[0] = new Orca(3001,18, TeamType.EnemyTeam01);
        pokemonOwned[1] = new Azawakh(3002, 1, TeamType.EnemyTeam01);
        pokemonOwned[2] = new Daring(3003, 1, TeamType.EnemyTeam01);
    }
}

public class PlayerEnemy002 : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.EnemyTeam01;
    protected override Warship[] pokemonOwned { get; set; } = new Warship[3];

    public PlayerEnemy002(int id, string name) : base(id, name)
    {
        TeamType = TeamType.EnemyTeam01;
        // 생성 시 포켓몬 3마리 자동 생성
        pokemonOwned[0] = new Daring(3001, 1, TeamType.EnemyTeam01);
        pokemonOwned[1] = new Dragon(3002, 1, TeamType.EnemyTeam01);
        pokemonOwned[2] = new Tianjin(3003, 1, TeamType.EnemyTeam01);
    }
}

public class PlayerEnemy003 : Player
{
    protected override TeamType TeamType { get; set; } = TeamType.EnemyTeam01;
    protected override Warship[] pokemonOwned { get; set; } = new Warship[3];

    public PlayerEnemy003(int id, string name) : base(id, name)
    {
        TeamType = TeamType.EnemyTeam01;
        // 생성 시 포켓몬 6마리 자동 생성
        pokemonOwned[0] = new Corsair(3001, 1, TeamType.EnemyTeam01);
        pokemonOwned[1] = new Tokyo(3002, 1, TeamType.EnemyTeam01);
        pokemonOwned[2] = new Benelux(3003, 1, TeamType.EnemyTeam01);
    }
}


public class PlayerDatas
{

}

