//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blacklist
    {
        public int BlacklistEntryId { get; set; }
        public int UserId { get; set; }
        public int BlockedUserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
