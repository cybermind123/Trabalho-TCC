using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes.Extras
{
    class Contas
    {
        public double SalarioLiquido,
            MesValor,
            ValorHora,
            ValorHora50,
            ValorHora100,
            ValorTrab50,
            ValorTrab100,
            ValorINSS,
            IR,
            DeducaoIR,
            ValorIR,
            ValorFGTS,
            ValorValeRefeicao,
            ValorValeTransposte,
            ToltalDeProventos,
            TotalDeDescontos;



        public double Calculo(double salariobruto, int DiasTrabMes, int numerodediasdomes, int HorasTrab50, int HorasTrab100)
        {

            //Mes/Valor
            MesValor = (salariobruto / numerodediasdomes) * DiasTrabMes;

            //Valor hora 
            ValorHora = salariobruto / 220;

            //Valor/hora 50%
            ValorHora50 = ValorHora + (ValorHora * 0.5);

            //Valor/hora 100%
            ValorHora100 = ValorHora + (ValorHora * 1);

            //Valor trab 50%
            ValorTrab50 = HorasTrab50 * ValorHora50;

            //Valor trab 100%
            ValorHora100 = HorasTrab100 * ValorHora100;

            //valor INSS
            if (salariobruto <= 1693.73)
            {
                ValorINSS = salariobruto * 0.08;
            }
            else if (salariobruto > 1693.73 && salariobruto < 2822.91
)
            {
                ValorINSS = salariobruto * 0.09;
            }
            else if (salariobruto >= 2822.91)
            {
                ValorINSS = salariobruto * 0.11;
            }

            //IR - coluna de aliquota 
            if (salariobruto == 0)
            {
                IR = salariobruto * 0;
                DeducaoIR = 0;
                // Valor ir 
                ValorIR = IR - DeducaoIR;

            }
            else if (salariobruto < 1903.98 && salariobruto > 0)
            {
                IR = salariobruto * 0.075;
                DeducaoIR = 142.80;
                // Valor ir 
                ValorIR = IR - DeducaoIR;

            }
            else if (salariobruto == 2826.65)
            {
                IR = salariobruto * 0.15;
                DeducaoIR = 354.80;
                // Valor ir 
                ValorIR = IR - DeducaoIR;

            }
            else if (salariobruto == 3751.05)
            {
                IR = salariobruto * 0.02250;
                DeducaoIR = 636.13;
                // Valor ir 
                ValorIR = IR - DeducaoIR;

            }
            else if (salariobruto == 4664.68)
            {
                IR = salariobruto * 0.275;
                DeducaoIR = 869.36;
                // Valor ir 
                ValorIR = IR - DeducaoIR;

            }

            else { }

            //Valor fgts
            ValorFGTS = salariobruto * 0.08;

            // Valor vale refeição
            ValorValeRefeicao = salariobruto * 0.08;

            //Valor Vale transporte 
            ValorValeTransposte = salariobruto * 0.06;

            //Valor de proventos 
            ToltalDeProventos = MesValor + ValorTrab50 + ValorTrab100 + DeducaoIR;

            // valor total de descontos 
            TotalDeDescontos = ValorINSS + IR + ValorIR + ValorFGTS + ValorValeRefeicao + ValorValeTransposte;

            //valor salario liquido 
            SalarioLiquido = ToltalDeProventos - TotalDeDescontos;



            return SalarioLiquido;
        }



    }

}


    

