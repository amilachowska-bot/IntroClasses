namespace IntroClasses;

public abstract class GameObject
{
    protected Vector2 _position = new Vector2(0, 0);
    protected char _avatar = '@';

    public GameObject(char avatar, Vector2 position)
    {
        _avatar = avatar;
        _position = position;
    }
    
    public void Display()
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write(_avatar);
    }
}