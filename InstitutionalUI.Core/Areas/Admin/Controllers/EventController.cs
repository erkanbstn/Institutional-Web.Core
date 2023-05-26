﻿using AutoMapper;
using Institutional.Core.Core.Models;
using Institutional.Core.Dto.Dtos.Event;
using Institutional.Core.Dto.Dtos.PageImage;
using Institutional.Core.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace InstitutionalUI.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly IEventService _EventService;

        public EventController(IMapper mapper, IFileProvider fileProvider, IEventService EventService)
        {
            _mapper = mapper;
            _fileProvider = fileProvider;
            _EventService = EventService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.EventCount = await _EventService.EventCount();
            var carouselList = _mapper.Map<List<EventListDto>>(await _EventService.ToListAsync());
            return View(carouselList);
        }
        public async Task<IActionResult> EditEvent(int id)
        {
            var eventData = await _EventService.GetByIdAsync(id);
            return View(new EventEditDto()
            {
                Id = eventData.Id,
                BirthDayContent = eventData.BirthDayContent,
                ConversationContent = eventData.ConversationContent,
                DinnerParty = eventData.DinnerParty
            });
        }
        [HttpPost]
        public async Task<IActionResult> EditEvent(EventEditDto EventEditDto)
        {
            var eventData = await _EventService.GetByIdAsync(EventEditDto.Id);
            eventData.ConversationContent = EventEditDto.ConversationContent;
            eventData.BirthDayContent = EventEditDto.BirthDayContent;
            eventData.DinnerParty = EventEditDto.DinnerParty;
            await _EventService.UpdateAsync(eventData);
            return Redirect("~/Admin/Event/Index");
        }
    }
}