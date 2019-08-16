using System;
using System.Threading;

namespace ActiveMQProdutor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ActiveMQProdutor activeMQ = new ActiveMQProdutor();
                activeMQ.InicializaAMQ();
                while (Thread.CurrentThread.IsAlive)
                {
                    activeMQ.ProdutorFila();
                    //activeMQ.ProdutorTopico();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
