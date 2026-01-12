using System;
using System.Collections.Generic;
using System.Text;


// (int)피해량 공식 = 40 * {공격자.스킬 위력} * ({공격자.공격력} + 1) / ({피격자.방어력} + 1), 1은 분모 0을 방지하기 위함


public class Skill
{
    public int SkillID;

}

public class Warship
{
    // 생성자로 넣어줄 스텟
    protected int BattleID; // 전투 캐릭터 고유 번호, 이건 중첩되면 안됨    
    public int Level { get; set; } = 1;

    protected TeamType TeamType;

    // 실제 값이 저장되는 숨겨진 변수, 자기 자신을 계속 호출하는 무한 루프를 방지하기 위해 추가
    private int _hPCurrent;

    // 함선을 구분하기 위한 기호
    protected virtual int ShipID { get { return 0; } } // 함선 도감 번호
    public virtual string ShipName { get { return "MissingNo."; } }    // 함선 명

    public virtual ShipType ShipType { get { return ShipType.None; } }  // 함선 등급

    // 함선 전투 관련 스텟
    // 부모 클래스는 적용 공식을, 자식 클래스는 실제 데이터를 맡음       

    // 자식 클래스에서 넣어줘야하는 전투 관련 스텟 기준치(abstract로 넣으면 자식 클래스 setter 넣어줘야해서 virtual 로 넣음)
    protected virtual int BaseHPMax { get { return 10; } }
    protected virtual int BaseAtk { get { return 10; } }
    protected virtual int BaseDef { get { return 10; } }
    protected virtual int BaseSpd { get { return 10; } }
    protected virtual Skill[] CharSkill { get; set; }

    // 실제 적용되는 공식 메서드
    // (int 형)`능력치` = `기초 능력치` * `(double 형)루트((`현재 레벨` + 9) / 10)`
    protected int HPMax { get { return (int)(this.BaseHPMax * ((this.Level + 5) / 25)); } }
    protected int AttackPower { get { return (int)(this.BaseAtk * ((this.Level + 5) / 25)); } }
    protected int DefencePower { get { return (int)(this.BaseDef * ((this.Level + 5) / 25)); } }
    protected int BattleSpeed { get { return (int)(this.BaseSpd * ((this.Level + 5) / 25)); } }

    // 생명력 관리용 메서드
    public int HPCurrent    // 현재 생명력, 0보다 작으면 0으로, 최대 생명력 보다 크면 최대 생명력 수치로 자동 변환되어야 함
    {
        get
        { return _hPCurrent; }
        protected set
        {
            if (value < 0)  // 생명력 0보다 작으면 0으로
            { _hPCurrent = 0; }
            else if (value > HPMax)    // 최대 생명력 보다 크면 최대 생명력 수치로
            { _hPCurrent = HPMax; }
            else
            { _hPCurrent = value; }
        }
    }

    // 생성자, 고유 번호랑 레벨, 팀 만 넣어줄 수 있음
    protected Warship(int id, int lv, TeamType teamType)
    {
        // this 안 붙여도 코드는 작동함, 내 객체를 표시하기 위해 명시함
        // 자식 클래스는 오버라이드 해서 포켓몬 클래스가 아닌 자신의 스텟을 가져옴
        this.BattleID = id;
        this.Level = lv;
        this.TeamType = teamType;
        this.HPCurrent = HPMax;  // 생성 시 현재 생명력 = 최대 생명력이 됨
    }

