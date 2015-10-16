using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;
using H.Core.DataAccess;

namespace H.Website.IISHost.Pages.ClubMembers
{
    public partial class Data : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            QueryCondition<ClubMembersEntity> query = new QueryCondition<ClubMembersEntity>();
            query.PagingInfo = new PagingInfo() { PageSize = 1000, PageIndex = 1 };
            query.Condition = new ClubMembersEntity();
            List<ClubMembersEntity> list = ClubMemberFacade.Search(query);
            BindSmallImage(list);
            BindBigImage(list);
        }

        public void BindSmallImage(List<ClubMembersEntity> list) {
            list.ForEach(x => {
                lit_smallImage.Text += "<li class=\"item\"><a href=\"#\"><img src=\"" + H.Core.Utility.WebConfig.UploadImageUrl + x.SmallImageUrl + "\" alt=\""+x.Title+"\" /></a></li>\r\n";
            });
        }

        public void BindBigImage(List<ClubMembersEntity> list)
        {
            list.ForEach(x =>
            {
                lit_bigImage.Text += "<li class=\"item--big\"><a href=\"#\"><figure><img src=\"" + H.Core.Utility.WebConfig.UploadImageUrl+ x.BigImageUrl + "\" alt=\"" + x.Title + "\" /><figcaption class=\"img-caption\">" + x.Title + "</figcaption></figure></a></li>\r\n";
            });
        }
    }
}