using System.Web.Http;

namespace ActiveMQ.WebProdutor.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public void Get()
        {
            ActiveMQProdutor activeMQ = new ActiveMQProdutor();
            activeMQ.InicializaAMQ();
            activeMQ.ProdutorTopico();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
