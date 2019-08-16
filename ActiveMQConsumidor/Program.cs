using System;
using System.Threading;

namespace ActiveMQConsumidor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ActiveMQConsumidor activeMQ = new ActiveMQConsumidor();
                activeMQ.InicializaAMQ();
                while (Thread.CurrentThread.IsAlive)
                {
                    activeMQ.ConsumidorFila();
                    //activeMQ.ConsumidorTopico();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
