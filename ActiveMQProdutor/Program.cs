using System;
using System.Threading;

namespace ActiveMQProdutor
{
    class Program
    {
        static void Main()
        {
            try
            {
                ActiveMQProdutor activeMQ = new ActiveMQProdutor();
                activeMQ.InicializaAMQ();
                while (Thread.CurrentThread.IsAlive)
                {
                    //activeMQ.ProdutorFila();
                    activeMQ.ProdutorTopico();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ACTIVEMQ - {ex.Message}");
                Console.WriteLine($"Reiniciando Serviço" );
                Main();
            }
        }
    }
}
