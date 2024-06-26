public class IdleStrategy : IActionStrategy {
    public bool CanPerform => true;
    public bool Complete {get; private set;}

    readonly CountdownTimer timer;
    public IdleStrategy(float duration)
    {
        timer = new CountdownTimer(duration);
        timer.OnTimerStart += () => Complete = false;
        timer.OnTimerStop += () => Complete = true;
    }

    public void Start() => timer.Start();
    public void Update(float deltaTime) => timer.Tick(deltaTime);
}
