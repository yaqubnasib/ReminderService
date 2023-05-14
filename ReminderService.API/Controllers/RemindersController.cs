using Microsoft.AspNetCore.Mvc;
using ReminderService.Domain.Entities;
using ReminderService.Domain.Models;
using ReminderService.Domain.Services;

namespace ReminderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public RemindersController(IReminderService reminderService)
            => _reminderService = reminderService;


        [HttpGet("{id}")]
        public async Task<ActionResult<Reminder>> GetReminder(int id)
        {
            var reminder = await _reminderService.GetByIdAsync(id);
            if (reminder == null)
                return NotFound();

            return Ok(reminder);
        }

        [HttpGet]
        public IActionResult GetReminders()
        {
            return Ok(_reminderService.GetAll());
        }


        [HttpPost]
        public async Task<IActionResult> Create(ReminderCommandRequest request)
        {
            var reminder = new Reminder
            {
                To = request.To,
                Method = request.Method,
                Content = request.Content,
                SendAt = request.SendAt
            };

            await _reminderService.CreateReminderAsync(reminder);
            //return CreatedAtAction(nameof(GetReminder), new { id = reminder.Id }, reminder);
            return Ok(reminder);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReminder(int id, ReminderCommandRequest request)
        {
            var reminder = await _reminderService.GetByIdAsync(id);

            if (reminder == null)
                return NotFound();

            reminder.To = request.To;
            reminder.Method = request.Method;
            reminder.Content = request.Content;
            reminder.SendAt = request.SendAt;

            await _reminderService.UpdateAsync(reminder);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReminders([FromQuery] List<int> ids)
        {
            await _reminderService.RemoveRangeAsync(ids);
            return NoContent();
        }


    }
}
