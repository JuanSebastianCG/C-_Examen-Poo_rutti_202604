public class Enemigo
{
  // vide del jugador
  public int vida;

  // daño que el jugador puede hacer
  public int dmgToDo;

  public Enemigo(int vida, int dmgToDo)
  {
    this.vida = vida;
    this.dmgToDo = dmgToDo;
  }

  /* Debe tener un método que le permita recibir daño
  */
  public void recibirDaño(int dañoRecibido)
  {
    this.vida = this.vida - dañoRecibido;
  }

  /* Debe tener un método que retorne el daño que puede causar */
  public int getDmgToDo()
  {
    return this.dmgToDo;
  }

  /* Debe tener un método que retorne si está vivo o muerto  */
  public bool estaVivo()
  {
    if (this.vida <= 0)
    {
      return false;
    }
    else
    {
      return true;
    }
  }



  public override string ToString()
  {
    return $"Enemigo [Vida: {this.vida}, Daño: {this.dmgToDo}]";
  }

}
