using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace blazor_test.Features.Questions;

public class QuestionsSection:ComponentBase
{
    [Parameter]
    public int QuestionsState { get; set; }
    [Parameter]
    public EventCallback<int> QuestionsStateChanged { get; set; }

    protected virtual async Task OnQuestionsStateChanged(int nextState){
        await QuestionsStateChanged.InvokeAsync(nextState);
    }
}
