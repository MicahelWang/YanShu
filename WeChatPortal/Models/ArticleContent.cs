//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeChatPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArticleContent
    {
        public int ArticleID { get; set; }
        public int ContentID { get; set; }
        public int Sort { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Content Content { get; set; }
    }
}
