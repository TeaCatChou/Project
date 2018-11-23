//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            this.TaskDetail = new HashSet<TaskDetail>();
            this.TaskModified = new HashSet<TaskModified>();
            this.TaskResource = new HashSet<TaskResource>();
        }
    
        public Nullable<System.Guid> ProjectGUID { get; set; }
        public System.Guid TaskGUID { get; set; }
        public Nullable<System.Guid> ParentTaskGUID { get; set; }
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public Nullable<System.DateTime> EstStartDate { get; set; }
        public Nullable<System.DateTime> EstEndDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> EstWorkTime { get; set; }
        public Nullable<int> WorkTime { get; set; }
        public Nullable<int> TaskStatusID { get; set; }
        public Nullable<System.Guid> EmployeeGUID { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public Nullable<int> TaskStatusIDChanged { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual PreTasks PreTasks { get; set; }
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskDetail> TaskDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskModified> TaskModified { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskResource> TaskResource { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }
    }
}