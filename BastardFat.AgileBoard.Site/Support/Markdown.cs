using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BastardFat.AgileBoard.Site.Support
{
    public static class Markdown
    {
        public static string ToHtml(string markdown)
        {
            var s = CommonMark.CommonMarkSettings.Default.Clone();
            s.RenderSoftLineBreaksAsLineBreaks = true;
            return CommonMark.CommonMarkConverter.Convert(markdown, s);
        }
    }
}