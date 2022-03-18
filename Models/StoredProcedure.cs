namespace mapun_api.Models
{
    public class SP_REPORTS_USER_BY_REGION
    {
        public int USER_COUNT { get; set; }
        public string OFFICE_NAME { get; set; }
    }
    public class SP_REPORTS_TRIBE_BY_REGION
    {
        public int TRIBE_COUNT { get; set; }
        public string OFFICE_NAME { get; set; }
    }

    public class SP_REPORTS_APPLICANTS_BY_REGION
    {
        public int TOTAL { get; set; }
        public string OFFICE_NAME { get; set; }
    }

    public class SP_REPORTS_APPLICANTS_BY_PERSON
    {
        public int TOTAL { get; set; }
        public string PERSONNEL_NAME { get; set; }
    }

    public class SP_REPORTS_APPLICANTS_BY_CIVIL_STATUS
    {
        public int TOTAL { get; set; }
        public string CIVIL_STATUS { get; set; }
    }

    public class SP_REPORTS_APPLICANTS_BY_GENDER
    {
        public int TOTAL { get; set; }
        public string GENDER { get; set; }
    }

    public class SP_REPORTS_PROCESSED_OVERALL
    {
        public int TOTAL { get; set; }
    }

}