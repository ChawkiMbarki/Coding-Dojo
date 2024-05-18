class Ninja{
  constructor(name, health = 90, speed = 3, strength = 3) {
    this.name = name;
    this.health = health;
    this.speed = speed;
    this.strength = strength;
  }

  sayName(){
    console.log(`Hello ${this.name}!`)
  }

  showStats(){
    console.log(`${this.name}\n\tStrength: ${this.strength}\n\tSpeed: ${this.speed}\n\tHealth: ${this.health}\n`)
  }

  drinkMilk(){
    this.health += 10;
  }

}
const ninja1 = new Ninja("Hyabusa");
ninja1.sayName();
ninja1.showStats();