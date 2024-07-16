class Program {
  static List<Enemy> Attackers = new List<Enemy>();
  static void Main() {
    Attackers.Add(new Enemy(0, "Steve", 100.0, 0));
    Attackers.Add(new Enemy(1, "Me7rez", 100.0, 0));
    Attackers.Add(new Enemy(2, "El Jelmawi", 100.0, 0));

    Attack attack1 = new Attack("Fire Ball", 20.0);
    Attack attack2 = new Attack("Storm", 45.5);
    Attack attack3 = new Attack("Lightining", 99.0);
    Attack attack4 = new Attack("regular", 5.0);

    Attackers[0].NewAttack(attack1);
    Attackers[0].NewAttack(attack2);
    Attackers[0].NewAttack(attack3);
    Attackers[0].NewAttack(attack4);

    Attackers[1].NewAttack(attack1);
    Attackers[1].NewAttack(attack2);
    Attackers[1].NewAttack(attack3);
    Attackers[1].NewAttack(attack4);

    Attackers[2].NewAttack(attack1);
    Attackers[2].NewAttack(attack2);
    Attackers[2].NewAttack(attack3);
    Attackers[2].NewAttack(attack4);

    Console.WriteLine("\n============================================================================================================\n");
    
    Random rand = new Random();
    while (Attackers.Count > 1)
    {
      int AttackerId = rand.Next(0, Attackers.Count);
      int TargetId = rand.Next(0, Attackers.Count);
      while (TargetId == AttackerId)
      {
        TargetId = rand.Next(0, Attackers.Count);
      }
      RandomAttack(AttackerId, TargetId);
      if (Attackers[TargetId].Health <= 0)
      {
        Attackers.RemoveAt(TargetId);
      }
    }
    Console.WriteLine($"§§§§§§§§§ !!! [ {Attackers[0].Name} ] WON THE TOURNAMENT !!! §§§§§§§§");
    Console.WriteLine("\n============================================================================================================\n");
  }

  static void RandomAttack(int AttackerId, int TargetId) {
    Random random = new Random();
    Enemy Attacker = Attackers[AttackerId];
    Enemy Target = Attackers[TargetId];
    List<Attack> Attacks = Attacker.GetAttacksList();
    Attack attack = Attacks[random.Next(0, Attacks.Count)];

    if (Target.Health <= 0)
    {
      Console.WriteLine($"[ {Target.Name} ] is already dead, you can't attack him!");
    }
    else
    {
      Console.WriteLine($"- [ {Attacker.Name} ] attacked [ {Target.Name} ] with a -{attack.Name}- attack!");
      if (Target.Health - attack.DamageAmount <= 0)
      {
        Console.WriteLine($"- He Successfully killed [ {Target.Name} ]");
        Console.WriteLine($"- [ {Attacker.Name} ]'s Score: {Attacker.Score} + 1 = {Attacker.Score + 1}");
        Attacker.Score += 1;
        Target.Health = 0;
      }
      else
      {
        Console.WriteLine($"- [ {Target.Name} ]'s HP: {Target.Health} - {attack.DamageAmount} = {Target.Health - attack.DamageAmount}%");
        Target.Health -= attack.DamageAmount;
      }
    }

    Console.WriteLine("\n============================================================================================================\n");

  }

}