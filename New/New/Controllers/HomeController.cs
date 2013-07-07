using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace New.Controllers
{
    
    
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public async Task<ActionResult> Index()
        {
            var faceBookCount = await GetFacebookCommentCountAsync();
            var commentCount = await GetFacebookLikeCountAsync();
            var faceBookStatus = new FaceBookStatus()
                {
                    FaceBookCount = faceBookCount,
                    CommentCount = commentCount
                };

            return View(faceBookStatus);
        }

        public Task<int> GetFacebookCommentCountAsync()
        {
            
            return Task<int>.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    return 20;
                });
        }

        public Task<int> GetFacebookLikeCountAsync()
        {
            return Task<int>.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    return 25;
                });
        }

    }

    public class FaceBookStatus
    {
        public int FaceBookCount { get; set; }

        public int CommentCount { get; set; }
    }
}
