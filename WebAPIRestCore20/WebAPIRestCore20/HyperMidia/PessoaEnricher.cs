using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapioca.HATEOAS;
using WebAPIRestCore20.Data.VO;

namespace WebAPIRestCore20.HyperMidia
{
    public class PessoaEnricher : ObjectContentResponseEnricher<PessoaVO>
    {

        private readonly object _lock = new object();

        protected override Task EnrichModel(PessoaVO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/pessoa";
            var url = new { controller = path, id = content.Id };
            string link = getLink(urlHelper, path);
            string linkWithId = getLink(content, urlHelper, path);

            //content.Links.Add(new HyperMediaLink()
            //{
            //    Action = HttpActionVerb.GET,
            //    Href = urlHelper.Link("DefaultApi", url),
            //    Rel = RelationType.self,
            //    Type = ResponseTypeFormat.DefaultGet
            //});

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = linkWithId,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = linkWithId,
                Rel = RelationType.self,
                Type = "int",
            });

            return null;
        }

        private string getLink(IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).ToString();
            }
        }

        private string getLink(PessoaVO content, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = content.Id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).ToString();
            }
        }
    }
}
