using System;
using System.Collections.Generic;
using System.Text;

public enum TeamType
{
    None = 0,
    Player = 10,
    PlayerNPC = 11,
    NeturalFriendly = 20,
    NeturalHostile = 21,
    EnemyTeam01 = 30,
    EnemyTeam02 = 31,
    EnemyTeam03 = 33

}

public enum ShipType
{
    None = 0,
    Spacecraft = 1,
    Corvette = 2,
    Frigate = 3,
    Destroyer = 4,
    Cruiser = 5,    // 순양함
    Battleship = 6,
    Dreadnought = 7,    // 초중전함

    EscortCarrier = 15, // 순양함급 항공모함
    LightCarrier = 16,
    FleetCarrier = 17,  // 초중전함급 항공모함
    LargeCarrier = 18,
    SuperCarrier = 19,

    Mothership = 20,
    StarFortress = 21,
    PlanemoSanctuary = 22
}


internal class GameDatas
{
}

