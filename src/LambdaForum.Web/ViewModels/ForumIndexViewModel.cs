using System.Collections.Generic;

namespace LambdaForum.Web.ViewModels
{
    public class ForumIndexViewModel
    {
        public IEnumerable<ForumListViewModel> ForumList { get; set; }
    }
}
