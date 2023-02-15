using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhanhVn.Common.Enums
{
    public enum OrderStatuses
    {
        New,
        Confirming,
        CustomerConfirming,
        Confirmed,
        Packing,
        Packed,
        ChangeDepot,
        Pickup,
        Shipping,
        Success,
        Failed,
        Canceled,
        Aborted,
        CarrierCanceled,
        SoldOut,
        Returning,
        Returned,
        ConfirmReturned
    }
}
