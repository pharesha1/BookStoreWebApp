using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.Utility
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public const string Role_User_Individual = "Individual";
        public const string Role_User_Company = "Company";

        public const string Order_Status_Pending = "Pending";
        public const string Order_Status_Approved = "Approved";
        public const string Order_Status_Processing = "Processing";
        public const string Order_Status_Shipped = "Shipped";
        public const string Order_Status_Cancelled = "Cancelled";
        public const string Order_Status_Refunded = "Refunded";

        public const string Payment_Status_Pending = "Pending";
        public const string Payment_Status_Approved = "Approved";
        public const string Payment_Status_DelayedPayment = "ApprovedForDelayedPayment";
        public const string Payment_Status_Rejected = "Rejected";
    }
}
