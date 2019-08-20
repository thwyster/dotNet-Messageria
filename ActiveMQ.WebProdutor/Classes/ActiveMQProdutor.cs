using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace ActiveMQ.WebProdutor
{
    public class ActiveMQProdutor
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

        public void ProdutorFila()
        {
            try
            {
                //Console.WriteLine("------------ PRODUTOR ------------");

                IDestination dest = _sessao.GetQueue(FILA);
                using (IMessageProducer producer = _sessao.CreateProducer(dest))
                {
                    for (int i = 1; i < 101; i++)
                    {
                        Thread.Sleep(100);

                        var mensagem = new Mensagem
                        {
                            Message = $"Mensagem {i}",
                        };

                        var objectMessage = producer.CreateObjectMessage(JsonConvert.SerializeObject(mensagem));
                        producer.Send(objectMessage);

                        Console.WriteLine($"{Thread.CurrentThread.Name} - Escrevendo na {FILA} => '{mensagem.Message}'");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ProdutorTopico()
        {
            try
            {
                //Console.WriteLine("------------ PRODUTOR ------------");

                IDestination dest = _sessao.GetTopic(TOPICO);
                using (IMessageProducer producer = _sessao.CreateProducer(dest))
                {
                    for (int i = 1; i < 101; i++)
                    {
                        Thread.Sleep(100);

                        var mensagem = new Mensagem
                        {
                            Message = $"Mensagem {i}",
                        };

                        var objectMessage = producer.CreateObjectMessage(JsonConvert.SerializeObject(mensagem));
                        producer.DeliveryMode = MsgDeliveryMode.NonPersistent;
                        producer.Send(objectMessage);

                        Console.WriteLine($"{Thread.CurrentThread.Name} - Escrevendo no {TOPICO} => '{mensagem.Message}'");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
