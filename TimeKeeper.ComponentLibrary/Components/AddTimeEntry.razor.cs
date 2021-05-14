using FluentValidation;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;
using TimeKeeper.Domain.Validators;
using TimeKeeper.Services;

namespace TimeKeeper.ComponentLibrary.Components
{
    public partial class AddTimeEntry
    {
        [Inject] protected IClientService ClientService { get; set; }
        [Inject] protected ICategoryService CategoryService { get; set; }
        [Inject] protected ITimeEntryService TimeEntryService { get; set; }

        [Parameter] public EventCallback<string> OnClick { get; set; }
        [Parameter] public User CurrentUser { get; set; }

        protected TimeEntry TimeEntry { get; set; }        
        protected IEnumerable<Category> Categories { get; set; }        
        protected IEnumerable<Client> Clients { get; set; }        
        
        //validations
        protected FluentValueValidator<int> ClientValidator = new(x => x.GreaterThan(0).WithMessage("Please select client"));
        protected FluentValueValidator<int> CategoryValidator = new(x => x.GreaterThan(0).WithMessage("Please select category"));
        protected FluentValueValidator<string> NotesValidator = new(x => x.NotEmpty().MaximumLength(100).WithMessage("Please enter note"));

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Clients = await ClientService.GetAllAsync();

                Categories = await CategoryService.GetAllAsync();                
            }
        }

        protected override void OnParametersSet()
        {
            TimeEntry = new TimeEntry
            {
                User = CurrentUser.Id,
                CreatedBy = CurrentUser.Id
            };
        }

        protected async Task SaveAsync()
        {
            await TimeEntryService.CreateAsync(TimeEntry);

            await OnClick.InvokeAsync("SubmitTimeEntry");
        }

        protected async Task CancelAsync()
        {            
            await OnClick.InvokeAsync("CancelTimeEntry");
        }
    }
}
