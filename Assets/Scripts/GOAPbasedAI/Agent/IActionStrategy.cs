public interface IActionStrategy
{
    bool CanPerform {get;}
    bool Complete {get;}

    public void Start() {
        
    }

    public void Update(float deltaTime) {
        
    }

    public void Stop(){

    }
}