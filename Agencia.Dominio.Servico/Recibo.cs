using System;

namespace Agencia.Dominio.Servico
{
    static public class Recibo
    {
        // Modelo do recibo: 2013 + 06 + 21 + 19 + 05
		// ano + 2 zeros + mes + dia + hora + minuto
		// 20130006211905

        static public string Numero(DateTime dtbaixa)
        {
            try
            {
                var ano = Convert.ToString(dtbaixa.Year);
                var mes = String.Format("{0:00}", Convert.ToInt32(dtbaixa.Month));
                var dia = String.Format("{0:00}", Convert.ToInt32(dtbaixa.Day));
                //var hora = DateTime.Now.Hour;
                //var minuto = DateTime.Now.Minute;
                //var segundo = DateTime.Now.Second;

                var dat = DateTime.Now.ToLongTimeString();
                var hora = dat.Replace(":", "");

                return ano + mes + dia + hora;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
