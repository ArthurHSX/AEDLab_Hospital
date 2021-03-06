﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static Lista lista = new Lista();
        static bool leito = false, enfermaria = false, cti = false, uti = false;

        static void Main(string[] args)
        {
            int contLeito = 0, contEnf = 0, contUT = 0, contCT = 0, rnd = 0;
            Random random = new Random();
            Paciente p;

            while (lista.Primeiro != null)
            {
                InterfaceHospital();                
                rnd = random.Next(0, 3);                
                if ((lista.Count() + rnd) <= 15)
                {
                    for (int i = 0; i < rnd; i++)
                    {
                        p = new Paciente(); lista.Inserir(p);                        
                    }
                }                
                InterfaceHospital();
                System.Threading.Thread.Sleep(1000);

                if (cti == false || contCT == 5)
                {
                    if (contCT == 5)
                    {
                        cti = false; contCT = 0;
                    }
                    if (lista.Busca(4, lista.Primeiro.Proximo))
                    {
                        lista.RetiraPPrioridade(4);
                        cti = true;
                    }
                }
                if (uti == false || contUT == 4)
                {
                    if (contUT == 4)
                    {
                        uti = false; contUT = 0;
                    }
                    if (lista.Busca(3, lista.Primeiro.Proximo))
                    {
                        lista.RetiraPPrioridade(3); uti = true;
                    }

                }
                if (enfermaria == false || contEnf == 2)
                {
                    if (contEnf == 2)
                    {
                        enfermaria = false; contEnf = 0;
                    }
                    if (lista.Busca(2, lista.Primeiro.Proximo))
                    {
                        lista.RetiraPPrioridade(2); enfermaria = true;
                    }

                }
                if (leito == false || contLeito == 1)
                {
                    if (contLeito == 1)
                    {
                        leito = false; contLeito = 0;
                    }
                    if (lista.Busca(1, lista.Primeiro.Proximo))
                    {
                        lista.RetiraPPrioridade(1); leito = true;
                    }
                }               
                
                InterfaceHospital();
                System.Threading.Thread.Sleep(1000);

                if (cti == true)
                    contCT++;
                if (uti == true)
                    contUT++;
                if (enfermaria == true)
                    contEnf++;
                if (leito == true)
                    contLeito++;
                System.Threading.Thread.Sleep(1500);
            }

        }
        static void InterfaceHospital()
        {
            string texto1 = "Disponível", texto2 = "Disponível", texto3 = "Disponível", texto4 = "Disponível";

            if (leito == true)
                texto1 = "Em atendimento";
            if (enfermaria == true)
                texto2 = "Em atendimento";
            if (uti == true)
                texto3 = "Em atendimento";
            if (cti == true)
                texto4 = "Em atendimento";

            Console.Clear();
            Console.WriteLine("-----------------------------------  HOSPITAL  ---------------------------------\n\n" +
                              "Número de pacientes em espera: {0}                \n" +
                              "                                                 \n" +
                              "Leito: {1}\n\nEnfermaria: {2}\n\nUTI: {3}\n\nCTI: {4}  ",
                              lista.Count(), texto1, texto2, texto3, texto4);
        }
    }
}
