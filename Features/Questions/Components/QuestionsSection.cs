using Microsoft.AspNetCore.Components;

namespace Features.Questions.Components;

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
