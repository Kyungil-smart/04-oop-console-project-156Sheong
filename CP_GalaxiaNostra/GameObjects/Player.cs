using System;
using System.Collections.Generic;
using System.Text;

// 필드 맵을 돌아다닐 플레이어, 전투 맵에는 등장 X
public class Player : GameObject
{

    private float _maxFuel = 40;
    private float _currentFuel;
    private float _currentFuelRate;

    public ObservableProperty<float> Fuel;
    private string _fuelGauge;



    public Tile[,] Field { get; set; }
    private Inventory _inventory;
    public bool IsActiveControl { get; private set; }

    // 생성자 람다식
    public Player() => Init();


    // 생성자에서 초기화할 목록을 넣는 함수
    public void Init()
    {
        _currentFuel = _maxFuel;
        Fuel = new ObservableProperty<float>(_currentFuel);

        Symbol = "🔹";
        IsActiveControl = true;
        Fuel.AddListener(SetFuelGauge);
        _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8";
        _inventory = new Inventory(this);

    }

    public void Update()
    {
        _currentFuelRate = _currentFuel / _maxFuel;


        Vector direction = new Vector();


        if (InputManager.GetKey(ConsoleKey.UpArrow) || InputManager.GetKey(ConsoleKey.W))
        {
            Move(Vector.Up);
            _inventory.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow) || InputManager.GetKey(ConsoleKey.S))
        {
            Move(Vector.Down);
            _inventory.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.LeftArrow) || InputManager.GetKey(ConsoleKey.A))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow) || InputManager.GetKey(ConsoleKey.D))
        {
            Move(Vector.Right);
        }

        if (InputManager.GetKey(ConsoleKey.Z) || InputManager.GetKey(ConsoleKey.Spacebar) || InputManager.GetKey(ConsoleKey.Enter))
        {
            _inventory.Select();
        }

        if (InputManager.GetKey(ConsoleKey.X) || InputManager.GetKey(ConsoleKey.Escape))
        {
            HandleControl();
        }
    }


    public void HandleControl()
    {
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;
    }

    public void Move(Vector direction)
    {
        if (Field == null || !IsActiveControl) return;

        Vector current = MapPosition;
        Vector nextPos = MapPosition + direction;

        // 예외 처리
        // 맵 배열 크기 확인
        if (nextPos.X < 0 || nextPos.Y < 0 || nextPos.X >= Field.GetLength(1) || nextPos.Y >= Field.GetLength(0))
        {
            return;
        }

        // 장애물인지 확인

        GameObject nextTileObject = Field[nextPos.Y, nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable)
            {
                (nextTileObject as IInteractable).Interact(this);
            }
        }


        Field[MapPosition.Y, MapPosition.X].OnTileObject = null;
        Field[nextPos.Y, nextPos.X].OnTileObject = this;
        MapPosition = nextPos;

    }

                public void Render()
    {
        DrawFuelGauge();
        _inventory.Render();
    }


    public void AddItem(Item item)
    {

        _inventory.Add(item);
    }


    private void DrawFuelGauge()
    {
        if (MapPosition.X - 2 >= 0 && MapPosition.Y - 1 >= 0)
        {
            Console.SetCursorPosition(MapPosition.X - 2, MapPosition.Y - 1);
        }
        
        _fuelGauge.Print(ConsoleColor.Yellow);
    }


    public void SetFuelGauge(float _currentFuelRate)
    {
        switch (_currentFuelRate)
        {
            case > 0.9f:
                //"■■■■■".Print(ConsoleColor.Green);
                _fuelGauge = "🟨🟨\U0001f7e8\U0001f7e8\U0001f7e8";
                break;
            case > 0.8f:
                //"■■■■□".Print(ConsoleColor.Green);
                _fuelGauge = "■ ■ ■ ■ ◧";
                break;
            case > 0.7f:
                //"■■■■□".Print(ConsoleColor.Green);
                _fuelGauge = "■■■■□";
                break;
            case > 0.6f:
                _fuelGauge = "■■■◧□";
                break;
            case > 0.5f:
                _fuelGauge = "■■■□□";
                break;
            case > 0.4f:
                _fuelGauge = "■ ■ ◧ □ □";
                break;
            case > 0.3f:
                _fuelGauge = "■ ■ □ □ □";
                break;
            case > 0.2f:
                _fuelGauge = "■ ◧ □ □ □";
                break;
            case > 0.1f:
                _fuelGauge = "■ □ □ □ □";
                break;
            case > 0.0f:
                _fuelGauge = "◧ □ □ □ □";
                break;
        }

    }

    public void Heal(int value)
    {
        Fuel.Value += value;
    }

}

