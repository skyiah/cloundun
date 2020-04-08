using CloudUn.Web;

namespace CloudUn.Net
{
    [Ui("Blocks")]
    public class BlockWork : WebWork
    {
        public void @default(WebContext wc)
        {
            wc.GivePage(200, h =>
            {
                h.TOOLBAR();
                h.FORM_("uk-card uk-card-primary");
                h._UL();
                h._FORM();
            });
        }

        [Ui("&#128269;"), Tool(Modal.AnchorPrompt)]
        public void search(WebContext wc)
        {
        }
    }
}