class Ranged : Enemy
{
  public double Distance = 5.0;
  public Ranged(int id, string name, double health = 100) : base(id, name, health)
  {
    MaxHp = 100;
    AttacksList.Add(new Attack("Shoot an Arrow", 20));
    AttacksList.Add(new Attack("Throw a Knife", 15));
  }
  public override Attack Ultimate(Enemy Target)
  {
    if (this.Health <= 0)
    {
      Console.WriteLine($"- [ {this.Name} ] is already dead, he can't preform an attack!");
      return new Attack("No", 0);
    }
    else {
      Console.WriteLine($"- [ {this.Name} ] DASHED to a distance of 20");
      Random random = new Random();
      this.Distance = 20;
      Attack attack = AttacksList[random.Next(0, AttacksList.Count)];
      PerformAttack(Target, attack);
      return new Attack($"Dash and {attack.Name}", attack.DamageAmount);
    }
  }

  public override void PerformAttack(Enemy Target, Attack attack)
  {
    if (this.Distance < 10)
    {
      Console.WriteLine($"- [ {this.Name} ] Can't preform an attack because he is so close to it's target [ {Target.Name} ]!");
      Console.WriteLine($"- Disctance between them must be more than 9 | Current Distance : [ {this.Distance} ]");
    }
    else if (Target.Health <= 0)
    {
      Console.WriteLine($"[ {Target.Name} ] is already dead, you can't attack him!");
    }
    else if (this.Health <= 0)
    {
      Console.WriteLine($"- [ {this.Name} ] is already dead, he can't preform an attack!");
    }
    else
    {
      Console.WriteLine($"- [ {this.Name} ] attacked [ {Target.Name} ] with a -{attack.Name}- attack!");
      if (Target.Health - attack.DamageAmount <= 0)
      {
        Console.WriteLine($"- He Successfully killed [ {Target.Name} ]");
        Console.WriteLine($"- [ {this.Name} ]'s Score: {this.Score} + 1 = {this.Score + 1}");
        this.Score += 1;
        Target.Health = 0;
      }
      else
      {
        Console.WriteLine($"- [ {Target.Name} ]'s HP: {Target.Health} - {attack.DamageAmount} = {Target.Health - attack.DamageAmount}");
        Target.Health -= attack.DamageAmount;
      }
    }
  }
}