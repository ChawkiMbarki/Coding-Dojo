class Enemy {
  public int Id;
  public string Name;
  public double Health;
  protected List<Attack> AttacksList = new List<Attack>();
  public int Score = 0;
  public double MaxHp = 0;
  public Enemy(int id, string name, double health) {
    Id = id;
    Name = name;
    Health = health;
  }
  
  public void NewAttack(Attack attack) {
    AttacksList.Add(attack);
  }

  public List<Attack> GetAttacksList() {
    return AttacksList;
  }
  
  public virtual void PerformAttack(Enemy Target, Attack attack)
  {
    if (Target.Health <= 0)
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

  public virtual Attack Ultimate(Enemy target)
  {
    return new Attack("No", 0);
  }
}
