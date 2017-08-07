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
            var tsc = new TalkNoteServiceClient();
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
