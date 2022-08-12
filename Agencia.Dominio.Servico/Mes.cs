using System;

namespace Agencia.Dominio.Servico
{
    static public class Mes
    {
        static public class Retorna
        {
            static public int MesNumero(string smes)
            {
                switch (smes)
                {
                    case "JANEIRO":
                        return 1;
                    case "FEVEREIRO":
                        return 2;
                    case "MARÇO":
                        return 3;
                    case "ABRIL":
                        return 4;
                    case "MAIO":
                        return 5;
                    case "JUNHO":
                        return 6;
                    case "JULHO":
                        return 7;
                    case "AGOSTO":
                        return 8;
                    case "SETEMBRO":
                        return 9;
                    case "OUTUBRO":
                        return 10;
                    case "NOVEMBRO":
                        return 11;
                    case "DEZEMBRO":
                        return 12;
                }

                return 0;
            }

            static public DateTime PrimeiroDia(int smes)
            {
                return Convert.ToDateTime("01" + "/" + smes + "/" + DateTime.Now.Year);

            }

            static public DateTime ULtimoDia(int smes)
            {
                return Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Now.Year, smes) + "/" + smes + "/" + DateTime.Now.Year);

            }
        }

    }
}
