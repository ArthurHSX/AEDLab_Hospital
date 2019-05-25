using System;
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
            int contLeito = 0, contEnf = 0, contUT = 0, contCT = 0;
            Random rnd = new Random();
            Paciente p = new Paciente(); lista.Inserir(p);

            while (lista.Primeiro != null)
            {
                InterfaceHospital();
                for (int i = 0; i < rnd.Next(0, 2); i++)
                {
                    p = new Paciente(); lista.Inserir(p);
                }
                InterfaceHospital();
                if (cti == false && contCT == 5)
                {
                    if (contCT == 5)
                    {
                        cti = false; contCT = 0;
                    }
                    if (lista.Busca(4, lista.Primeiro.Proximo))
                        lista.RetiraPPrioridade(4);
                    cti = true;
                }
                else if (uti == false || contUT == 4)
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
                else if (enfermaria == false || contEnf == 3)
                {
                    if (contEnf == 3)
                    {
                        uti = false; contEnf = 0;
                    }
                    if (lista.Busca(2, lista.Primeiro.Proximo))
                    {
                        lista.RetiraPPrioridade(2); enfermaria = true;
                    }

                }
                else if (leito == false || contLeito == 2)
                {
                    if (contLeito == 2)
                    {
                        leito = false; contLeito = 0;
                    }
                    if (lista.Busca(1, lista.Primeiro.Proximo))
                    {
                        lista.RetiraPPrioridade(1); leito = true;
                    }
                }
                InterfaceHospital();
                contLeito++; contEnf++; contUT++; contCT++;
                System.Threading.Thread.Sleep(2000);
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
            Console.WriteLine("------------------------------------  HOSPITAL  -----------------------------------\n\n" +
                              "Número de pacientes em espera: {0}                \n" +
                              "                                                 \n" +
                              "Leito: {1}\nEnfermaria: {2}\nUTI: {3}\nCTI: {4}  ",
                              lista.count, texto1, texto2, texto3, texto4);
        }
    }
}
