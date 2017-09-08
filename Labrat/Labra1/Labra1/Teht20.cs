﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace Labra1
{

    class oldSpaces
    {
       // Teht20 = new List<oldSpaces>()
        public int oldY{get;set;}
        public int oldX {get; set;}

        public virtual ICollection<Teht20> GENRES { get; set; } // Use ICollection here
    }

    class Teht20
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);


        public static void display(char[,] area,string dirString)
        {
            var oldSpaces = new List<oldSpaces>();

            Console.Clear();
            for (int i = 0; i < area.GetLength(0); i++)// tehdään sarake 1,2,3
            {
                for (int j = 0; j < area.GetLength(1); j++) // rivi sarake 1,2,3
                {    
                    Console.Write(area[i, j]);
                }
                
                Console.WriteLine("");
            }
            Console.WriteLine(dirString);

        }


        public static void Snake()
        {
            List<int> OldY = new List<int>();
            List<int> OldX = new List<int>();
                         /*
                        OldY.Add(123);
                        OldY.Add(312);
                        Console.WriteLine("y at 0"+ OldY.ElementAt(1));
                         Console.ReadLine();    

                         OldY.Add(1);
                        Console.WriteLine("capa");
                        Console.WriteLine(OldX.Count);
                        Console.WriteLine(OldY.Count);
                        Console.ReadLine();
                        */

            int currentVert;
            int currentHor;
            int vert;
            int hor;
            int [,]oldSpaces = new int[200,2];

            string dirString;
            Random rnd = new Random();          
            dirString = "O";
            vert = 0;
            hor = 0;
            
            double TimeElapsed;
            TimeElapsed = 0;
            //initialisoi peli
            bool Alive = true;
            currentHor = 2;
            currentVert = 4;

            System.Timers.Timer timer = new System.Timers.Timer(200);
             timer.Enabled = true;
             timer.Start();

                                     // riviä, saraketta
                                    //vert hor
            char[,] area = new char[10, 20];
            

            Console.WriteLine(area.GetLength(0));
            Console.WriteLine("Here");

            for (int i = 0;i < area.GetLength(0); i++)// tehdään sarake 1,2,3
            {
                        for (int j = 0; j < area.GetLength(1); j++) // rivi sarake 1,2,3
                            {
                                area[i, j] = 'x';
                            Console.Write(area[0, j]);

                            }
                Console.WriteLine("");
            }

            Stopwatch t = new Stopwatch();
            Console.WriteLine("START");
            Console.ReadLine();
            int round = 0;
            int score = 0;
            int y = 0;
            area[6, 7] = 'o';
            while (Alive)
            {
                //round++;
                //Console.WriteLine(round);

                t.Start();
                TimeSpan ts = t.Elapsed;
                TimeElapsed = ts.Seconds;
     
                if (GetAsyncKeyState(38) != 0 && dirString != "Down")
                {
                    vert = -1;
                    hor = 0;
                    dirString = "Up";
                   // Console.WriteLine("UP");
                }
                else if (GetAsyncKeyState(40) != 0 && dirString != "Up")
                {
                    vert = 1;
                    hor = 0;
                    dirString = "Down";
                    // Console.WriteLine("DOWN");
                }

                else if (GetAsyncKeyState(39) != 0 && dirString != "Left")
                {
                    vert = 0;
                    hor = 1;
                    dirString = "Right";
                    //Console.WriteLine("RIGHT");
                }
               
                else if (GetAsyncKeyState(37) != 0 && dirString != "Right")
                {
                    vert = 0;
                    hor = -1;
                    dirString = "Left";
                  //  Console.WriteLine("LEFT");
                }
                
                if (TimeElapsed > 0.1)//_________________________________________________________________________________________________
                {
                    t.Reset();
                    TimeElapsed = 0;

                    
                    Console.WriteLine("current"+currentVert+" "+currentHor);
                    //[rivi,sarake]
                    //[]

                    area[currentVert, currentHor] = 'x';

                    if(area[currentVert + vert, currentHor + hor] == 'o')
                    {
                        score++;
                        int NewScoreVert = rnd.Next(0, 10);
                        int NewScoreHort = rnd.Next(0, 20);
                        area[NewScoreVert, NewScoreVert] = 'o';
                    }
                    //drew current head space

                    area[currentVert + vert,currentHor + hor] = '■';

                    currentVert = currentVert + vert;
                    currentHor = currentHor + hor;


                    OldY.Add(currentVert);
                    OldX.Add(currentHor);
                    oldSpaces[y, 0] = currentVert;
                    oldSpaces[y, 1] = currentHor;

                    OldY.Add(currentVert);
                    OldX.Add(currentHor);
                    for (int i = 0; i < score; i++)
                    {
                        //area[currentVert, currentHor] = 'x';
                       

                        for(int j = 0; j < score; j++) {//make head
                            Console.WriteLine("J:" +j+"index"+OldY.ElementAt(OldY.Count - 1) +" "+ OldX.ElementAt(OldX.Count - 1));
                            //Console.WriteLine((area[oldSpaces[y, 0] - vert, oldSpaces[y, 1] - hor]));
                            //Console.WriteLine(area[oldSpaces[y, 0] - vert, oldSpaces[y, 1] - hor]);
                            area[OldY.ElementAt(OldY.Count-1), OldX.ElementAt(OldX.Count-1)] = 'P';
                            area[OldX.ElementAt(OldY.Count - score - 1), OldX.ElementAt(OldX.Count - score - 1)] = 'x';

                            Console.WriteLine("to x:" + OldX.ElementAt(OldY.ElementAt(score) - score) + " " + OldX.ElementAt(OldX.ElementAt(score) - score));
                            
                           
                            //Console.ReadLine();
                        }

                        //area[oldSpaces[y, 0]-vert, oldSpaces[y, 1]-hor] = '■';
                    }

                    display(area,dirString);
                    
                    
                    //Console.WriteLine("ver:"+vert + "hor:"+hor+"score"+score);
                    Console.WriteLine(currentVert + " " + currentHor);
                    //Console.WriteLine(area[oldSpaces[y, 0] - vert, oldSpaces[y, 1] - hor]);

                    for(int i = 0; i < y; i++)
                     {
                         Console.Write(" "+OldY[i]);
                         Console.Write(OldX[i]);
                     }
                    y++;
                }




            }



        }

   }

        
}

