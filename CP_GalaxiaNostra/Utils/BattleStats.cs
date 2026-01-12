using System;
using System.Collections.Generic;
using System.Text;


public class BattleStats
{
    // 전투 공격 관련 스텟
    public ObservableProperty<float> AttackPower;
    public ObservableProperty<float> PenetrationPower;
    public ObservableProperty<float> AccuracyRate;

    // 방어 관련 스텟
    public ObservableProperty<float> DefensePower;
    public ObservableProperty<float> InterceptionRate;

}

