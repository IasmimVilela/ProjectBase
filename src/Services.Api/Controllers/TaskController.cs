using System;
using TaskB3.Application.Interfaces;
using TaskB3.Application.ViewModels;
using TaskB3.Domain.Core.Bus;
using TaskB3.Domain.Core.Notifications;
using TaskB3.Infra.CrossCutting.Identity.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskB3.Services.Api.Controllers.v1
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TarefaController : ApiController
    {
        private readonly ITarefaAppService _tarefaAppService;

        public TarefaController(
            ITarefaAppService tarefaAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _tarefaAppService = tarefaAppService;
        }

        [HttpGet]
        [AllowAnonymous] 
        public IActionResult Get()
        {
            return Response(_tarefaAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _tarefaAppService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost] 
        [Route("create")]
        public IActionResult Post([FromBody]TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            { 
                NotifyModelStateErrors();
                return Response(tarefaViewModel);
            }

            _tarefaAppService.Create(tarefaViewModel);

            return Response(tarefaViewModel);
        }

        [HttpPut] 
        //[Route("update")]
        public IActionResult Put([FromBody]TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(tarefaViewModel);
            }

            _tarefaAppService.Update(tarefaViewModel);

            return Response(tarefaViewModel);
        }

        [HttpDelete] 
        //[Route("remove")]
        public IActionResult Delete(Guid id)
        {
            _tarefaAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("history/{id:int}")]
        public IActionResult History(Guid id)
        {
            var tarefaHistoryData = _tarefaAppService.GetAllHistory(id);
            return Response(tarefaHistoryData);
        }
    }
}
