using System;
using System.Collections.Generic;
using System.Text;

// 첫번째 이동 필드 씬
public class FieldScene001 : SceneBase
{
    Random randNumberA = new Random();
    Random randNumberB = new Random();

    int numberA;
    int numberB;
    int numberA1;
    int numberA2;
    int numberB1;
    int numberB2;

    public Tile[,] _field;  // 마을 크기
    // private Player _player;

    // 씬에서 플레이어 소환하는 생성자 람다식
    public FieldScene001()
    {
        CreatMapSize();
        Init(GameManager._player);
    }

    public void CreatMapSize()
    {
        numberA = 10 + randNumberA.Next(0, 5);
        numberB = 12 + randNumberB.Next(0, 6);

        _field = new Tile[numberA, numberB];  // 마을 크기


    }





    public void Init(Player player)
    {
        //_player = player;

        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                Vector pos = new Vector(x, y);
                _field[y, x] = new Tile(pos);
            }
        }
    }

    public void ReCreateMap()
    {
        CreatMapSize();

        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                Vector pos = new Vector(x, y);
                _field[y, x] = new Tile(pos);
            }
        }


        numberA1 = randNumberA.Next(1, numberA / 2);
        numberA2 = randNumberA.Next(1 + numberA / 2, numberA - 1);
        numberB1 = randNumberB.Next(1, numberB / 2);
        numberB2 = randNumberB.Next(1 + numberB / 2, numberB - 1);

        for (int i = 0; i < 3; i++)
        {
            Random randNumberC = new Random();
            Random randNumberD = new Random();
            int numberX = randNumberC.Next(1, numberA - 1);
            int numberY = randNumberD.Next(1, numberA - 1);

            _field[numberX, numberY].OnTileObject = new FuelEvent() { Name = $"Potion{i}" };
        }

        _field[numberA2, numberB1].OnTileObject = new RandomEvent() { Name = "Random01" };
        _field[numberA2, numberB2].OnTileObject = new EnemyEvent() { Name = "Enemy01" };
    }


    public override void Enter()
    {
        ReCreateMap();

        // 사운드 변경
        SoundManager.ChangeBGM(4);

        GameManager._player.Field = _field;
        //GameManager._player.CurrentFuel.Value = 0.5f * GameManager._player.MaxFuel.Value;   // 게임 재시작 이후 연료 넣기 위해 수정

        GameManager._player.MapPosition = new Vector(6, 6);    // 6. 6 위치에서 생성 
        _field[GameManager._player.MapPosition.Y, GameManager._player.MapPosition.X].OnTileObject = GameManager._player;
        GameManager._player.IsActiveControl = true;
        // Console.WriteLine("플레이어 소환");

    }

    public override void Update()
    {
        GameManager._player.Update();
    }

    public override void Render()
    {
        PrintField();
        // PrintFuelGauge();
        GameManager._player.Render();   // 팝업 창 개념이라 나중에 랜더함
    }

    public override void Exit()
    {
        _field[GameManager._player.MapPosition.Y, GameManager._player.MapPosition.X].OnTileObject = null;
        GameManager._player.Field = null;
    }

    private void PrintField()
    {
        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                _field[y, x].Print();
            }
            Console.WriteLine();
        }
    }

    /*
    private void PrintFuelGauge()
    {
        Console.SetCursorPosition(0, _field.GetLength(0));
        _player._fuelGauge.Print(ConsoleColor.Yellow);
        Console.WriteLine();
        _player.Fuel.Value.ToString().Print(ConsoleColor.Yellow);
        Console.Write(" / ");
        _player.MaxFuel.Value.ToString().Print(ConsoleColor.Yellow);
    }
    */

}