using System;
using System.Collections.Generic;
using System.Text;

// 모든 씬을 상속할 부모용 추상 씬
public abstract class SceneBase
{
    public abstract void Enter();
    public abstract void Update();
    public abstract void Render();
    public abstract void Exit();
}

