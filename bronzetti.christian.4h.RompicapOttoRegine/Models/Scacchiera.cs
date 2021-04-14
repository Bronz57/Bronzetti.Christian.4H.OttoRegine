using System;
using System.Collections.Generic;
using System.Text;

//per il controllo devi es cornici e diagonali tpsit e determinante laplace, utile anche per la ricorsione molto simile
namespace bronzetti.christian._4h.RompicapOttoRegine.Models
{
    class Scacchiera
    {
        int _nRigeColonne; //dimensionamento matrice
        char  [,] _scacchiera; //matrice di caratteri
        int _colonnaAttuale; //colonna che si sta analizzando
		int _rigaCorrente; //riga che viene analizzata
		int k;
		//costruttore
		public Scacchiera(int n)
        {
            _nRigeColonne = n;
            _scacchiera = new char [_nRigeColonne, _nRigeColonne]; //creo matrice 
			_colonnaAttuale = 0;
			_rigaCorrente = 0;
        }

		//metodo per stampare il risoltuato ottenuto
		public string StampaScacchiera()
		{
			
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < _nRigeColonne; i++)
			{
				for (int j = 0; j < _nRigeColonne; j++)

					if (_scacchiera[i, j] == 'R')
						sb.Append(" R \t");
					else
						sb.Append(" - \t");
						
				sb.AppendLine("\n");
			}

			return sb/*.AppendLine($"Girato per {k-1} volte ")*/.ToString();
		}

		private bool ControlloCatturaRegina()
		{
			
			//controlla _rigaCorrente, alla prima colonna
			for (int i = 0; i < _colonnaAttuale; i++)
				if (_scacchiera[_rigaCorrente, i] == 'R')
					return true;

			//controllo la metà in alto 
			int r = _rigaCorrente;
			int c = _colonnaAttuale;
			do
			{
				if (_scacchiera[r, c] == 'R')
					return true;

				r--;
				c--;
			} while (r >= 0 && c >= 0);


			//controllo della metà in diagonale in basso
			r = _rigaCorrente;
			c = _colonnaAttuale;
            do
            {
				if (_scacchiera[r, c] == 'R')
					return true;

				c--;
				r++;
			} while (c >= 0 && r < _nRigeColonne);
				

			return false;
		}
		
		public bool RisolviRompicapo()
		{
			k++;

			
			//gira fino a quando il le colonne sono finite ---!caso base|
			if (_colonnaAttuale >= _nRigeColonne)
				return true;

			//inzia dalla cella A,8 nella scacchiera è la prima in alto a sx
			for (int i = 0; i < _nRigeColonne; i++)
			{
				//gira controllando ogni riga per ogni colonna
				_rigaCorrente = i;
				if (!ControlloCatturaRegina())
				{
					//se non viene catturata poziona regina	
					_scacchiera[i, _colonnaAttuale] = 'R';

					
					_colonnaAttuale++; //avanzo colonna
										
					if (RisolviRompicapo()) //controllo se ha finito le colonne in caso riprende le colonne dalla precendente
						return true;

					_colonnaAttuale--;  //decremento colonna in cas non venga soddisfato l'if

					//caso tampone per rimuovere un'eventuale regina piazzata
					_scacchiera[i, _colonnaAttuale] = '-';
				}
			}

			return false;
		}
	}
}
