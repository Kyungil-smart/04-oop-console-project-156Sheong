using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;


public class CombatManager
{
    private List<Warship> allShips = new List<Warship>();
    int nowTurn;
    int aliveAllyShipCount;
    int aliveEnemyShipCount;

    public void EnterInit(Player player, Player[] enemyPlayers, Tile[,] battleTile)
    {
        // 이전 전투 관련 클리어
        allShips.Clear();
        nowTurn = 0;
        aliveAllyShipCount = 0;
        aliveEnemyShipCount = 0;

        // 아군 군함 위치 넣기
        int playerPosX = 0;
        foreach (Warship ship in player.shipOwned)
        {
            // 생존한 군함 넣기
            if (ship != null && ship.IsAlive == true)
            {
                ship.BattlePosition = playerPosX;
                allShips.Add(ship);
                playerPosX += 1;
                aliveAllyShipCount += 1;
            }
        }

        // 적군 군함 위치 넣기
        int enemyPosX = battleTile.GetLength(1);   // 전투 맵의 X 축만 넣기
        for (int i = 0; i < enemyPlayers.Length; i++)
        {
            foreach (Warship ship in enemyPlayers[i].shipOwned)
            {
                if (ship != null && ship.IsAlive == true)
                {
                    ship.BattlePosition = enemyPosX;
                    allShips.Add(ship);
                    enemyPosX -= 1;
                    aliveEnemyShipCount += 1;
                }
            }
        }

        allShips.Sort((x, y) => y.BattleSpeed.CompareTo(x.BattleSpeed));    //  https://stackoverflow.com/questions/66182228/how-does-this-sortx-y-x-comparetoy-work
    }

    public void UpdateTurn()
    {
        allShips.Sort((x, y) => y.BattleSpeed.CompareTo(x.BattleSpeed));

        foreach (var attacker in allShips)
        {
            // 이미 죽은 배는 공격 못 함
            if (!attacker.IsAlive) continue;

            // 가장 가까운 상대 팀 함선 찾기
            Warship target = FindClosestTarget(attacker);

            if (target != null)
            {
                AttackTarget(attacker, target);
            }
        }

        // 이거 있어야 생존, 죽음 업데이트 가능
        aliveAllyShipCount = 0;
        aliveEnemyShipCount = 0;

        for (int j = 0; j < allShips.Count; j++)
        {
            if (allShips[j].IsAlive && allShips[j].MyTeamType == TeamType.Player)
            {
                aliveAllyShipCount++;
            }
            else if (allShips[j].IsAlive && allShips[j].MyTeamType != TeamType.Player)
            {
                aliveEnemyShipCount++;
            }
        }

        // 승리 와 패배 로직

        if (aliveAllyShipCount <= 0)
        {
            Defeat();
        }
        else if (aliveEnemyShipCount <= 0)
        {

            Victory();
        }



    }


    private Warship FindClosestTarget(Warship attacker)
    {
        Warship realTarget = null;
        int minDistance = 99; // 임의의 값으로 초기화

        foreach (Warship potenTarget in allShips)
        {
            // 포텐 타겟이 살아있고, 내 팀이 아니면 대상이 됨 (추후에 중립 추가될 수 있으니, 수정이 필요할 수 있음)
            if (potenTarget.IsAlive && attacker.MyTeamType != potenTarget.MyTeamType)
            {
                // 거리라 절대값으로 해야함
                int newDistance = Math.Abs(attacker.BattlePosition - potenTarget.BattlePosition);  // https://learn.microsoft.com/ko-kr/dotnet/api/system.math.abs?view=net-9.0

                // 새 거리가 기존의 거리보다 짧으면 그 짧은 거리를 가진 타겟이 새 타겟이 됨
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    realTarget = potenTarget;
                }
            }
        }
        return realTarget;
    }


    // 데미지 계산 함수
    private void AttackTarget(Warship attacker, Warship target)
    {

        // (int)피해량 공식 = 40 * {공격자.스킬 위력} * ({공격자.공격력} + 1) / ({피격자.방어력} + 1), 1은 분모 0을 방지하기 위함
        int finalDMG = (int)(40 * attacker.CharSkill.SkillPower * (attacker.AttackPower + 1f) / (target.DefencePower + 1f));

        Debug.Log($"{attacker.ShipName}의 공격 -> {target.ShipName}가 피격 | 거리: {Math.Abs(attacker.BattlePosition - target.BattlePosition)}");

        target.TakeDamage(finalDMG);
    }




    // 승리 매서드
    public void Victory()
    {
        SceneManager.ChangeScene("Field001");
    }

    // 패배 매서드
    public void Defeat()
    {
        SceneManager.ChangeScene("GameOver");
    }
}


