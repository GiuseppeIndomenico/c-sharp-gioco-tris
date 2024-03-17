/*usare un array bidimensionale di caratteri per rappresentare la criglia del gioco.
I giocatori possono inserire le loro mosse tramite riga e colonna, e il programma controlla se la mossa è valida
alla fine  di ogni mossa controlliamo se la griglia è piena o c'è una vittoria*/


class Tris
{
    static char[,] griglia = new char[3, 3];
    static void Main(string[] args)
    {
        Play();
    }

    static void CreazioneGriglia()//inizializza la griglia vuota
    {
        for (int riga = 0; riga < griglia.GetLength(0); riga++)
        {
            for (int colonna = 0; colonna < griglia.GetLength(1); colonna++)
            {
                griglia[riga, colonna] = ' ';
            }
        }
    }
    static void StampaGriglia()
    {
        for (int riga = 0; riga < griglia.GetLength(0); riga++)
        {
            for (int colonna = 0; colonna < griglia.GetLength(1); colonna++)
            {
                Console.Write(" " + griglia[riga, colonna] + " ");
                if (colonna < griglia.GetLength(1) - 1)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (riga < griglia.GetLength(0) - 1)
            {
                Console.WriteLine("-----------");
            }
        }
    }


    static bool MossaValida(int riga, int colonna)//metodo per verificare se la mossa è valida
    {
        return riga >= 0 && riga < 3 && colonna >= 0 && colonna < 3 && griglia[riga, colonna] == ' ';
    }
    static bool GrigliaPiena()//metodo per impostare se la griglia è piena
    {
        foreach (char cella in griglia)
        {
            if (cella == ' ')
            {
                return false;
            }

        };
        return true;
    }
    static bool ControlloVittoria(char simbolo)
    {
        for (int i = 0; i < griglia.GetLength(0); i++)
        {
            if (griglia[i, 0] == simbolo && griglia[i, 1] == simbolo && griglia[i, 2] == simbolo)
            {
                return true;
            }
            if (griglia[0, i] == simbolo && griglia[1, i] == simbolo && griglia[2, i] == simbolo)
            {
                return true;
            }
        }
        if (griglia[0, 0] == simbolo && griglia[1, 1] == simbolo && griglia[2, 2] == simbolo)
        {
            return true;
        }
        if (griglia[0, 2] == simbolo && griglia[1, 1] == simbolo && griglia[2, 0] == simbolo)
        {
            return true;
        }
        return false;
    }
    static void Play()
    {
        CreazioneGriglia();
        char simbolo = 'X';
        bool vittoria = false;
        while (!vittoria && !GrigliaPiena())
        {


            StampaGriglia();

            Console.WriteLine($"giocatore con il simbolo '{simbolo}' è il tuo turno, inserisci un numero per la riga(0-2) e uno per la colonna (0-2)");
            string[] input = Console.ReadLine().Split(' ');
            int riga = Convert.ToInt32(input[0]);
            int colonna = Convert.ToInt32(input[1]);
            if (MossaValida(riga, colonna))
            {
                griglia[riga, colonna] = simbolo;
                vittoria = ControlloVittoria(simbolo);
                if (vittoria)
                {
                    Console.WriteLine("ha vinto il giocatore con il simbolo: " + simbolo);

                }
                else if (GrigliaPiena())
                {
                    Console.WriteLine("pareggio!");
                }
                else
                {
                    simbolo = (simbolo == 'X') ? 'O' : 'X';//cambia turno giocatore
                }
            }
            else
            {
                Console.WriteLine("mossa non valida");

            }
        }
        StampaGriglia();
    }
}
