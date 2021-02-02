using System;
using System.Collections.Generic;

namespace AlnaSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            Task2();
        }

        static void Task1()
        {
            double valandos = -1;
            double minutes = -1;
            double laipsniaiVienaiValandai = 360 / 12;
            double laipsniaiVienaiMinutei = 360 / 60;

            Console.WriteLine("Įveskite valandas:");

            while (valandos == -1)
            {
                try
                {
                    valandos = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Neteisingi duomenys. Bandykite dar kartą.");
                }
            }

            Console.WriteLine("Įveskite minutes:");

            while (minutes == -1)
            {
                try
                {
                    minutes = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Neteisingi duomenys. Bandykite dar kartą.");
                }
            }

            if (valandos == 12)
            {
                valandos = 0;
            }
            if (minutes == 60)
            {
                minutes = 0;
            }

            Console.WriteLine("Kampas tarp rodyklių:");

            //is valandu rodykles atsilenkimo kampo nuo 12 atimamas minučiu rodiklių atsilenkimo kampas
            double kampas = Math.Abs(valandos * laipsniaiVienaiValandai + 0.5 * minutes - minutes * laipsniaiVienaiMinutei);

            // Reikalingas mažesnis kampas, todel
            // jei gautas kampas yra didesnis uz 180 laipsnių
            // reiskia, kad gautas didysis kampas
            // Kad gauti mazaji kampa reikia is 360 atimti gautaji kampa
            if (kampas > 180)
            {
                kampas = 360 - kampas;
            }
            Console.WriteLine(kampas);
        }

        static void Task2()
        {
            Saka saknis = new Saka();
            sukurtiMedzioStruktura2(saknis);

            int pradinisGylis = 1;
            int pradinisDidziausiasGylis = 1;

            Console.WriteLine(rekursija(saknis, pradinisDidziausiasGylis, pradinisGylis));
        }

        /// <summary>
        /// Surandmas giliausias lygmuo naudojant rekursija
        /// </summary>
        /// <param name="saka">dabartine saka</param>
        /// <param name="gyliausiasLygmuo"></param>
        /// <param name="dabartinisLygmuo"></param>
        /// <returns></returns>
        static int rekursija(Saka saka, int gyliausiasLygmuo, int dabartinisLygmuo)
        {

            // jei saka turi daugiau saku kvieciamas rekursijos metodas
            // ir padidinamas lygmuo
            foreach (Saka _saka in saka.gautiSakas())
            {
                gyliausiasLygmuo = rekursija(_saka, gyliausiasLygmuo, ++dabartinisLygmuo);

                //griztant atgal lygmuo mazinamas
                dabartinisLygmuo--;
            }

            //esant paskutineje grandines sakoje tikrinama ar 
            //dabartinis lygmuo yra mazesnis uz iki siol esama
            // gyliausia lygmeni, jei taip, gyliausio lygmens reiksme
            //pakeiciama
            if (dabartinisLygmuo > gyliausiasLygmuo)
            {
                gyliausiasLygmuo = dabartinisLygmuo;
            }

            return gyliausiasLygmuo;

        }
        static void sukurtiMedzioStruktura(Saka saka)
        {
            Saka saka2 = new Saka();
            Saka saka3 = new Saka();
            Saka saka4 = new Saka();
            Saka saka5 = new Saka();
            Saka saka6 = new Saka();
            Saka saka7 = new Saka();
            Saka saka8 = new Saka();
            Saka saka9 = new Saka();
            Saka saka10 = new Saka();
            Saka saka11 = new Saka();

            saka.pridetiSaka(saka2);
            saka2.pridetiSaka(saka3);

            saka3.pridetiSaka(saka4);

            saka4.pridetiSaka(saka5);
            saka5.pridetiSaka(saka6);
            saka6.pridetiSaka(saka7);

            saka7.pridetiSaka(saka8);

            saka8.pridetiSaka(saka9);
            saka9.pridetiSaka(saka10);

            saka10.pridetiSaka(saka11);
        }

        /// <summary>
        /// Sukuriama medzio struktura
        /// </summary>
        /// <param name="saka">Medzio saknis prie kurios pridedamos kitos sakos</param>
        static void sukurtiMedzioStruktura2(Saka saka)
        {
            List<Saka> sakos = new List<Saka>();
            for (int i = 0; i <= 14; i++)
            {
                sakos.Add(new Saka());
            }

            saka.pridetiSaka(sakos[0]);
            saka.pridetiSaka(sakos[1]);
            saka.pridetiSaka(sakos[2]);

            sakos[0].pridetiSaka(sakos[3]);
            sakos[0].pridetiSaka(sakos[4]);

            sakos[1].pridetiSaka(sakos[5]);

            sakos[4].pridetiSaka(sakos[6]);
            sakos[4].pridetiSaka(sakos[7]);

            sakos[5].pridetiSaka(sakos[8]);
            sakos[5].pridetiSaka(sakos[9]);

            sakos[7].pridetiSaka(sakos[10]);

            sakos[9].pridetiSaka(sakos[11]);
            sakos[9].pridetiSaka(sakos[12]);

            sakos[11].pridetiSaka(sakos[13]);
            sakos[11].pridetiSaka(sakos[14]);
        }

    }

    class Saka
    {
        List<Saka> sakos = new List<Saka>();
        public void pridetiSaka(Saka saka)
        {
            sakos.Add(saka);
        }
        public List<Saka> gautiSakas()
        {
            return sakos;
        }
    }
}
