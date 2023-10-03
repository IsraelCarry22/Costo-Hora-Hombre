using System;

namespace Costo_Hora_Hombre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Salario_Diario = 0, Aguinaldo = 0, Vacaciones = 0, Dias_Festivos = 0;
            double Prima_Vacacional = 0, Riesgo_Trabajo = 0;
            Console.Write("Ingresa tu salario: ");
            Salario_Diario = int.Parse(Console.ReadLine());
            Console.Write("Ingresa tu aguinaldo: ");
            Aguinaldo = int.Parse(Console.ReadLine());
            Console.Write("Ingresa el numero de dias de vacaciones: ");
            Vacaciones = int.Parse(Console.ReadLine());
            Console.Write("Ingresa el numero de dias festivos: ");
            Dias_Festivos = int.Parse(Console.ReadLine());
            Console.Write("Ingresa el porcentaje de prima vacacinal: ");
            Prima_Vacacional = double.Parse(Console.ReadLine());
            Console.Write("Ingresa el porcentaje de riesgo de trabajo: ");
            Riesgo_Trabajo = double.Parse(Console.ReadLine());

            CalcularCostoHoraHombre(Salario_Diario, Aguinaldo, Vacaciones, Dias_Festivos, Prima_Vacacional, Riesgo_Trabajo);
            Console.ReadKey();
        }

        private static void CalcularCostoHoraHombre(int salario_Diario, int aguinaldo, int vacaciones, int dias_Festivos, double prima_Vacacional, double riesgo_Trabajo)
        {
            //Factor de integracion
            double FI = (aguinaldo + (vacaciones * prima_Vacacional)) / 365;
            double FI_MR = Math.Round(FI, 2);

            //Salario diario intergrado
            double SDI = ((salario_Diario * FI_MR) + salario_Diario);
            double SDI_MR = Math.Round(SDI, 2);

            //Cuota
            double C = 103.74 * 0.20;
            double C_MR = Math.Round(C, 2);

            //Excedentes
            double[] excedentes = new double[3];
            excedentes[0] = (SDI_MR - (3 * 103.74)) * 0.0110;
            if (excedentes[0] < 0)
            {
                excedentes[0] = 0;
            }
            excedentes[1] = (SDI_MR * 0.0965);
            excedentes[2] = (SDI_MR * riesgo_Trabajo);
            excedentes[0] = Math.Round(excedentes[0], 2);
            excedentes[1] = Math.Round(excedentes[1], 2);
            excedentes[2] = Math.Round(excedentes[2], 2);

            //Cuota Patronal IMSS
            double CPI = C + excedentes[0] + excedentes[1] + excedentes[2];
            double CPI_MR = Math.Round(CPI, 2);

            //Aguinaldo
            double Agui = (salario_Diario * aguinaldo) / 365;
            double Agui_MR = Math.Round(Agui, 2);

            //Prima vacacional
            double PV = ((salario_Diario * vacaciones) * prima_Vacacional) / 365;
            double PV_MR = Math.Round(PV, 2);

            //Infonavid
            double IFO = SDI_MR * 0.05;
            double IFO_MR = Math.Round(IFO, 2);

            //ISN
            double ISN = SDI_MR * 0.02;
            double ISN_MR = Math.Round(ISN, 2);

            //Dias laborables
            int DL = 365 - vacaciones - dias_Festivos - 52;

            //Costo mano de obra
            double CMO = salario_Diario + Agui + PV + CPI + IFO + ISN;
            double CMO_MR = Math.Round(CMO, 2);

            //Costo H/Hombre
            double CHH = ((CMO * 365) / DL) / 8;
            double CHH_MR = Math.Round(CHH, 2);

            Console.Clear();
            Console.WriteLine("==============Resultados==============\n");
            Console.WriteLine("- Factor de integracion: " + FI_MR);
            Console.WriteLine("- Salario diario integrado: " + SDI_MR);
            Console.WriteLine("- Cuota: " + C_MR);
            Console.WriteLine("- Excedentes 1: " + excedentes[0]);
            Console.WriteLine("- Excedentes 2: " + excedentes[1]);
            Console.WriteLine("- Excedentes 3: " + excedentes[2]);
            Console.WriteLine("- Cuota pratonal del imss: " + CPI_MR);
            Console.WriteLine("- Aguinaldo: " + Agui_MR);
            Console.WriteLine("- Prima Vacacional: " + PV_MR);
            Console.WriteLine("- Infonavid: " + IFO_MR);
            Console.WriteLine("- ISN: " + ISN_MR);
            Console.WriteLine("- Dias laborables: " + DL);
            Console.WriteLine("- Costo de mano de hobra: " + CMO_MR);
            Console.WriteLine("- Costo H/Hombre: " + CHH_MR);
            Console.WriteLine("\n======================================");
        }
    }
}