using System;
using System.Collections.Generic;
using System.Text;

// 첫번째 이동 필드 씬
public class FieldScene001 : SceneBase
{
    public Tile[,] _field = new Tile[12, 16];  // 마을 크기
    private Player _player;

    // 씬에서 플레이어 소환하는 생성자 람다식
    public FieldScene001(Player player) => Init(player);

    public void Init(Player player)
    {
        _player = player;

        for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                Vector pos = new Vector(x, y);
                _field[y, x] = new Tile(pos);
            }
        }
    }


    public override void Enter()
    {
        // 사운드 변경
        SoundManager.ChangeBGM(4);

        _player.Field = _field;
        _player.CurrentFuel.Value = 0.5f * _player.MaxFuel.Value;   // 게임 재시작 이후 연료 넣기 위해 수정

        _player.MapPosition = new Vector(4, 4);    // 4.4 위치에서 생성 
        _field[_player.MapPosition.Y, _player.MapPosition.X].OnTileObject = _player;
        _player.IsActiveControl = true;
        // Console.WriteLine("플레이어 소환");

        _field[3, 5].OnTileObject = new FuelEvent() { Name = "Potion01" };
        _field[2, 15].OnTileObject = new FuelEvent() { Name = "Potion02" };
        _field[7, 3].OnTileObject = new FuelEvent() { Name = "Potion03" };
        _field[8, 12].OnTileObject = new RandomEvent() { Name = "Random01" };
        _field[9, 5].OnTileObject = new EnemyEvent() { Name = "Enemy01" };
    }

    public override void Update()
    {
        _player.Update();
    }

    public override void Render()
    {
        PrintField();
        // PrintFuelGauge();
        _player.Render();   // 팝업 창 개념이라 나중에 랜더함
    }

    public override void Exit()
    {
        _field[_player.MapPosition.Y, _player.MapPosition.X].OnTileObject = null;
        _player.Field = null;
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