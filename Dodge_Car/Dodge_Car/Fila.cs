using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Dodge_Car
{
    class Fila
    {
        public int primeiro, final, nroElem, maxElem;
        public int[] elementos;

        public Fila()
        {
            primeiro = 0;
            final = 0;
            nroElem = 0;
            maxElem = 4;
            elementos = new int[maxElem];
            for (int i = 0; i < maxElem; i++)
                elementos[i] = 0;
        }
        public int GetNroElem()
        {
            return nroElem;
        }
        public int GetMaxElemt()
        {
            return maxElem;
        }

        //Métodos para manipular a Fila
        public bool Cheia()
        {
            if (nroElem < maxElem)
                return false;
            else
                return true;
        }

        public bool Vazia()
        {
            if (nroElem == 0)
                return true;
            else
                return false;
        }

        public void Insere(int x, ref bool deuCerto)
        {
            if (Cheia())
                deuCerto = false;
            else
            {
                deuCerto = true;
                nroElem++;
                elementos[final] = x;

                //Avança o apontador
                if (final == maxElem - 1)
                    final = 0;
                else
                    final++;
            }
        }

        public void Retira(ref int x, ref bool deuCerto)
        {
            if (Vazia())
                deuCerto = false;
            else
            {
                deuCerto = true;
                x = elementos[primeiro];
                elementos[primeiro] = 999;  //999 simboliza o 'nada'
                nroElem--;

                //Avança o apontador
                if (primeiro >= maxElem - 1)
                    primeiro = 0;
                else
                    primeiro++;
            }
        }

        //fim métodos primários da fila

    }
}
