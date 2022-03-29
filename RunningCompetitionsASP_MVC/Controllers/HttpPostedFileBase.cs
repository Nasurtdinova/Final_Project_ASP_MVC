using System.IO;

namespace RunningCompetitionsASP_MVC.Controllers
{
    public class HttpPostedFileBase
    {
        public Stream InputStream { get; internal set; }
        public int ContentLength { get; internal set; }
    }
}