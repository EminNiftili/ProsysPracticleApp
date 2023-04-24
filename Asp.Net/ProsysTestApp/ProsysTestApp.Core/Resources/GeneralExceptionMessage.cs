namespace ProsysTestApp.Core.Resources
{
    public class GeneralExceptionMessage
    {
        public const string StudentNull = "Şagird məlumatları boş ola bilməz";
        public const string DatabaseHasSameStudent = "Şagird nömrəsi sistemdə mövcuddur!";

        public const string LessonNull = "Dərs məlumatları boş ola bilməz";
        public const string DatabaseHasSameLesson = "Dərs kodu sistemdə mövcuddur!";


        public const string ExamNull = "İmtahan məlumatları boş ola bilməz";
        public const string DatabaseHasSameExam = "Bu dərs kodunda olan şagirdin qiymətləndirməsi mövcuddur!";

        public const string SomethingWrong = "Səhv baş verdi lütfən məlumatları doğruluğundan əmin olun!";
    }
}
