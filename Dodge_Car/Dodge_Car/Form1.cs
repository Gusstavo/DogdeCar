using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Car
{
    public partial class Form1 : Form
    {
        Grafico PlayGround;
        Carro Player;
        Fila[] ordem;
        Label Pause;
        Button[] selecaoCarro;
        SoundPlayer music,explosion;        //Para reproduzir som
        bool esquerda, direita, cima, deuCerto,pause,controleEntradas, disparo;
        string fundo, stagio,carroEscolhido;
        int[] tam, tamArvores;
        int [,] desenhos, arvores;
        int score, posXLaser;
        int auxMovimento, auxInimigo, auxExplosion, auxArvore, auxLaser, cargasLaser,auxTempo;

        public Form1()
        {
            InitializeComponent();
            //Música
            music = new SoundPlayer("music.wav");
            explosion = new SoundPlayer("explosion.wav");

            carroEscolhido = "carro1";
            timer1.Enabled = false;
            selecaoCarro = new Button[4];
            PlayGround = new Grafico(pictureBox1);
            Player = new Carro(carroEscolhido);
            tam = new int[4];
            tamArvores = new int[4];
            ordem = new Fila[4];
            desenhos = new int[5,4];
            arvores = new int[7, 4];

            //Carrega Label do pause
            Pause = new Label();
            Pause.Text = "PAUSE";
            Pause.BackColor = Color.Transparent;
            Pause.ForeColor = System.Drawing.Color.Red;
            Pause.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Pause.Location = new Point(425 - 93, 300 - 50);
            Pause.Size = new System.Drawing.Size(200, 200);
            Pause.Visible = false;
            pictureBox1.Controls.Add(Pause);

            IniciaValores();
        }

        private void IniciaValores()
        {
            //Instanciando com valores 0 em 'ordem'
            for (int i = 0; i < 4; i++)
            {
                ordem[i] = new Fila();
                for (int j = 0; j < ordem[i].GetMaxElemt(); j++)
                {
                    ordem[i].Insere(0, ref deuCerto);
                }
            }

            //Instanciando com os valores 0 em 'desenhos'
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    desenhos[i, j] = 0;
                }
            }

            //Instanciando com os valores 0 em 'arvores'
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arvores[i, j] = 0;
                }
            }

            fundo = "capa";
            stagio = "menu";
            pause = false;
            esquerda = false;
            direita = false;
            controleEntradas = false;
            disparo = false;
            score = 0;
            auxMovimento = 0;
            auxArvore = 0;
            auxExplosion = 0;
            auxLaser = 0;
            posXLaser = 0;
            cargasLaser = 1;
            auxTempo = 0;
            tam[0] = 0;
            tam[1] = 0;
            tam[2] = 850;
            tam[3] = 650;
            tamArvores[0] = 50;
            tamArvores[1] = 120;
            tamArvores[2] = 800;
            tamArvores[3] = 710;
            Player = new Carro(carroEscolhido);
            PlayGround.LimpaTela();
            PlayGround.Desenha(fundo, tam[0], tam[1], tam[2], tam[3]);
            explosion.Stop();
            music.Play();
        }

        private void button_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_iniciar_Click(object sender, EventArgs e)
        {
            DesativaInterfaces();
            stagio = "inGame";
            fundo = "Rua";
            tam[0] = 175;
            tam[1] = 0;
            tam[2] = 500;
            tam[3] = 1000;
            timer1.Enabled = true;
            timer_pontua.Enabled = true;
        }

        private void timer_explosao_Tick(object sender, EventArgs e)
        {
            auxExplosion++;
            if(auxExplosion < 13)
                PlayGround.Desenha("explosion\\explosion" + auxExplosion.ToString(), Player.Get_posX() - 40, Player.Get_posY() - 30, 128, 128);
            else
            {
                timer_explosao.Enabled = false;
                auxExplosion = 0;
                Pause.Text = "Você durou "+ score.ToString() + "\n   segundos!";
                Pause.ForeColor = System.Drawing.Color.Black;
                Pause.Location = new Point(425 - 180, 300 - 50);
                Pause.Size = new System.Drawing.Size(400, 200);
                PlayGround.Escreve("Press Down!", Color.Black, System.Drawing.FontStyle.Bold, 23f, 315, 420);
                Pause.Visible = true;
            }
        }

        private void timer_pontua_Tick(object sender, EventArgs e)
        {
            score++;
            auxTempo++;
            if(auxTempo == 10)
            {
                auxTempo = 0;
                cargasLaser++;
            }
        }

        private void button_controles_Click(object sender, EventArgs e)
        {
            if (stagio == "menu")
            {
                fundo = "setas";
                stagio = "fechaControle";
                PlayGround.Desenha(fundo, 275, 225, 300, 200);
                fundo = "capa";
                DesativaInterfaces();
                button_controles.Enabled = true;
                button_controles.Visible = true;
                button_controles.Location = new Point(350, 426);
                button_controles.Text = "Voltar";
            }
            else
            {
                PlayGround.Desenha(fundo, tam[0], tam[1], tam[2], tam[3]);
                stagio = "menu";
                button_controles.Location = new Point(642, 406);
                button_controles.Text = "Controles";
                HabilitaInterfaces();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!pause)
            {
                PlayGround.LimpaTela();
                PlayGround.Desenha(fundo, tam[0], tam[1], tam[2], tam[3]);
                PlayGround.Desenha(Player.Get_sprite(), Player.Get_posX(), Player.Get_posY(), Player.Get_tamX(), Player.Get_tamY());
                tam[0] = 285;
                tam[1] = 360;
                tam[2] = 435;
                tam[3] = 515;

                //Desenha carros
                for (int i = 0; i < 5; i ++)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        if(ValorToString(desenhos[i,j]) != "nada")
                        {
                            PlayGround.Desenha(PlayGround.Rotacionar(PlayGround.RetornaBitmapa(ValorToString(desenhos[i,j]))), tam[j], i * 114 + auxInimigo * 18, Player.Get_tamX(), Player.Get_tamY());
                        }
                    }
                }
                //Desenhas Árvores
                for(int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (ValorToString(arvores[i, j]) != "nada")
                        {
                            PlayGround.Desenha(PlayGround.RetornaBitmapa(ValorToString(arvores[i, j])), tamArvores[j], i * 120 + auxArvore * 15, 52, 88);
                        }
                    }
                }
                //Desenha Quantidades de Poder
                PlayGround.Desenha(PlayGround.RetornaBitmapa("power"), PlayGround.Get_X() - 70, PlayGround.Get_Y() - 70, 50, 50);
                PlayGround.Escreve(cargasLaser.ToString() + "x", Color.Red, System.Drawing.FontStyle.Bold, 26f, PlayGround.Get_X() - 130, PlayGround.Get_Y() - 60);
                //Desenha Score
                PlayGround.Escreve("Score: " + score.ToString(), Color.Black, System.Drawing.FontStyle.Bold, 15f, 20, 20);
                tam[0] = 175;
                tam[1] = 0;
                tam[2] = 500;
                tam[3] = 1000;
                if(stagio == "colissao")
                {
                    timer1.Enabled = false;
                }
                else
                    Mecanica();
                //label1.Text = Player.Get_posX().ToString();
            }
        }

        private void DesativaInterfaces()
        {
            button_controles.Enabled = false;
            button_iniciar.Enabled = false;
            button_sair.Enabled = false;
            button_opcao.Enabled = false;

            button_controles.Visible = false;
            button_iniciar.Visible = false;
            button_sair.Visible = false;
            button_opcao.Visible = false;
        }

        private void HabilitaInterfaces()
        {
            button_iniciar.Enabled = true;
            button_controles.Enabled = true;
            button_sair.Enabled = true;
            button_opcao.Enabled = true;
            button_iniciar.Visible = true;
            button_controles.Visible = true;
            button_sair.Visible = true;
            button_opcao.Visible = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys tecla = e.KeyData;

            if (tecla == Keys.P && stagio == "inGame")
            {
                if (!pause)
                {
                    music.Stop();
                    pause = true;
                    Pause.Text = "PAUSE";
                    Pause.ForeColor = System.Drawing.Color.Red;
                    Pause.Location = new Point(425 - 93, 300 - 50);
                    Pause.Size = new System.Drawing.Size(200, 200);
                    Pause.Visible = true;
                    timer_pontua.Enabled = false;
                }
                else
                {
                    music.Play();
                    pause = false;
                    Pause.Visible = false;
                    timer_pontua.Enabled = true;
                }
            }
            if (tecla == Keys.Down && stagio != "menu")
            {
                if (stagio == "colissao")
                {
                    //Instanciando com valores 0 em 'ordem'
                    for (int i = 0; i < 4; i++)
                    {
                        ordem[i] = new Fila();
                        for (int j = 0; j < ordem[i].GetMaxElemt(); j++)
                        {
                            ordem[i].Insere(0, ref deuCerto);
                        }
                    }

                    //Instanciando com os valores 0 em 'desenhos'
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            desenhos[i, j] = 0;
                        }
                    }

                    //Instanciando com os valores 0 em 'arvores'
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            arvores[i, j] = 0;
                        }
                    }

                    pause = false;
                    esquerda = false;
                    direita = false;
                    controleEntradas = false;
                    disparo = false;
                    score = 0;
                    auxMovimento = 0;
                    auxArvore = 0;
                    auxExplosion = 0;
                    auxLaser = 0;
                    posXLaser = 0;
                    cargasLaser = 1;
                    auxTempo = 0;
                    tam[0] = 0;
                    tam[1] = 0;
                    tam[2] = 850;
                    tam[3] = 650;
                    tamArvores[0] = 50;
                    tamArvores[1] = 120;
                    tamArvores[2] = 800;
                    tamArvores[3] = 710;
                    Player = new Carro(carroEscolhido);
                    DesativaInterfaces();
                    stagio = "inGame";
                    fundo = "Rua";
                    tam[0] = 175;
                    tam[1] = 0;
                    tam[2] = 500;
                    tam[3] = 1000;
                    explosion.Stop();
                    music.Play();
                    Pause.Visible = false;
                    timer1.Enabled = true;
                    timer_pontua.Enabled = true;
                }
                else
                {
                    IniciaValores();
                    HabilitaInterfaces();
                    timer1.Enabled = false;
                    timer_pontua.Enabled = false;
                    timer_explosao.Enabled = false;
                    Pause.Visible = false;
                }
            }
            if (tecla == Keys.Right && !controleEntradas && stagio == "inGame")
            {
                direita = true;
                controleEntradas = true;
                this.KeyPreview = false;
            }
            if (tecla == Keys.Left && !controleEntradas && stagio == "inGame")
            {
                esquerda = true;
                controleEntradas = true;
                this.KeyPreview = false;
            }
            if (tecla == Keys.Up && !disparo && stagio == "inGame" && cargasLaser > 0)
            {
                cima = true;
                disparo = true;
            }
        }

        private void Mecanica()
        {
            //Comandos para movimentação para direita
            if(direita)
            {
                if (Player.Get_posX() >= 285 && Player.Get_posX() < 360)
                {
                    if (auxMovimento == 0)
                    {
                        Player.Set_posX(Player.Get_posX() + 19);
                        Player.Set_sprite(carroEscolhido + "D");
                        auxMovimento++;
                    }
                    else
                    if (auxMovimento == 1)
                    {
                        Player.Set_posX(Player.Get_posX() + 19);
                        auxMovimento++;
                    }
                    else
                    {
                        Player.Set_posX(360);
                        Player.Set_sprite(carroEscolhido);
                        auxMovimento = 0;
                        direita = false;
                        this.KeyPreview = true;
                        controleEntradas = false;
                    }
                }
                else
                if (Player.Get_posX() >= 360 && Player.Get_posX() < 435)
                {
                    if (auxMovimento == 0)
                    {
                        Player.Set_posX(Player.Get_posX() + 19);
                        auxMovimento++;
                        Player.Set_sprite(carroEscolhido + "D");
                    }
                    else
                    if (auxMovimento == 1)
                    {
                        Player.Set_posX(Player.Get_posX() + 19);
                        auxMovimento++;
                    }
                    else
                    {
                        Player.Set_posX(435);
                        Player.Set_sprite(carroEscolhido);
                        auxMovimento = 0;
                        direita = false;
                        this.KeyPreview = true;
                        controleEntradas = false;
                    }
                }
                else
                if (Player.Get_posX() >= 435 && Player.Get_posX() < 515)
                {
                    if (auxMovimento == 0)
                    {
                        Player.Set_posX(Player.Get_posX() + 20);
                        auxMovimento++;
                        Player.Set_sprite(carroEscolhido + "D");
                    }
                    else
                    if (auxMovimento == 1)
                    {
                        Player.Set_posX(Player.Get_posX() + 20);
                        auxMovimento++;
                    }
                    else
                    {
                        Player.Set_posX(515);
                        Player.Set_sprite(carroEscolhido);
                        auxMovimento = 0;
                        direita = false;
                        this.KeyPreview = true;
                        controleEntradas = false;
                    }
                }
                else
                if (Player.Get_posX() >= 515)
                {
                    auxMovimento = 0;
                    direita = false;
                    this.KeyPreview = true;
                    controleEntradas = false;
                }
            }
            //Comandos para movimentação para esquerda
            if (esquerda)
            {
                if (Player.Get_posX() > 435 && Player.Get_posX() <= 515)
                {
                    if (auxMovimento == 0)
                    {
                        Player.Set_posX(Player.Get_posX() - 20);
                        auxMovimento++;
                        Player.Set_sprite(carroEscolhido + "E");
                    }
                    else
                    if(auxMovimento == 1)
                    {
                        Player.Set_posX(Player.Get_posX() - 20);
                        auxMovimento++;
                    }
                    else
                    {
                        Player.Set_posX(435);
                        Player.Set_sprite(carroEscolhido);
                        auxMovimento = 0;
                        esquerda = false;
                        this.KeyPreview = true;
                        controleEntradas = false;
                    }
                }
                else
                if (Player.Get_posX() > 360 && Player.Get_posX() <= 435)
                {
                    if (auxMovimento == 0)
                    {
                        Player.Set_posX(Player.Get_posX() - 19);
                        auxMovimento++;
                        Player.Set_sprite(carroEscolhido + "E");
                    }
                    else
                    if (auxMovimento == 1)
                    {
                        Player.Set_posX(Player.Get_posX() - 19);
                        auxMovimento++;
                    }
                    else
                    {
                        Player.Set_posX(360);
                        Player.Set_sprite(carroEscolhido);
                        auxMovimento = 0;
                        esquerda = false;
                        this.KeyPreview = true;
                        controleEntradas = false;
                    }
                }
                else
                if (Player.Get_posX() > 285 && Player.Get_posX() <= 360)
                {
                    if (auxMovimento == 0)
                    {
                        Player.Set_posX(Player.Get_posX() - 19);
                        auxMovimento++;
                        Player.Set_sprite(carroEscolhido + "E");
                    }
                    else
                    if (auxMovimento == 1)
                    {
                        Player.Set_posX(Player.Get_posX() - 19);
                        auxMovimento++;
                    }
                    else
                    {
                        Player.Set_posX(285);
                        Player.Set_sprite(carroEscolhido);
                        auxMovimento = 0;
                        esquerda = false;
                        this.KeyPreview = true;
                        controleEntradas = false;

                    }
                }
                else
                if (Player.Get_posX() <= 285)
                {
                    auxMovimento = 0;
                    esquerda = false;
                    this.KeyPreview = true;
                    controleEntradas = false;
                }
            }

            //Movimentando os carros
            if (auxInimigo == 5)
            {
                int valor = 0;
                Random rand = new Random();
                richTextBox1.Text = "";

                for (int i = 0; i < 4; i++)
                {
                    ordem[i].Retira(ref valor, ref deuCerto);

                    for (int j = 4; j >= 0; j--)
                    {
                        if (j == 0)
                            desenhos[0, i] = valor;
                        else
                            desenhos[j, i] = desenhos[(j - 1), i];
                    }

                    ordem[i].Insere(rand.Next(0, 100), ref deuCerto);
                }
                richTextBox1.Text += "\nTeste dos Valores da fila\n";
                for (int l = 0; l < 5; l++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        richTextBox1.Text += desenhos[l, k] + " ";
                    }
                    richTextBox1.Text += "\n";
                }
                auxInimigo=0;
            }
            else
                auxInimigo++;
            //Movimentação das árvores
            if (auxArvore == 7)
            {
                Random rand = new Random();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 6; j >= 0; j--)
                    {
                        if (j == 0)
                            arvores[0, i] = rand.Next(101,110);
                        else
                            arvores[j, i] = arvores[(j - 1), i];
                    }
                }
                auxArvore = 0;
            }
            else
                auxArvore++;

            //Colisão
            for (int i = 0; i < 4; i++)
            {
                if((ValorToString(desenhos[3,i]) != "nada" && auxInimigo == 2) || (ValorToString(desenhos[4,i]) != "nada"))
                {
                    if (Player.Get_posX() >= 285 && Player.Get_posX() < 360 - 40 && i == 0)
                    {
                        stagio = "colissao";
                        timer1.Enabled = false;
                    }
                    else
                    if (Player.Get_posX() >= 360 - 40 && Player.Get_posX() < 435 - 40 && i == 1)
                    {
                        stagio = "colissao";
                        timer1.Enabled = false;
                    }
                    else
                    if (Player.Get_posX() >= 435 - 40 && Player.Get_posX() < 515 - 40 && i == 2)
                    {
                        stagio = "colissao";
                        timer1.Enabled = false;
                    }
                    else
                    if (Player.Get_posX() >= 515 - 40 && i == 3)
                    {
                        stagio = "colissao";
                        timer1.Enabled = false;
                    }
                    if(stagio == "colissao")
                    {
                        timer_explosao.Enabled = true;
                        timer_pontua.Enabled = false;
                        music.Stop();
                        explosion.Play();
                    }
                }
            }

            //Laser
            if(cima)
            {
                if(auxLaser == 0)
                {
                    if(Player.Get_posX() >= 285 && Player.Get_posX() < 360)
                    {
                        posXLaser = 0;
                    }
                    else
                    if (Player.Get_posX() >= 360 && Player.Get_posX() < 435)
                    {
                        posXLaser = 1;
                    }
                    else
                    if (Player.Get_posX() >= 435 && Player.Get_posX() < 515)
                    {
                        posXLaser = 2;
                    }
                    else
                    if (Player.Get_posX() >= 515)
                    {
                        posXLaser = 3;
                    }
                    cargasLaser--;
                }

                disparo = true;
                auxLaser++;

                if(auxLaser > 0 && auxLaser < 5)
                {
                    int aux=0;


                    if (posXLaser == 0)
                        aux = 285;
                    else
                    if (posXLaser == 1)
                        aux = 360;
                    else
                    if (posXLaser == 2)
                        aux = 435;
                    else
                    if (posXLaser == 3)
                        aux = 515;

                    PlayGround.Desenha(PlayGround.RetornaBitmapa("laser1"),aux - 23, -(600 - Player.Get_posY())+2, 99, 600);
                    for(int i = 0; i < 5; i++)
                        desenhos[i, posXLaser] = 0;
                }
                else
                {
                    auxLaser = 0;
                    cima = false;
                    disparo = false;
                }

            }
        }

        private string ValorToString(int numero)
        {
            string texto = "";
            if (numero > 0 && numero < 4)
                texto = "carro0";
            else
                if (numero >= 4 && numero < 8)
                texto = "carro1";
            else
                if (numero >= 8 && numero < 12)
                texto = "carro2";
            else
                if (numero >= 12 && numero < 16)
                texto = "carro3";
            else
                if (numero == 105)
                texto = "arvore1";
            else
                if (numero == 106)
                texto = "arvore2";
            else
                texto = "nada";

            return texto;
        }

        private void button_opcao_Click(object sender, EventArgs e)
        {
            PlayGround.Desenha("selecaoCarro", 130, 130, 600, 366);
            DesativaInterfaces();
            for (int i = 0; i < 4; i++)
            {
                selecaoCarro[i] = new Button();
                selecaoCarro[i].Text = "";
                selecaoCarro[i].BackColor = Color.Transparent;
                selecaoCarro[i].ForeColor = System.Drawing.Color.White;
                selecaoCarro[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                if (i == 0)
                {
                    selecaoCarro[i].Click += new System.EventHandler(this.selecaoCarro_click1);
                    selecaoCarro[i].Location = new Point(150, 199);
                }
                if (i == 1)
                {
                    selecaoCarro[i].Click += new System.EventHandler(this.selecaoCarro_click2);
                    selecaoCarro[i].Location = new Point(150, 340);
                }
                if (i == 2)
                {
                    selecaoCarro[i].Click += new System.EventHandler(this.selecaoCarro_click3);
                    selecaoCarro[i].Location = new Point(455, 199);
                }
                if (i == 3)
                {
                    selecaoCarro[i].Click += new System.EventHandler(this.selecaoCarro_click4);
                    selecaoCarro[i].Location = new Point(455, 340);
                }
                selecaoCarro[i].Size = new System.Drawing.Size(255, 128);

                pictureBox1.Controls.Add(selecaoCarro[i]);
            }
        }

        private void selecaoCarro_click1(object sender, EventArgs e)
        {
            PlayGround.LimpaTela();
            PlayGround.Desenha(fundo, tam[0], tam[1], tam[2], tam[3]);
            HabilitaInterfaces();
            carroEscolhido = "carro4";
            Player.Set_sprite(carroEscolhido);
            for (int i = 0; i < 4; i++)
            {
                selecaoCarro[i].Enabled = false;
                selecaoCarro[i].Visible = false;
            }
        }
        private void selecaoCarro_click2(object sender, EventArgs e)
        {
            PlayGround.LimpaTela();
            PlayGround.Desenha(fundo, tam[0], tam[1], tam[2], tam[3]);
            HabilitaInterfaces();
            carroEscolhido = "carro3";
            Player.Set_sprite(carroEscolhido);
            for (int i = 0; i < 4; i++)
            {
                selecaoCarro[i].Enabled = false;
                selecaoCarro[i].Visible = false;
            }
        }
        private void selecaoCarro_click3(object sender, EventArgs e)
        {
            PlayGround.LimpaTela();
            PlayGround.Desenha(fundo, tam[0], tam[1], tam[2], tam[3]);
            HabilitaInterfaces();
            carroEscolhido = "carro1";
            Player.Set_sprite(carroEscolhido);
            for (int i = 0; i < 4; i++)
            {
                selecaoCarro[i].Enabled = false;
                selecaoCarro[i].Visible = false;
            }
        }
        private void selecaoCarro_click4(object sender, EventArgs e)
        {
            PlayGround.LimpaTela();
            PlayGround.Desenha(fundo, tam[0], tam[1], tam[2], tam[3]);
            HabilitaInterfaces();
            carroEscolhido = "carro2";
            Player.Set_sprite(carroEscolhido);
            for (int i = 0; i < 4; i++)
            {
                selecaoCarro[i].Enabled = false;
                selecaoCarro[i].Visible = false;
            }
        }

    }
}
