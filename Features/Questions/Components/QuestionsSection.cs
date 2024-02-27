using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace blazor_test.Features.Questions;

public class QuestionsSection:ComponentBase
{
    [Parameter]
    public QuestionsStateEnum QuestionsState { get; set; }
    [Parameter]
    public EventCallback<QuestionsStateEnum> QuestionsStateChanged { get; set; }

    protected virtual async Task OnQuestionsStateChanged(QuestionsStateEnum nextState){
        await QuestionsStateChanged.InvokeAsync(nextState);
    }
}
