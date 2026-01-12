using System;
using System.Collections.Generic;
using System.Text;

// 필드 맵을 돌아다닐 플레이어, 전투 맵에는 등장 X
public class Player : GameObject
{

    public float _maxFuel = 40;
    public float _currentFuel;

    public ObservableProperty<float> CurrentFuel;
    public ObservableProperty<float> MaxFuel;
    ObservableProperty<float> CurrentFuelRate;
    public string _fuelGauge;



    public Tile[,] Field { get; set; }
    private Inventory _inventory;
    public bool IsActiveControl { get; private set; }

    // 생성자 람다식
    public Player() => Init();


    // 생성자에서 초기화할 목록을 넣는 함수
    public void Init()
    {
        _currentFuel = 0.5f * _maxFuel;
        CurrentFuel = new ObservableProperty<float>(_currentFuel);
        MaxFuel = new ObservableProperty<float>(_maxFuel);
        CurrentFuelRate = new ObservableProperty<float>(_currentFuel  / _maxFuel);


        Symbol = "🔹";
        IsActiveControl = true;
        CurrentFuelRate.AddListener(SetFuelGauge);
        _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8🔲🔲🔲🔲🔲";
        _inventory = new Inventory(this);

    }

    public void Update()
    {

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

        if(CurrentFuel.Value <= 0)
        {
            CurrentFuel.Value = 0;
            SceneManager.ChangeScene("GameOver");
        }
    }


    public void HandleControl()
    {
        /*
        _inventory.IsActive = !_inventory.IsActive;
        IsActiveControl = !_inventory.IsActive;

        Debug.LogWarning($"{_inventory._itemMenu.CurrentIndex}");
        */
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
        /*
        if()
        {
            return;
        }
        */

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

        // 연료 -1
        CurrentFuel.Value -= 1;
    }

    public void Render()
    {
        DrawFuelGauge();
        _inventory.Render();
    }


    public void AddItem(Item item)
    {

        _inventory.AddItem(item);
    }

    
    private void DrawFuelGauge()
    {
        /*
        Console.SetCursorPosition(0, 20);
        _fuelGauge.Print(ConsoleColor.Yellow);
        */

        Console.SetCursorPosition(0, 12);
        Console.WriteLine();
        CurrentFuel.Value.ToString().Print(ConsoleColor.Yellow);
        Console.Write(" / ");
        MaxFuel.Value.ToString().Print(ConsoleColor.Yellow);

    }
    

    public void SetFuelGauge(float _currentFuelRate)
    {
        /*
        switch (_currentFuelRate)
        {
            case > 0.9f:
                //"■■■■■".Print(ConsoleColor.Green);
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8";
                break;
            case > 0.8f:
                //"■■■■□".Print(ConsoleColor.Green);
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8🔲";
                break;
            case > 0.7f:
                //"■■■■□".Print(ConsoleColor.Green);
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8🔲🔲";
                break;
            case > 0.6f:
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8🔲🔲🔲";
                break;
            case > 0.5f:
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8🔲🔲🔲🔲";
                break;
            case > 0.4f:
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8🔲🔲🔲🔲🔲";
                break;
            case > 0.3f:
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8\U0001f7e8🔲🔲🔲🔲🔲🔲";
                break;
            case > 0.2f:
                _fuelGauge = "\U0001f7e8\U0001f7e8\U0001f7e8🔲🔲🔲🔲🔲🔲🔲";
                break;
            case > 0.1f:
                _fuelGauge = "\U0001f7e8\U0001f7e8🔲🔲🔲🔲🔲🔲🔲🔲";
                break;
            case > 0.0f:
                _fuelGauge = "\U0001f7e8🔲🔲🔲🔲🔲🔲🔲🔲🔲";
                break;
        
        }
        */
    }

    public void Heal(float value)
    {
        if(CurrentFuel.Value + value >= _maxFuel)
        {
            CurrentFuel.Value = _maxFuel;
        }
        else
        {
            CurrentFuel.Value += value;
        }
            
        // Debug.Log(_currentFuel.ToString());
    }


    public void Encounter()
    {
        SceneManager.ChangeScene("Battle001");
    }
}

