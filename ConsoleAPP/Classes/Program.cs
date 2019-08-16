using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.CurrentThread.Name = "Thread Principal";
                Console.WriteLine("Iniciando aplicação Thread Principal...");

                ActiveMQ activeMQ = new ActiveMQ();
                activeMQ.InicializaAMQ();
                while (Thread.CurrentThread.IsAlive)
                {
                    //Com Threads
                    //IniciaThreadProdutor(activeMQ);
                    //IniciaThreadConsumidor(activeMQ);

                    //Sem Threads
                    //activeMQ.ProdutorFila();
                    //activeMQ.ConsumidorFila();

                    activeMQ.ProdutorTopico();
                }

                activeMQ.FinalizaAMQ();
                Console.WriteLine("Finalizando aplicação Thread Principal...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void IniciaThreadProdutor(ActiveMQ activeMQ)
        {
            //Forma padrao
            //ThreadStart tsProdutor = delegate { activeMQ.Produtor(); };
            //Thread threadProdutor = new Thread(tsProdutor);
            //threadProdutor.Name = "Thread Produtor";
            //threadProdutor.Start();

            //forma com lambda
            new Thread(() =>
            {
                Thread.CurrentThread.Name = "Thread Produtor";
                activeMQ.ProdutorFila();
            }).Start();
        }

        public static void IniciaThreadConsumidor(ActiveMQ activeMQ)
        {
            //ThreadStart tsConsumidor = delegate { activeMQ.Consumidor(); };
            //Thread threadConsumidor = new Thread(tsConsumidor);
            //threadConsumidor.Name = "Thread Consumidor";
            //threadConsumidor.Start();

            //forma com lambda
            new Thread(() =>
            {
                Thread.CurrentThread.Name = "Thread Consumidor";
                activeMQ.ConsumidorFila();
            }).Start();
        }
    }
}
