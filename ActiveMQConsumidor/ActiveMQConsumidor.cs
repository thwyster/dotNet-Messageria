using ActiveMQ.Base;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActiveMQConsumidor
{
    public class ActiveMQConsumidor
    {
        private IConnection _conexao;
        private ISession _sessao;
        private const String FILA = "FILA 1";
        private const String TOPICO = "TOPICO";

        public void InicializaAMQ()
        {
            Console.WriteLine("Inicializando conexão ActiveMQ");
            IConnectionFactory factory = new ConnectionFactory("tcp://127.0.0.1:61616");
            _conexao = factory.CreateConnection();
            _conexao.Start();
            _sessao = _conexao.CreateSession();
        }

        public void FinalizaAMQ()
        {
            Console.WriteLine("Finalizando conexão ActiveMQ");
            _sessao.Close();
            _conexao.Close();
        }

        public void ConsumidorFila()
        {
            try
            {
                //Console.WriteLine("----------- CONSUMIDOR -----------");
                Mensagem mensagem = null;
                IDestination dest = _sessao.GetQueue(FILA);
                using (IMessageConsumer consumer = _sessao.CreateConsumer(dest))
                {
                    IMessage message;
                    while ((message = consumer.Receive(TimeSpan.FromMilliseconds(10))) != null)
                    {
                        //Thread.Sleep(100);

                        var objectMessage = message as IObjectMessage;
                        if (objectMessage != null)
                        {
                            mensagem = objectMessage.Body as Mensagem;
                            if (mensagem != null)
                                Console.WriteLine($"{Thread.CurrentThread.Name} - Lendo na {FILA} => '{mensagem.Message}'");
                        }
                        else
                            Console.WriteLine("Object Message é NULO");
                    }
                }
                if (mensagem == null)
                    Console.WriteLine("Mensagem é nula");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConsumidorTopico()
        {
            try
            {
                //Console.WriteLine("----------- CONSUMIDOR -----------");
                Mensagem mensagem = null;
                IDestination dest = _sessao.GetTopic(TOPICO);
                using (IMessageConsumer consumer = _sessao.CreateConsumer(dest))
                {
                    IMessage message;
                    while ((message = consumer.Receive(TimeSpan.FromMilliseconds(10))) != null)
                    {
                        //Thread.Sleep(100);

                        var objectMessage = message as IObjectMessage;
                        if (objectMessage != null)
                        {
                            mensagem = objectMessage.Body as Mensagem;
                            if (mensagem != null)
                                Console.WriteLine($"{Thread.CurrentThread.Name} - Lendo no {TOPICO} => '{mensagem.Message}'");
                        }
                        else
                            Console.WriteLine("Object Message é NULO");
                    }
                }
                if (mensagem == null)
                    Console.WriteLine("Mensagem é nula");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
