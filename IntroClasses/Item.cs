namespace IntroClasses;

public class Item: GameObject
{
    public Item(char avatar, Vector2 position, Map map) : base(avatar, position)
    {
        Cell cell = map.GetCell(_position.X, _position.Y);
        cell.Item = this;
    }
}