using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Car
{
    class Carro
    {
        private int posX, posY, vel,tamX,tamY;
        private string sprite;

        public Carro(string nome)
        {
            //285,360,435,515 Posições possíveis em X
            posX = 285;
            posY = 475;
            tamX = 53;
            tamY = 114;
            vel = 4;
            sprite = nome;
        }
        
        //Métodos Get
        public int Get_posX()
        {
            return posX;
        }
        public int Get_posY()
        {
            return posY;
        }
        public int Get_tamX()
        {
            return tamX;
        }
        public int Get_tamY()
        {
            return tamY;
        }
        public int Get_vel()
        {
            return vel;
        }
        public string Get_sprite()
        {
            return sprite;
        }
        //Métodos Set
        public void Set_posX(int valor)
        {
            posX = valor;
        }
        public void Set_posY(int valor)
        {
            posY = valor;
        }
        public void Set_tamX(int valor)
        {
            tamX = valor;
        }
        public void Set_tamY(int valor)
        {
            tamY = valor;
        }
        public void Set_vel(int valor)
        {
            vel = valor;
        }
        public void Set_sprite(string valor)
        {
            sprite = valor;
        }

    }
}
