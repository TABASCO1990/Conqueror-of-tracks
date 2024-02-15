using Game;
using Levels;

public class PointDead : LoseCondition
{
    protected override void Start()
    {
        way = transform.parent.GetComponent<Way>();
    }
}
