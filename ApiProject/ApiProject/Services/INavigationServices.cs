using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApiProject.Services
{
    public interface INavigationServices
    {
        Task NonModalPush(Page page);
        Task ModalPush(Page page);
        Task NonModalPop();
        Task ModalPop();
    }
}
