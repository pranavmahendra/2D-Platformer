using UnityEngine;

public class EnemyModel
{
   public EnemyModel(int Health, int damage)
    {
        this.Health = Health;
        this.Damage = damage;
    }

    public int Health { get; }
    public int Damage { get; }
}
