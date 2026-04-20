

/*====================================== */

// bool loEscribióMal = true;
// int vida = 0;
// int dmgToDo = 0;

// /* preguntar cuanta vida y dano tendra el jugador */
// while (loEscribióMal)
// {
//   Console.WriteLine("Cuanta vida tendrá tu jugador? (No mayor a 100)");
//   vida = int.Parse(Console.ReadLine());
//   Console.WriteLine("Cuanta daño hará tu jugador? (No mayor a 100)");
//   dmgToDo = int.Parse(Console.ReadLine());

//   if (vida > 100 || dmgToDo > 100)
//   {
//     Console.WriteLine("Te pasaste de los limites papu");
//     loEscribióMal = true;
//   }
//   else
//   {
//     loEscribióMal = false;
//   }
// }

// /* Declarar instancia de jugador */
// Jugador p1 = new Jugador(vida, dmgToDo);



/*====================================== */
/* cuantos enemigos habrán */
Console.WriteLine("Cuantos Enemigos habrán?");
int ctEnemigos = int.Parse(Console.ReadLine());

/* crear lista vacia (por ahora) de enemigos */
List<Enemigo> listaDeEnemigos = new List<Enemigo>();
for (int i = 0; i < ctEnemigos; i++)
{
  Console.WriteLine($"Cuanta vida tendrá el enemigo#" + i + "?");
  int vida = int.Parse(Console.ReadLine());
  Console.WriteLine($"Cuanta daño hará el enemigo#" + i + "?");
  int dmgToDo = int.Parse(Console.ReadLine());

  /* crear enemigo */
  Enemigo e = new Enemigo(vida, dmgToDo);
  /* Meterlo en la lista al enemigo */
  listaDeEnemigos.Add(e);
}


Console.WriteLine($"Enemigos" + listaDeEnemigos );






/* Enemigo e1 = new Enemigo(120, 10);
e1.recibirDaño(20);
Console.WriteLine($" {e1.vida}");
Console.WriteLine($" {e1.estaVivo()}");
 */
