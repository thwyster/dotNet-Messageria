using System;
using System.Threading;

namespace ActiveMQConsumidor
{
    class Program
    {
        static void Main()
        {
            try
            {
                ActiveMQConsumidor activeMQ = new ActiveMQConsumidor();
                activeMQ.InicializaAMQ();
                while (Thread.CurrentThread.IsAlive)
                {
                    //activeMQ.ConsumidorFila();
                    activeMQ.ConsumidorTopico();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ACTIVEMQ - {ex.Message}");
                Console.WriteLine($"Reiniciando Serviço");
                Main();
            }
        }
    }
}
