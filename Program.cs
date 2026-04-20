bool jugar = true;
while (jugar)
{
  /* ===============Crear jugador==================== */

  /* preguntar al usuario para crear su personaje  */
  bool loEscribióMal = true;
  int vida = 0;
  int dmgToDo = 0;

  // Crear jugador con validación
  while (loEscribióMal)
  {
    Console.WriteLine("Cuanta vida tendrá tu jugador? (No mayor a 100)");
    vida = int.Parse(Console.ReadLine());

    Console.WriteLine("Cuanta daño hará tu jugador? (No mayor a 100)");
    dmgToDo = int.Parse(Console.ReadLine());

    if (vida > 100 || dmgToDo > 100)
    {
      Console.WriteLine("Te pasaste de los limites papu");
    }
    else
    {
      loEscribióMal = false;
    }
  }
  Jugador p1 = new Jugador(vida, dmgToDo);

  /* ==============Crear enemigos===================== */
  // Enemigos
  Console.WriteLine("Cuantos Enemigos habrán?");
  int ctEnemigos = int.Parse(Console.ReadLine());

  List<Enemigo> listaDeEnemigos = new List<Enemigo>();

  for (int i = 0; i < ctEnemigos; i++)
  {
    Console.WriteLine($"Vida enemigo #{i}:");
    int vidaE = int.Parse(Console.ReadLine());

    Console.WriteLine($"Daño enemigo #{i}:");
    int dmgE = int.Parse(Console.ReadLine());

    listaDeEnemigos.Add(new Enemigo(vidaE, dmgE));
  }

  /* ==============Empezar juego===================== */
  // LOOP DEL JUEGO
  bool juegoNoTerminado = true;

  while (juegoNoTerminado)
  {
    MostrarEstado(listaDeEnemigos, p1);
    if (TodosMuertos(listaDeEnemigos))
    {
      Console.WriteLine("GANASTE");
      juegoNoTerminado = false;
    }
    else
    {
      Console.WriteLine("A que enemigo atacar?");
      int indice = int.Parse(Console.ReadLine());
      bool turnoValido = true;

      /* verificaciones de indice */
      if (indice < 0 || indice >= listaDeEnemigos.Count)
      {
        Console.WriteLine("Indice invalido");
        turnoValido = false;
      }
      else
      {
        /* verificar si el enemigo ya esta muerto */
        if (!listaDeEnemigos[indice].estaVivo())
        {
          Console.WriteLine("Ese enemigo ya está muerto");
          turnoValido = false;
        }
      }

      if (turnoValido)
      {
        /*  atacar al enemigo*/
        listaDeEnemigos[indice].recibirDaño(p1.getDmgToDo());
        Console.WriteLine("Atacaste! le quitaste "+ p1.getDmgToDo()+" de vida");

        /* el enemigo ataca */
        Enemigo atacante = EnemigoVivoRandom(listaDeEnemigos);
        /* si no me retorno ningún enemigo random vivo entonces no puedo atacar al jugador */
        if (atacante != null)
        {
          p1.recibirDaño(atacante.getDmgToDo());
          Console.WriteLine("el enemigo  te atacó! y te bajo");
        }

        if (p1.vida <= 0)
        {
          Console.WriteLine("PERDISTE");
          juegoNoTerminado = false;
        }
      }
    }
  }

  // Reiniciar
  Console.WriteLine("Quieres jugar otra vez? (s/n)");
  string resp = Console.ReadLine();
  if (resp != "s")
  {
    jugar = false;
  }
}



bool TodosMuertos(List<Enemigo> enemigos)
{
  for (int i = 0; i < enemigos.Count; i++)
  {
    if (enemigos[i].estaVivo())
      return false;
  }
  return true;
}

Enemigo EnemigoVivoRandom(List<Enemigo> enemigos)
{
  /* crear lista de vivos */
  List<Enemigo> vivos = new List<Enemigo>();
  for (int i = 0; i < enemigos.Count; i++)
  {
    if (enemigos[i].estaVivo())
    {
      vivos.Add(enemigos[i]);
    }
  }
  /* si no hay vivos retornar null(vacio - no existen) */
  if (vivos.Count == 0)
  {
    return null;
  }

  // si si existen vivos continua y selecciona uno random
  Random rnd = new Random();
  /* dame un numero aleatorio dentro de  rango 0 a la lista de vivos */
  int index = rnd.Next(0, vivos.Count);
  return vivos[index];
}


void MostrarEstado(List<Enemigo> enemigos, Jugador p1)
{
  Console.WriteLine("\n--- ESTADO ---");
  Console.WriteLine("Vida jugador: " + p1.vida);
  for (int i = 0; i < enemigos.Count; i++)
  {
    Console.WriteLine("|" + i + "| " + enemigos[i].vida + " Vivo: " + enemigos[i].estaVivo());
  }
}