    // 능력치 출력
    public void ShowPokemonStatus()
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"  {ShipName}급 {ShipType.ToString()}  |  Lv.{Level}");
        Console.WriteLine($"  HP: {HPCurrent} / {HPMax}  |  방어력: {DefencePower}");
        Console.WriteLine($"  공격력: {AttackPower}  |  전투 속도: {BattleSpeed}");
        Console.WriteLine("--------------------------------------------------");
    }


    // 피죤투 자식 클래스
    public class Orca : Warship
    {
        /*
        // 내부에서 사용할 밸런스 계수 (사용 안함)
        private const int BaseHP = 83;
        private const int BaseAtkPower = 75;
        private const int BaseDefPower = 72;
        private const int BaseBattleSpd = 101;
        */

        // 자식 클래스 생성자
        public Orca(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 18; } }
        public override string ShipName { get { return "범고래"; } }
        public override ShipType ShipType { get { return ShipType.Corvette; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 40; } }
        protected override int BaseAtk { get { return 40; } }
        protected override int BaseDef { get { return 40; } }
        protected override int BaseSpd { get { return 130; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 깨비드릴조 자식 클래스
    public class Azawakh : Warship
    {
        // 자식 클래스 생성자
        public Azawakh(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 22; } }
        public override string ShipName { get { return "아자와크"; } }
        public override ShipType ShipType { get { return ShipType.Corvette; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 30; } }
        protected override int BaseAtk { get { return 40; } }
        protected override int BaseDef { get { return 40; } }
        protected override int BaseSpd { get { return 140; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 아보크 자식 클래스
    public class Daring : Warship
    {
        // 자식 클래스 생성자
        public Daring(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 24; } }
        public override string ShipName { get { return "데어링"; } }
        public override ShipType ShipType { get { return ShipType.Corvette; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 30; } }
        protected override int BaseAtk { get { return 60; } }
        protected override int BaseDef { get { return 30; } }
        protected override int BaseSpd { get { return 120; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 나인테일
    public class Corsair : Warship
    {
        // 자식 클래스 생성자
        public Corsair(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 26; } }
        public override string ShipName { get { return "커세어"; } }
        public override ShipType ShipType { get { return ShipType.Frigate; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 60; } }
        protected override int BaseAtk { get { return 60; } }
        protected override int BaseDef { get { return 60; } }
        protected override int BaseSpd { get { return 120; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 고지
    public class Dragon : Warship
    {
        // 자식 클래스 생성자
        public Dragon(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 28; } }
        public override string ShipName { get { return "드라군"; } }
        public override ShipType ShipType { get { return ShipType.Frigate; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 70; } }
        protected override int BaseAtk { get { return 50; } }
        protected override int BaseDef { get { return 90; } }
        protected override int BaseSpd { get { return 110; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 라이츄 자식 클래스
    public class Chasseurs : Warship
    {
        /*
        // 내부에서 사용할 밸런스 계수
        private const int BaseHP = 60;
        private const int BaseAtkPower = 90;
        private const int BaseDefPower = 67;
        private const int BaseBattleSpd = 110;
        */

        // 자식 클래스 생성자
        public Chasseurs(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 38; } }
        public override string ShipName { get { return "샤쇠르"; } }
        public override ShipType ShipType { get { return ShipType.Frigate; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 60; } }
        protected override int BaseAtk { get { return 80; } }
        protected override int BaseDef { get { return 55; } }
        protected override int BaseSpd { get { return 120; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 파라섹트
    public class Kinshasa : Warship
    {
        // 자식 클래스 생성자
        public Kinshasa(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 47; } }
        public override string ShipName { get { return "킨샤사"; } }
        public override ShipType ShipType { get { return ShipType.Destroyer; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 90; } }
        protected override int BaseAtk { get { return 70; } }
        protected override int BaseDef { get { return 130; } }
        protected override int BaseSpd { get { return 100; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 페르시온
    public class Tianjin : Warship
    {
        // 자식 클래스 생성자
        public Tianjin(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 53; } }
        public override string ShipName { get { return "텐진"; } }
        public override ShipType ShipType { get { return ShipType.Destroyer; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 95; } }
        protected override int BaseAtk { get { return 120; } }
        protected override int BaseDef { get { return 90; } }
        protected override int BaseSpd { get { return 105; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 골덕
    public class Cairo : Warship
    {
        // 자식 클래스 생성자
        public Cairo(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 55; } }
        public override string ShipName { get { return "카이로"; } }
        public override ShipType ShipType { get { return ShipType.Destroyer; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 80; } }
        protected override int BaseAtk { get { return 90; } }
        protected override int BaseDef { get { return 70; } }
        protected override int BaseSpd { get { return 120; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 윈디
    public class Tokyo : Warship
    {
        // 자식 클래스 생성자
        public Tokyo(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 59; } }
        public override string ShipName { get { return "도쿄"; } }
        public override ShipType ShipType { get { return ShipType.Destroyer; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 130; } }
        protected override int BaseAtk { get { return 80; } }
        protected override int BaseDef { get { return 70; } }
        protected override int BaseSpd { get { return 100; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 후딘
    public class SaoPaulo : Warship
    {
        // 자식 클래스 생성자
        public SaoPaulo(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 65; } }
        public override string ShipName { get { return "상파울루"; } }
        public override ShipType ShipType { get { return ShipType.Cruiser; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 150; } }
        protected override int BaseAtk { get { return 120; } }
        protected override int BaseDef { get { return 120; } }
        protected override int BaseSpd { get { return 80; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 슬리퍼
    public class Benelux : Warship
    {
        // 자식 클래스 생성자
        public Benelux(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 97; } }
        public override string ShipName { get { return "베네룩스"; } }
        public override ShipType ShipType { get { return ShipType.Cruiser; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 110; } }
        protected override int BaseAtk { get { return 160; } }
        protected override int BaseDef { get { return 90; } }
        protected override int BaseSpd { get { return 90; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 또도가스
    public class Texas : Warship
    {
        // 자식 클래스 생성자
        public Texas(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 110; } }
        public override string ShipName { get { return "텍사스"; } }
        public override ShipType ShipType { get { return ShipType.Cruiser; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 160; } }
        protected override int BaseAtk { get { return 140; } }
        protected override int BaseDef { get { return 110; } }
        protected override int BaseSpd { get { return 85; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 아쿠스타
    public class Rajasthan : Warship
    {
        // 자식 클래스 생성자
        public Rajasthan(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 121; } }
        public override string ShipName { get { return "라자스탄"; } }
        public override ShipType ShipType { get { return ShipType.Cruiser; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 200; } }
        protected override int BaseAtk { get { return 100; } }
        protected override int BaseDef { get { return 100; } }
        protected override int BaseSpd { get { return 70; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 켄타로스
    public class Chara : Warship
    {
        // 자식 클래스 생성자
        public Chara(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 128; } }
        public override string ShipName { get { return "차라"; } }
        public override ShipType ShipType { get { return ShipType.Battleship; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 220; } }
        protected override int BaseAtk { get { return 160; } }
        protected override int BaseDef { get { return 140; } }
        protected override int BaseSpd { get { return 65; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 잠만보
    public class Bellatrix : Warship
    {
        // 자식 클래스 생성자
        public Bellatrix(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호, set을 없애 바뀌는 것을 방지
        protected override int ShipID { get { return 143; } }
        public override string ShipName { get { return "벨라트릭스"; } }
        public override ShipType ShipType { get { return ShipType.Battleship; } }

        // 자식 클래스의 스텟, set을 없애 바뀌는 것을 방지
        protected override int BaseHPMax { get { return 180; } }
        protected override int BaseAtk { get { return 240; } }
        protected override int BaseDef { get { return 100; } }
        protected override int BaseSpd { get { return 60; } }
        protected override Skill[] CharSkill { get; set; }
    }

    // 망나뇽
    public class Acrux : Warship
    {
        // 자식 클래스 생성자
        public Acrux(int id, int lv, TeamType teamType) : base(id, lv, teamType)
        {
        }

        // 자식 클래스 포켓몬을 구분하기 위한 기호
        protected override int ShipID { get { return 149; } }
        public override string ShipName { get { return "아르크투루스"; } }
        public override ShipType ShipType { get { return ShipType.Battleship; } }

        // 자식 클래스의 스텟
        protected override int BaseHPMax { get { return 300; } }
        protected override int BaseAtk { get { return 130; } }
        protected override int BaseDef { get { return 110; } }
        protected override int BaseSpd { get { return 50; } }
        protected override Skill[] CharSkill { get; set; }

    }

}

