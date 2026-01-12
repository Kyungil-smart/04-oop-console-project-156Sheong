using System;
using System.Collections.Generic;
using System.Text;


public class BattleScene001 : SceneBase
{
    public Tile[,] _battleField = new Tile[6, 12];  // 전투 필드 크기

    private PCruiser _pCruiser;

    private bool isPlayerTurn = true;

    public BattleScene001(PCruiser pCruiser) => Init(pCruiser);

    public void Init(PCruiser pCruiser)
    {
        _pCruiser = pCruiser;


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
        _pCruiser.MyField = _battleField;

        _pCruiser.MapPosition = new Vector(0, 2);    
        _battleField[_pCruiser.MapPosition.Y, _pCruiser.MapPosition.X].OnTileObject = _pCruiser;


    }

    public override void Update()
    {
        if()
        {

        }

        _pCruiser.Update();
    }

    public override void Render()
    {
        PrintField();
        _pCruiser.Render();
    }

    public override void Exit()
    {
        _battleField[_pCruiser.MapPosition.Y, _pCruiser.MapPosition.X].OnTileObject = null;
        _pCruiser.MyField = null;
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
