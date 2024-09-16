using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using TagosysWeb.Service;
using TagosysWeb.Service.interfaces;

namespace TagosysWeb.ViewComponents.Public
{
    [ViewComponent(Name = "Client")]
    public class ClientComponent : ViewComponent
    {
        public IClientService _clientService;

        public ClientComponent(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var team = await _clientService.getClientList();
            ViewData["clientData"] = team.data;
            return View("~/Areas/Public/Views/Components/Client/Client.cshtml");
            // return View($"~/Pages/Components/Client/Client.cshtml");

        }
    }
}
