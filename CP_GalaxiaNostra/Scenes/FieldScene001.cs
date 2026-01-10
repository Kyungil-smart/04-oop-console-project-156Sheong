using System;
using System.Collections.Generic;
using System.Text;

// 첫번째 이동 필드 씬
public class FieldScene001 : SceneBase
{
    private Tile[,] _field = new Tile[16, 16];
    private Player _player;

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
        _player.Field = _field;

        _player.Position = new Vector(3, 3);
        _field[_player.Position.Y, _player.Position.X].OnTileObject = _player;
    }

    public override void Update()
    {

    }

    public override void Render()
    {

    }

    public override void Exit()
    {

    }
}