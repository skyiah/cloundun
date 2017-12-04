using Greatbone.Core;

namespace Greatbone.Samp
{
    public abstract class SlideWork<V> : Work where V : SlideVarWork
    {
        protected SlideWork(WorkContext wc) : base(wc)
        {
        }
    }

    [Ui("客服"), Auth(User.OPR)]
    public class AdmSlideWork : SlideWork<AdmSlideVarWork>
    {
        public AdmSlideWork(WorkContext wc) : base(wc)
        {
            CreateVar<AdmSlideVarWork, string>((obj) => ((Slide)obj).no);
        }

        public void @default(ActionContext ac)
        {
            string shopid = ac[typeof(ShopVarWork)];
            using (var dc = ac.NewDbContext())
            {
                dc.Query("SELECT * FROM slides WHERE shopid = @1", p => p.Set(shopid));
                ac.GiveBoardPage(200, dc.ToArray<Slide>(), (h, o) => { });
            }
        }
    }
}