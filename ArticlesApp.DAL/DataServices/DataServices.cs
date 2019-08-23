using System;
using ArticlesApp.DAL.DataServices.Online;

namespace ArticlesApp.DAL.DataServices
{
    public static class DataServices
    {
        public static void Init(bool isMock)
        {
            if(!isMock)
            {
                Account = new AccountDataService();
                //Articles = new ArticlesDataService();
            }
            else
            {
                throw new NotImplementedException("Mock data services not implemented yet.");
            }
        }

        public static AccountDataService Account { get; private set; }
        public static ArticlesDataService Articles { get; set; }
        public static AuthorsDataService Authors { get; set; }
        public static ReviewsDataService Reviews { get; set; }
    }
}
