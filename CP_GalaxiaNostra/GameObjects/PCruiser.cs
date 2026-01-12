using System;
using System.Collections.Generic;
using System.Text;


public class PCruiser : GameObject
{
    private float _maxHP;
    private float _currentHP;

    private float _attackPower;
    private float _penetrationPower;
    private float _accuracyRate;

    private float _defensePower;
    private float _interceptionRate;

    private float _moveRange;
    private float _attackRange;
    private float _behaviorPriority;


    // 생존 관련 스텟
    public ObservableProperty<float> MaxHP;
    public ObservableProperty<float> CurrentHP;

    // 전투 공격 관련 스텟
    public ObservableProperty<float> AttackPower;
    public ObservableProperty<float> PenetrationPower;
    public ObservableProperty<float> AccuracyRate;

    // 방어 관련 스텟
    public ObservableProperty<float> DefensePower;
    public ObservableProperty<float> InterceptionRate;

    // 이동 및 사거리 관련 스텟
    public ObservableProperty<int> MoveRange;
    public ObservableProperty<int> AttackRange;
    public ObservableProperty<float> BehaviorPriority;


    public Tile[] Field { get; set; }
    private CharacterMenu _charMenu;
    public bool IsActiveControl { get; private set; }

    public PCruiser() => Init();



    public void Init()
    {
        _maxHP = 12;
        MaxHP = new ObservableProperty<float>(_maxHP);
        _currentHP = _maxHP;
        CurrentHP = new ObservableProperty<float>(_currentHP);

        _attackPower = 6;
        MaxHP = new ObservableProperty<float>(_attackPower);
        _penetrationPower = 5;
        MaxHP = new ObservableProperty<float>(_penetrationPower);
        _accuracyRate = 8;
        MaxHP = new ObservableProperty<float>(_accuracyRate);

        _defensePower = 4;
        MaxHP = new ObservableProperty<float>(_defensePower);
        _interceptionRate = 4;
        MaxHP = new ObservableProperty<float>(_interceptionRate);

        _moveRange = 3;
        MaxHP = new ObservableProperty<float>(_moveRange);
        _attackRange = 3;
        MaxHP = new ObservableProperty<float>(_attackRange);
        _behaviorPriority = 6;
        MaxHP = new ObservableProperty<float>(_behaviorPriority);


        Symbol = "🔵";
        IsActiveControl = true;
        MaxHP.AddListener(SetHPGauge);
        _charMenu = new CharacterMenu(this);
    }


    public void Update()
    {
        Vector direction = new Vector();


        if (InputManager.GetKey(ConsoleKey.UpArrow) || 
            InputManager.GetKey(ConsoleKey.W))
        {
            Move(Vector.Up);
            _charMenu.SelectUp();
        }

        if (InputManager.GetKey(ConsoleKey.DownArrow) || 
            InputManager.GetKey(ConsoleKey.S))
        {
            Move(Vector.Down);
            _charMenu.SelectDown();
        }

        if (InputManager.GetKey(ConsoleKey.LeftArrow) || 
            InputManager.GetKey(ConsoleKey.A))
        {
            Move(Vector.Left);
        }

        if (InputManager.GetKey(ConsoleKey.RightArrow) || 
            InputManager.GetKey(ConsoleKey.D))
        {
            Move(Vector.Right);
        }

        if (InputManager.GetKey(ConsoleKey.Z) || 
            InputManager.GetKey(ConsoleKey.Spacebar) || 
            InputManager.GetKey(ConsoleKey.Enter))
        {
            _charMenu.Select();
        }

        if (InputManager.GetKey(ConsoleKey.X) || 
            InputManager.GetKey(ConsoleKey.Escape))
        {
            HandleControl();
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

        GameObject nextTileObject = Field[nextPos.X].OnTileObject;

        if (nextTileObject != null)
        {
            if (nextTileObject is IInteractable)
            {
                (nextTileObject as IInteractable).Interact(this);
            }
        }


        Field[MapPosition.X].OnTileObject = null;
        Field[nextPos.X].OnTileObject = this;
        MapPosition = nextPos;

    }

    public void Render()
    {
        DrawHPGauge();
        // _inventory.Render();
    }


    public void AddItem(Item item)
    {

        // _inventory.AddItem(item);
    }


    private void DrawHPGauge()
    {
        /*
        Console.SetCursorPosition(0, 20);
        _fuelGauge.Print(ConsoleColor.Yellow);
        */

        Console.SetCursorPosition(1, 12);
        Console.WriteLine();
        CurrentHP.Value.ToString().Print(ConsoleColor.Yellow);
        Console.Write(" / ");
        MaxHP.Value.ToString().Print(ConsoleColor.Yellow);

    }


    public void SetHPGauge(float hp)
    {

    }
}

