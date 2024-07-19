class Magic : Enemy
{

  public Magic(int id, string name, double Health = 80) : base(id, name, Health)
  {
    MaxHp = 80;
    AttacksList.Add(new Attack("Fireball", 25));
    AttacksList.Add(new Attack("Lightning Bolt", 20));
    AttacksList.Add(new Attack("Staff Strike", 10));
  }
  public override Attack Ultimate(Enemy Taget)
  {
    if (this.Health <= 0)
    {
      Console.WriteLine($"- [ {this.Name} ] is already dead, he can't preform an attack!");
    }
    else {
      if(Taget.Health == Taget.MaxHp)
      {
        Console.WriteLine($"- [ {Taget.Name} ] Already have maximum HP of: [ {Taget.Health} ]");
      }
      else if(Taget.MaxHp - Taget.Health < 40)
      {
        Console.WriteLine($"- [ {this.Name} ] preformed a healing spell on [ {Taget.Name} ]");
        Console.WriteLine($"- [ {Taget.Name} ]'s HP is: [ {Taget.Health} ] + {Taget.MaxHp - Taget.Health} = {Taget.Health + Taget.MaxHp - Taget.Health}");
        Taget.Health += Taget.MaxHp - Taget.Health;
      }
      else
      {
        Console.WriteLine($"- [ {this.Name} ] preformed a healing spell on [ {Taget.Name} ]");
        Console.WriteLine($"- [ {Taget.Name} ]'s HP is: [ {Taget.Health} ] + 40 = {Taget.Health + 40}");
        Taget.Health += 40;
      }
    }
    return new Attack("No", 0);
  }
}