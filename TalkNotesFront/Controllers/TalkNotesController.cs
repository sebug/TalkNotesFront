using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Tracing;
using TalkNotesFront.Services;

namespace TalkNotesFront.Controllers
{
    public class TalkNotesController : ApiController
    {
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            string address = System.IO.File.ReadAllText("C:\\TalkNotesFront\\address.txt");
            Configuration.Services.GetTraceWriter().Debug(this.Request, "System.Web.Http.Controllers", "Calling Service " + address + " to obtain talk notes.");
            var tsc = new TalkNoteServiceClient("BasicHttpBinding_ITalkNoteService", address);
            var talkNotes = await tsc.GetAllAsync();
            return talkNotes.Select(tn => tn.Title);
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
