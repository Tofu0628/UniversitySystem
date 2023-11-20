using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UniSys.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Student_ID { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter student name")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Please select student gender")]
        public required bool Gender { get; set; }
        [StringLength(15, MinimumLength =10, ErrorMessage ="Please Enter Valid Phone Number")]
        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        [MaxLength(50)]
        [EmailAddress]
        [RegularExpression(@"^\b[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{2,3}\b$", ErrorMessage = "Please Enter Valid Email Address")]
        [Column(TypeName = "varchar(15)")]
        public string? Email { get; set; }
        [DefaultValue(false)]
        public required bool IsDelete { get; set; }
        [Display(Name = "Deleted Date")]
        [Column(TypeName = "datetime")]
        [DefaultValue(null)]
        public DateTime? IsDeletedDate { get; set; }
    }

    public class Tutor
    {
        [Key]
        public int Tutor_ID { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter tutor name")]
        public required string Name { get; set; }
        public required int Position { get; set; }
        [Required(ErrorMessage = "Please select tutor gender")]
        public required bool Gender { get; set; }
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please Enter Valid Phone Number")]
        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        [MaxLength(50)]
        [EmailAddress]
        [RegularExpression(@"^\b[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{2,3}\b$", ErrorMessage="Please Enter Valid Email Address")]
        public string? Email { get; set; }
        public required bool IsDelete { get; set; }
        [Display(Name = "Deleted Date")]
        [Column(TypeName = "datetime")]
        [DefaultValue(null)]
        public DateTime? IsDeletedDate { get; set; }

        // Define the one-to-many relationship with Subject
        public ICollection<Subject>? Subjects { get; set; }
    }

    public class Subject
    {
        [Key]
        public int Subject_ID { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter subject title")]
        public required string Title { get; set; }
        public required bool IsDelete { get; set; }
        [Display(Name = "Deleted Date")]
        [Column(TypeName = "datetime")]
        [DefaultValue(null)]
        public DateTime? IsDeletedDate { get; set; }
        [ForeignKey("Tutor")]
        [Required(ErrorMessage = "Please select a tutor")]
        public required int Tutor_ID { get; set; }
        public Tutor? Tutor { get; set; }

        // Define the one-to-many relationship with Enrollment
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
    public class ExamResult
    {
        [Key]
        public int Exam_ID { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        [Range(0,100, ErrorMessage = "Score must be between 0 and 100")]
        [RegularExpression(@"^\d{2,3}(\.\d{1})?$", ErrorMessage = "Score must be between 0 and 100 and upto 1 decimal")]
        [DisplayFormat(DataFormatString = "{0:N1}", ApplyFormatInEditMode = true)]
        public required decimal Mark { get; set; }
        [DefaultValue(null)]
        [Display(Name = "Exam Date")]
        [Column(TypeName = "datetime")]
        public required DateTime ExamDate { get; set; }
        public required bool IsDelete { get; set; }
        [Display(Name = "Deleted Date")]
        [Column(TypeName = "datetime")]
        [DefaultValue(null)]
        public DateTime? IsDeletedDate { get; set; }
        [ForeignKey("Enrollment")]
        public required int Enrollment_ID { get; set; }
        public virtual Enrollment? Enrollment { get; set; }

        [NotMapped]
        public virtual int Student_ID { get; set; }
        [NotMapped]
        public virtual int Subject_ID { get; set; }
        [NotMapped]
        public virtual string? Name { get; set; }
        [NotMapped]
        public virtual string? Title { get; set; }
    }

    public class Enrollment
    {
        [Key]
        public int Enrollment_ID { get; set; }
        [ForeignKey("Student")]
        public required int Student_ID { get; set; }

        [ForeignKey("Subject")]
        public required int Subject_ID { get; set; }

        // Define the one-to-one relationship with ExamResult
        public virtual ExamResult? ExamResult { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
        [NotMapped]
        public virtual string? Name { get; set; }
        [NotMapped]
        public virtual string? Title { get; set; }
    }

    // TODO: solve add more tutor to subject relation

    //public class SubjectTutor
    //{
    //    [Key]
    //    public int SubjectTutor_ID { get; set; }

    //    [ForeignKey("Tutor")]
    //    public int Tutor_ID { get; set; }

    //    [ForeignKey("Subject")]
    //    public required int Subject_ID { get; set; }
    //}

}
