class Melee : Enemy
{
  public Melee(int id, string name, double health = 120) : base(id, name, health)
  {
    MaxHp = 120;
    AttacksList.Add(new Attack("Punch", 20));
    AttacksList.Add(new Attack("Kick", 15));
    AttacksList.Add(new Attack("Tackle", 25));
  }
  public override Attack Ultimate(Enemy Target)
  {
    if (this.Health <= 0)
    {
      Console.WriteLine($"- [ {this.Name} ] is already dead, he can't preform an attack!");
      return new Attack("No", 0);
    }
    else {
      Console.WriteLine("- RAGE");
      Random random = new Random();
      Attack rageAttack = AttacksList[random.Next(0, AttacksList.Count)];
      Attack modifiedAttack = new Attack("Rage " + rageAttack.Name, rageAttack.DamageAmount + 10);
      PerformAttack(Target, modifiedAttack);
      return modifiedAttack;
    }
  }
}